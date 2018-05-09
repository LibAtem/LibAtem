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
        private static readonly IReadOnlyList<Type> AcceptedCommands;

        private readonly AtemConnection _connection;
        private readonly ConcurrentQueue<DataTransferJob> _queue;

        private Timer _startTimer;

        private uint _nextTransferId;

        private readonly object _jobLock;
        private DataTransferJob _currentJob;
        private bool _currentJobCompleted;
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
                typeof(MediaPoolClipSourceCommand), // TODO - this shouldnt be here
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
                    DequeueAndRun();
                    return;
                }

                _currentId = _nextTransferId++;
                _currentJobCompleted = false;

                // Try and get lock
                _connection.QueueCommand(new LockStateSetCommand {Index = _currentJob.StoreId, Locked = true});

                if (_currentJob.StoreId == 255) // Macro pool doesnt use a lock
                {
                    GotLock(_currentJob.StoreId);
                }
            }
        }

        private void GotLock(uint storeId)
        {
            lock (_jobLock)
            {
                if (_currentJobCompleted)
                {
                    // TODO - release lock?
                }

                if (_currentJob == null || storeId != _currentJob.StoreId)
                    return;

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

                ICommand cmd = _currentJob.Start(_currentId);
                if (cmd == null)
                {
                    // Release lock
                    _connection.QueueCommand(new LockStateSetCommand { Index = _currentJob.StoreId, Locked = false });

                    _currentJob = null;
                    DequeueAndRun();
                    return;
                }

                _connection.QueueCommand(cmd);
            }
        }

        private void LostLock(uint storeId)
        {
            lock (_jobLock)
            {
                if (_currentJob != null && storeId == _currentJob.StoreId)
                {
                    if (_currentJobCompleted)
                    {
                        _currentJob = null;
                        
                    }
                    else
                    {
                        // TODO - cancel current job instead of just running next

                        DequeueAndRun();
                        return;
                    }
                }
                
                DequeueAndRun();
            }
        }

        private bool HoldsLock(uint index)
        {
            lock (_ownersLock)
            {
                if (index >= _owners.Count)
                    return false;

                return _owners[index] == LockOwner.This;
            }
        }

        private void ReleaseLock(uint index)
        {
            _connection.QueueCommand(new LockStateSetCommand {Index = index, Locked = false});
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

                    if (!chCmd.Locked)
                        LostLock(chCmd.Index);
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
                
                if (!AcceptedCommands.Contains(cmd.GetType()) || !_currentJob.StartedAt.HasValue)
                    return false;

                var res = _currentJob.OnMessage(cmd, _connection);
                switch (res)
                {
                    case DataTransferStatus.OK:
                        break; // Job is still working away 
                    case DataTransferStatus.Success:
                        _currentJobCompleted = true;

                        if (HoldsLock(_currentJob.StoreId))
                            ReleaseLock(_currentJob.StoreId);
                        break;
                    case DataTransferStatus.Error:
                        // TODO - send error
                        _currentJobCompleted = true;

                        if (HoldsLock(_currentJob.StoreId))
                            ReleaseLock(_currentJob.StoreId);
                        break;
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