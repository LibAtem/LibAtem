using System;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;
using LibAtem.Util.Media;

namespace LibAtem.Net.DataTransfer
{
    public class UploadMediaStillJob : UploadMediaFrameJob
    {
        public UploadMediaStillJob(uint index, AtemFrame frame, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(0, index, frame, onComplete, timeout)
        {
        }
    }


    public class UploadMediaFrameJob : DataTransferJob
    {
        private readonly uint _index;
        private readonly AtemFrame _frame;
        private readonly Action<bool> _onComplete;
        private readonly byte[] _remainingData;
        private int _sentData;
        private uint _id;

        public UploadMediaFrameJob(uint bank, uint index, AtemFrame frame, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(bank, timeout)
        {
            _index = index;
            _frame = frame;
            _onComplete = onComplete;
            _remainingData = frame.GetRLEEncodedYCbCr();
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
                TransferIndex = _index,
                TransferStoreId = StoreId,
                Size = _frame.GetYCbCrData().Length,
                Mode = DataTransferUploadRequestCommand.TransferMode.Write,
            };
            // TODO - seperate clear op?
        }

        private bool sentDescription;

        public override DataTransferStatus OnMessage(ICommand command, AtemConnection connection)
        {
            if (command is DataTransferUploadContinueCommand continueCommand && continueCommand.TransferId == _id)
            {
                if (!sentDescription)
                {
                    var toSend = new DataTransferFileDescriptionCommand()
                    {
                        TransferId = _id,
                        Name = _frame.Name,
                        Description = "",
                        FileHash = _frame.GetHash(),
                    };
                    connection.QueueCommand(toSend);
                    sentDescription = true;
                }

                if (_sentData >= _remainingData.Length)
                {
                    return DataTransferStatus.OK;
                }

                // queue data
                var chunkSize = continueCommand.ChunkSize - 4;
                for (int i = 0; i < continueCommand.ChunkCount; i++)
                {
                    if (_sentData >= _remainingData.Length)
                        break;

                    var len = _sentData + chunkSize > _remainingData.Length ? (long) (_remainingData.Length - _sentData) : chunkSize;
                    byte[] b = new byte[len];
                    Array.Copy(_remainingData, _sentData, b, 0, len);

                    connection.QueueCommand(new DataTransferDataCommand
                    {
                        TransferId = _id,
                        Body = b,
                    });
                    _sentData += (int) len;
                }

                return DataTransferStatus.OK;
            }

            if (command is DataTransferCompleteCommand completeCmd && completeCmd.TransferId == _id)
            {
                _onComplete(true);
                return DataTransferStatus.Success;
            }

            _onComplete(false);
            return DataTransferStatus.Error;
        }
    }
}