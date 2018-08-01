using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;
using LibAtem.MacroOperations;

namespace LibAtem.Net.DataTransfer
{
    public class DownloadMacroJob : DownloadMacroBytesJob
    {
        public DownloadMacroJob(uint index, Action<IReadOnlyList<MacroOpBase>> onComplete, TimeSpan? timeout=null) 
            : base(index, d => onComplete(Deserialize(d)), timeout)
        {
        }

        private static IReadOnlyList<MacroOpBase> Deserialize(IEnumerable<byte[]> data)
        {
            return data?.Select(MacroOpManager.CreateFromData).ToList();
        }
    }

    public class DownloadMacroBytesJob : DataTransferJob
    {
        private readonly uint _index;
        private readonly Action<IReadOnlyList<byte[]>> _onComplete;
        private readonly List<byte[]> _receivedData;
        private uint _id;

        public DownloadMacroBytesJob(uint index, Action<IReadOnlyList<byte[]>> onComplete, TimeSpan? timeout = null)
            : base(0xffff, timeout)
        {
            _index = index;
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
                Unknown = 0x03fe,
                Unknown2 = 0x6411,
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
                var ops = new List<byte[]>();
                var fullData = _receivedData.SelectMany(d => d).ToArray();

                int length = fullData.Length;
                int pos = 0;
                while (pos < length)
                {
                    uint opLength = BitConverter.ToUInt16(fullData, pos);

                    byte[] opData = new byte[opLength];
                    Array.Copy(fullData, pos, opData, 0, opLength);
                    pos += (int)opLength;

                    ops.Add(opData);
                }

                _onComplete(ops);
                return DataTransferStatus.Success;
            }

            _onComplete(null);
            return DataTransferStatus.Error;
        }
    }
}