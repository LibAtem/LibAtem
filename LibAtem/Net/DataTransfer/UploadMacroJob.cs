using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;
using LibAtem.MacroOperations;

namespace LibAtem.Net.DataTransfer
{
    public class UploadMacroJob : DataTransferJob
    {
        private readonly Action<bool> _onComplete;
        private readonly IReadOnlyList<byte[]> _dataQueue;
        private uint _id;

        public UploadMacroJob(uint index, IReadOnlyList<MacroOpBase> dataQueue, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(0xffff, index, timeout)
        {
            _onComplete = onComplete;
            _dataQueue = dataQueue.Select(o => o.ToByteArray()).ToList();
        }

        public override ICommand Start(uint transferID)
        {
            StartedAt = DateTime.Now;
            if (StartedAt >= ExpiresAt)
                return null;

            _id = transferID;

            return new DataTransferUploadRequestCommand()
            {
                TransferId = transferID,
                TransferIndex = Index,
                TransferStoreId = StoreId,
                Size = _dataQueue.Sum(o => o.Length),
                Mode = DataTransferUploadRequestCommand.TransferMode.Clear | DataTransferUploadRequestCommand.TransferMode.Write,
            };
        }

        public override DataTransferStatus OnMessage(ICommand command, AtemConnection connection)
        {
            var continueCommand = command as DataTransferUploadContinueCommand;
            if (continueCommand != null && continueCommand.TransferId == _id)
            {
                var toSend = new DataTransferFileDescriptionCommand()
                {
                    TransferId = _id
                };
                connection.QueueCommand(toSend);

                // also queue data
                const int maxBodySize = 1350;

                // TODO - is this chunking correctly?
                int startPos = 0;
                while (startPos < _dataQueue.Count)
                {
                    int count = 1;
                    for (; count < _dataQueue.Count - startPos; count++)
                    {
                        int d = _dataQueue.Skip(startPos).Take(count + 1).Sum(v => v.Length);
                        if (d > maxBodySize)
                            break;
                    }

                    connection.QueueCommand(new DataTransferDataCommand()
                    {
                        TransferId = _id,
                        Body = _dataQueue.Skip(startPos).Take(count).SelectMany(b => b).ToArray()
                    });

                    startPos += count;
                }

                return DataTransferStatus.OK;
            }

            var completeCommand = command as DataTransferCompleteCommand;
            if (completeCommand != null && completeCommand.TransferId == _id)
            {
                _onComplete(true);
                return DataTransferStatus.Success;
            }

            _onComplete(false);
            return DataTransferStatus.Error;
        }
    }
}