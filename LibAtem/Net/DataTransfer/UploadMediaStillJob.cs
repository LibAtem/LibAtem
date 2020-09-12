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

    public class UploadMediaFrameJob : UploadJobBase
    {
        private readonly uint _index;
        private readonly AtemFrame _frame;

        public UploadMediaFrameJob(uint bank, uint index, AtemFrame frame, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(bank, frame.GetYCbCrData() /*.GetRLEEncodedYCbCr() This doesnt work because it needs to line up with command boundaries */, onComplete, timeout)
        {
            _index = index;
            _frame = frame;
        }

        public override ICommand Start(uint transferID)
        {
            StartedAt = DateTime.Now;
            if (StartedAt >= ExpiresAt)
                return null;

            TransferId = transferID;

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

        protected override DataTransferFileDescriptionCommand GetDescription()
        {
            return new DataTransferFileDescriptionCommand()
            {
                TransferId = TransferId,
                Name = _frame.Name,
                Description = "",
                FileHash = _frame.GetHash(),
            };
        }
    }
}