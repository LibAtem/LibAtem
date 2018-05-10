using System;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;

namespace LibAtem.Net.DataTransfer
{
    public abstract class UploadJobBase : DataTransferJob
    {
        private readonly Action<bool> _onComplete;
        private int _sentData;

        protected uint TransferId { get; set; }
        protected byte[] Data { get; }

        // TODO - refactor UploadMacro to use this
        protected UploadJobBase(uint bank, byte[] data, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(bank, timeout)
        {
            Data = data;
            _onComplete = onComplete;
        }
        
        private bool sentDescription;

        protected abstract DataTransferFileDescriptionCommand GetDescription();

        public override DataTransferStatus OnMessage(ICommand command, AtemConnection connection)
        {
            if (command is DataTransferUploadContinueCommand continueCommand && continueCommand.TransferId == TransferId)
            {
                if (!sentDescription)
                {
                    connection.QueueCommand(GetDescription());
                    sentDescription = true;
                }

                if (_sentData >= Data.Length)
                {
                    return DataTransferStatus.OK;
                }

                // queue data
                var chunkSize = continueCommand.ChunkSize - 4;
                for (int i = 0; i < continueCommand.ChunkCount; i++)
                {
                    if (_sentData >= Data.Length)
                        break;

                    var len = _sentData + chunkSize > Data.Length ? (long)(Data.Length - _sentData) : chunkSize;
                    byte[] b = new byte[len];
                    Array.Copy(Data, _sentData, b, 0, len);

                    connection.QueueCommand(new DataTransferDataCommand
                    {
                        TransferId = TransferId,
                        Body = b,
                    });
                    _sentData += (int)len;
                }

                return DataTransferStatus.OK;
            }

            if (command is DataTransferCompleteCommand completeCmd && completeCmd.TransferId == TransferId)
            {
                _onComplete(true);
                return DataTransferStatus.Success;
            }

            _onComplete(false);
            return DataTransferStatus.Error;
        }
    }
}