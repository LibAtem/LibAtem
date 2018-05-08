using System;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;
using LibAtem.Util.Media;

namespace LibAtem.Net.DataTransfer
{
    public class UploadMediaStillJob : DataTransferJob
    {
        private readonly AtemFrame _frame;
        private readonly Action<bool> _onComplete;
        private byte[] _remainingData;
        private uint _id;

        public UploadMediaStillJob(uint index, AtemFrame frame, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(0, index, timeout)
        {
            _frame = frame;
            _onComplete = onComplete;
            _remainingData = frame.GetYCbCrData();
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

                if (_remainingData.Length == 0)
                {
                    return DataTransferStatus.OK;
                }

                // queue data
                var chunkSize = continueCommand.ChunkSize - 4;
                for (int i = 0; i < continueCommand.ChunkCount; i++)
                {
                    int startPos = (int) (chunkSize * i);
                    if (startPos > _remainingData.Length)
                        break;
                    
                    connection.QueueCommand(new DataTransferDataCommand()
                    {
                        TransferId = _id,
                        Body = _remainingData.Skip(startPos).Take((int)chunkSize).ToArray()
                    });
                }

                _remainingData = _remainingData.Skip((int) (continueCommand.ChunkCount * chunkSize)).ToArray();

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