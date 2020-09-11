using System;
using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.Net.DataTransfer
{
    public enum DataTransferStatus
    {
        OK,
        Success,
        Unknown,
    }

    public abstract class DataTransferJob
    {
        public uint StoreId { get; }
        public DateTime? ExpiresAt { get; private set; }

        public DateTime? StartedAt { get; protected set; }

        protected DataTransferJob(uint storeId, TimeSpan? timeout = null)
        {
            StoreId = storeId;
            ExpiresAt = DateTime.Now + timeout;
        }

        public abstract ICommand Start(uint transferID);

        public abstract DataTransferStatus OnMessage(ICommand command, AtemConnection connection);

        public void SetExpired()
        {
            this.ExpiresAt = DateTime.MinValue;
        }
        // TODO - add cancel method
        //public abstract void Cancel();

        // Job has failed, notify callback
        public abstract void Fail();
    }
}