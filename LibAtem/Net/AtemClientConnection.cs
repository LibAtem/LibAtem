using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;

namespace LibAtem.Net
{
    public class AtemClientConnection : AtemConnection
    {
        private readonly List<ICommand> _queuedCommands;

        public AtemClientConnection(EndPoint endpoint, int sessionId) : base(endpoint, sessionId)
        {
            _queuedCommands = new List<ICommand>();
        }

        public override void QueueCommand(ICommand command)
        {
            lock (_queuedCommands)
            {
                _queuedCommands.Add(command);
            }
        }

        protected override OutboundMessage CompileNextMessage()
        {
            lock (_queuedCommands)
            {
                if (_queuedCommands.Any())
                    return CompileQueuedUpdateMessage(_queuedCommands);
            }

            return base.CompileNextMessage();
        }

        private static OutboundMessage CompileQueuedUpdateMessage(List<ICommand> commands)
        {
            var builder = new OutboundMessageBuilder();

            int removeCount = 0;
            foreach (ICommand cmd in commands)
            {
                if (!builder.TryAddCommand(cmd))
                    break;
                    
                removeCount++;
            }

            commands.RemoveRange(0, removeCount);
            return builder.Create();
        }
    }

    public class DataTransferManager
    {
        private readonly AtemConnection _connection;
        private readonly List<DataTransferJob> _queue;

        private uint _nextTransferId = 1;

        private DataTransferJob _currentJob;
        private uint _currentId;
        private List<byte[]> _data;
        


        public DataTransferManager(AtemConnection connection)
        {
            _connection = connection;
            _queue = new List<DataTransferJob>();
        }

        public bool IsActive => _currentJob != null; // TODO - is this right?

        public void StartReceive(DataTransferJob job)
        {
            // TODO - locking and ensure not already in progress

            _currentJob = job;
            _currentId = _nextTransferId++;
            _data.Clear();
            
            _connection.QueueCommand(new DataTransferDownloadRequestCommand()
            {
                TransferId = _currentId,
                TransferIndex = job.Index,
                TransferStoreId = job.StoreId,
            });
        }

        public bool HandleCommand(ICommand cmd)
        {
//            if (cmd is )

            return false;
        }

        public void StartSend()
        {
            // TODO need a wireshark capture before this can be done.
        }

    }

    public enum DataTransferMode
    {
        Send,
        Receive,
    }

    public class DataTransferJob
    {
        public uint StoreId { get; }
        public uint Index { get; }
        public Func<byte[]> OnComplete { get; }

        public DataTransferJob(uint storeId, uint index, Func<byte[]> onComplete)
        {
            StoreId = storeId;
            Index = index;
            OnComplete = onComplete;
        }
    }

}