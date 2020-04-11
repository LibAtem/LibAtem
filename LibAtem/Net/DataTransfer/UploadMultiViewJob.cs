using System;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;
using LibAtem.Util.Media;

namespace LibAtem.Net.DataTransfer
{

    public class UploadMultiViewJob : UploadJobBase
    {
        private readonly uint _index;
        private readonly AtemFrame _frame;

        public UploadMultiViewJob(uint index, AtemFrame frame, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(0xffff, frame.GetRLEEncodedYCbCr(), onComplete, timeout)
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
                Mode = DataTransferUploadRequestCommand.TransferMode.Clear2Write,
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