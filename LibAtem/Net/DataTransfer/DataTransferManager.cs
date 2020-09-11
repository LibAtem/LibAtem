using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;
using LibAtem.Commands.Media;

namespace LibAtem.Net.DataTransfer
{
    public enum LockOwner
    {
        None,
        This,
        Other,
    }

    public class DataTransferManager : IDisposable
    {
        private const uint MacroPoolId = 0xffff;
        
        private static readonly IReadOnlyList<Type> AcceptedCommands;

        private readonly AtemConnection _connection;
        private readonly ConcurrentQueue<DataTransferJob> _queue;

        private Timer _startTimer;

        private uint _nextTransferId;

        private readonly object _jobLock;
        private DataTransferJob _currentJob;
        private ICommand _currentStartCommand;
        private uint _currentId;

        private readonly Dictionary<uint, LockOwner> _owners;
        private readonly object _ownersLock;

        static DataTransferManager()
        {
            AcceptedCommands = new List<Type>()
            {
                typeof(DataTransferDataCommand),
                typeof(DataTransferCompleteCommand),
                typeof(DataTransferErrorCommand),
                typeof(DataTransferUploadContinueCommand),
                typeof(MediaPoolClipDescriptionCommand), // TODO - this shouldnt be here
            };
        }

        public DataTransferManager(AtemConnection connection)
        {
            _connection = connection;
            _queue = new ConcurrentQueue<DataTransferJob>();
            _jobLock = new object();

            _owners = new Dictionary<uint, LockOwner>();
            _ownersLock = new object();

            StartTimer();
        }

        internal void Reset()
        {
            lock(_ownersLock)
            {
                _owners.Clear();
            }

            lock (_jobLock) {
                _currentJob = null;
                _currentId = 0;
            }
        }

        private void StartTimer()
        {
            _startTimer = new Timer(o =>
            {
                if (_connection.HasTimedOut)
                    return;

                DequeueAndRun();
            }, null, 0, AtemConstants.DataTransferCheckInterval);
        }

        public bool IsActive => _currentJob != null;
        
        public void QueueJob(DataTransferJob job)
        {
            _queue.Enqueue(job);
        }

        private void DequeueAndRun()
        {
            lock (_jobLock)
            {
                if (_currentJob != null)
                    return;

                if (!_queue.TryDequeue(out _currentJob))
                    return;

                // If job has timed out, skip it and try again
                if (_currentJob.ExpiresAt.HasValue && _currentJob.ExpiresAt.Value < DateTime.Now)
                {
                    _currentJob = null;
                    DequeueAndRun();
                    return;
                }

                _currentId = _nextTransferId++;

                if (_currentJob.StoreId == MacroPoolId) // Macro pool doesnt use a lock
                {
                    GotLock(_currentJob.StoreId);
                    return;
                }

                // Try and get lock
                _connection.QueueCommand(new LockStateSetCommand { Index = _currentJob.StoreId, Locked = true });
            }
        }

        private void GotLock(uint storeId)
        {
            lock (_jobLock)
            {
                if (_currentJob == null || storeId != _currentJob.StoreId)
                {
                    // Don't need it
                    ReleaseLock(storeId);
                    // TODO - will we get stuck if we then never get our lock?
                    return;
                }

                // Ensure only run once
                if (_currentJob.StartedAt != null)
                    return;

                // If transfer has timed out, cancel it and release lock
                if (_currentJob.ExpiresAt.HasValue && _currentJob.ExpiresAt.Value < DateTime.Now)
                {
                    _currentJob = null;
                    ReleaseLock(storeId);
                    return;
                }

                _currentStartCommand = _currentJob.Start(_currentId);
                if (_currentStartCommand == null)
                {
                    // Release lock
                    ReleaseLock(_currentJob.StoreId);

                    _currentJob = null;
                    DequeueAndRun();
                    return;
                }

                _connection.QueueCommand(_currentStartCommand);
            }
        }

        /*
        private bool HoldsLock(uint index)
        {
            lock (_ownersLock)
            {
                if (index >= _owners.Count)
                    return false;

                return _owners[index] == LockOwner.This;
            }
        }
        */

        private void ReleaseLock(uint index)
        {
            if (index != MacroPoolId)
            {
                _connection.QueueCommand(new LockStateSetCommand {Index = index, Locked = false});
            }
        }

        public bool HandleCommand(ICommand cmd)
        {
            if (cmd is LockStateChangedCommand chCmd)
            {
                lock (_ownersLock)
                {
                    if (!chCmd.Locked)
                        _owners[chCmd.Index] = LockOwner.None;
                    else if (!_owners.ContainsKey(chCmd.Index) || _owners[chCmd.Index] == LockOwner.None)
                        _owners[chCmd.Index] = LockOwner.Other;
                }

                return true;
            }

            if (cmd is LockObtainedCommand obCmd)
            {
                lock (_ownersLock)
                {
                    _owners[obCmd.Index] = LockOwner.This;

                    GotLock(obCmd.Index);
                }

                return true;
            }

            lock (_jobLock)
            {
                if (_currentJob == null)
                {
                    // TODO - send error?
                    return false;
                }

                // The atem sends this 'error' while we are not allowed/able to download the asset. we should keep retrying the same start until it succeeds
                // Note: perhaps this means that someone else has the lock, but we have the lock which will become valid once their transfer completes?
                if (cmd is DataTransferErrorCommand errCmd && _currentId == errCmd.TransferId)
                {
                    // This can happen sometimes, and we should retry until it works
                    if (errCmd.ErrorCode == DataTransferError.TryAgain && _currentStartCommand != null)
                    {
                        _connection.QueueCommand(_currentStartCommand);
                        return true;
                    }
                    
                    // The asset was not found, or some unknown error meaning we should fail and move on
                    if (_currentJob != null)
                    {
                        if (errCmd.ErrorCode != DataTransferError.NotFound)
                        {
                            // We don't know the error, so abort the transfer
                            _connection.QueueCommand(new DataTransferAbortCommand
                            {
                                TransferId = _currentId
                            });
                        }

                        ReleaseLock(_currentJob.StoreId);
                        _currentJob.Fail();
                        
                        _currentStartCommand = null;
                        _currentJob = null;
                    }
                    
                    // Try and get next job started
                    DequeueAndRun();
                    return true;
                }

                if (cmd is DataTransferCompleteCommand completeCmd && _currentId != completeCmd.TransferId)
                {
                    // TODO - should we try and start our job?
                    return false;
                }
                
                if (!AcceptedCommands.Contains(cmd.GetType()) || !_currentJob.StartedAt.HasValue)
                    return false;

                var res = _currentJob.OnMessage(cmd, _connection);
                switch (res)
                {
                    case DataTransferStatus.OK:
                        break; // Job is still working away 
                    case DataTransferStatus.Success:

                        ReleaseLock(_currentJob.StoreId);
                        
                        _currentStartCommand = null;
                        _currentJob = null;
                        
                        DequeueAndRun();
                        
                        break;
                    case DataTransferStatus.Unknown:
                        // Command was not handled, this is probably ok
                        // TODO - we should track the time of the last handled command so we can check for stuck transfers
                        return false;
                }

                return true;
            }
        }

        public void Dispose()
        {
            _startTimer?.Dispose();
        }
    }
}