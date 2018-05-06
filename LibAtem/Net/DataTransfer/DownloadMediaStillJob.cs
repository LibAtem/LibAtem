using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;

namespace LibAtem.Net.DataTransfer
{
    public class DownloadMediaStillJob : DataTransferJob
    {
        private readonly Action<byte[]> _onComplete;
        private readonly List<byte[]> _receivedData;
        private uint _id;

        public DownloadMediaStillJob(uint index, Action<byte[]> onComplete, TimeSpan? timeout = null)
            : base(0, index, timeout)
        {
            _onComplete = onComplete;
            _receivedData = new List<byte[]>();
        }

        public override ICommand Start(uint transferID)
        {
            StartedAt = DateTime.Now;
            if (StartedAt >= ExpiresAt)
                return null;

            _id = transferID;

            return new DataTransferDownloadRequestCommand()
            {
                TransferId = transferID,
                TransferIndex = Index,
                TransferStoreId = StoreId,
            };
        }

        public override DataTransferStatus OnMessage(ICommand command, AtemConnection connection)
        {
            if (command is DataTransferDataCommand dataCommand && dataCommand.TransferId == _id)
            {
                // TODO - do i need to track ids to avoid duplicate data on retransmits?
                _receivedData.Add(dataCommand.Body);

                connection.QueueCommand(new DataTransferAckCommand()
                {
                    TransferId = _id,
                    TransferIndex = Index,
                });

                return DataTransferStatus.OK;
            }

            if (command is DataTransferCompleteCommand completeCommand && completeCommand.TransferId == _id)
            {
                var fullData = _receivedData.SelectMany(d => d).ToArray();
                _onComplete(fullData);
                return DataTransferStatus.Success;
            }

            _onComplete(null);
            return DataTransferStatus.Error;
        }
    }
}