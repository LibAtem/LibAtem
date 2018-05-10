using System;
using System.Security.Cryptography;
using LibAtem.Commands;
using LibAtem.Commands.DataTransfer;

namespace LibAtem.Net.DataTransfer
{
    public class UploadMediaAudioJob : UploadJobBase
    {
        private readonly string _name;

        public UploadMediaAudioJob(uint index, string name, byte[] data, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(index + 1, data, onComplete, timeout)
        {
            _name = name;
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
                TransferIndex = 0,
                TransferStoreId = StoreId,
                Size = Data.Length,
                Mode = DataTransferUploadRequestCommand.TransferMode.WriteAudio,
            };
            // TODO - seperate clear op?
        }

        protected override DataTransferFileDescriptionCommand GetDescription()
        {
            byte[] hash;
            using (MD5 md5Hash = MD5.Create())
                hash = md5Hash.ComputeHash(Data);

            return new DataTransferFileDescriptionCommand()
            {
                TransferId = TransferId,
                Name = _name,
                Description = "",
                FileHash = hash,
            };
        }
    }
}