using System;
using LibAtem.Commands;

namespace LibAtem.Net.DataTransfer
{
    public enum DataTransferStatus
    {
        OK,
        Success,
        Error,
    }

    public abstract class DataTransferJob
    {
        public uint StoreId { get; }
        public uint Index { get; }
        public DateTime? ExpiresAt { get; }

        public DateTime? StartedAt { get; protected set; }

        protected DataTransferJob(uint storeId, uint index, TimeSpan? timeout = null)
        {
            StoreId = storeId;
            Index = index;
            ExpiresAt = DateTime.Now + timeout;
        }

        public abstract ICommand Start(uint transferID);

        public abstract DataTransferStatus OnMessage(ICommand command, AtemConnection connection);
    }
}