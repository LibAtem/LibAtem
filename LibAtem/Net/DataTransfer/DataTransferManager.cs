using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;

namespace LibAtem.Net.DataTransfer
{
    public class DataTransferManager : IDisposable
    {
        private static readonly IReadOnlyList<Type> AcceptedCommands;

        private readonly AtemConnection _connection;
        private readonly ConcurrentQueue<DataTransferJob> _queue;

        private Timer _startTimer;

        private uint _nextTransferId = 1;

        private readonly object _jobLock;
        private DataTransferJob _currentJob;
        private uint _currentId;

        static DataTransferManager()
        {
            AcceptedCommands = new List<Type>()
            {
                typeof(DataTransferDataCommand),
                typeof(DataTransferCompleteCommand),
                typeof(DataTransferErrorCommand),
                typeof(DataTransferUploadContinueCommand),
            };
        }

        public DataTransferManager(AtemConnection connection)
        {
            _connection = connection;
            _queue = new ConcurrentQueue<DataTransferJob>();
            _jobLock = new object();

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
                
                _currentId = _nextTransferId++;

                var cmd = _currentJob.Start(_currentId);
                if (cmd == null)
                {
                    _currentJob = null;
                    DequeueAndRun();
                    return;
                }

                _connection.QueueCommand(cmd);
            }
        }

        public bool HandleCommand(ICommand cmd)
        {
            lock (_jobLock)
            {
                if (_currentJob == null)
                {
                    // TODO - send error?
                    return false;
                }

                if (!AcceptedCommands.Contains(cmd.GetType()))
                    return false;

                var res = _currentJob.OnMessage(cmd, _connection);
                switch (res)
                {
                    case DataTransferStatus.OK:
                        break; // Job is still working away 
                    case DataTransferStatus.Success:
                        _currentJob = null;
                        break;
                    case DataTransferStatus.Error:
                        // TODO - send error
                        _currentJob = null;
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