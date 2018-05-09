using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;
using LibAtem.Common;
using LibAtem.Util.Media;

namespace LibAtem.Net.DataTransfer
{
    public class DownloadMediaStillJob : DataTransferJob
    {
        private readonly uint _index;
        private readonly VideoModeResolution _resolution;
        private readonly Action<AtemFrame> _onComplete;
        private readonly List<byte[]> _receivedData;
        private uint _id;

        // TODO - name to use
        public DownloadMediaStillJob(uint index, VideoModeResolution resolution, Action<AtemFrame> onComplete, TimeSpan? timeout = null)
            : base(0, timeout)
        {
            _index = index;
            _resolution = resolution;
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
                TransferIndex = _index,
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
                    TransferIndex = _index,
                });

                return DataTransferStatus.OK;
            }

            if (command is DataTransferCompleteCommand completeCommand && completeCommand.TransferId == _id)
            {
                var fullData = _receivedData.SelectMany(d => d).ToArray();
                _onComplete(AtemFrame.FromAtem(_resolution, "", fullData)); // TODO - name
                return DataTransferStatus.Success;
            }

            _onComplete(null);
            return DataTransferStatus.Error;
        }
    }
}