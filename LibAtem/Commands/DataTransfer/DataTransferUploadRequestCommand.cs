using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTSD", 16)] // Client to Server
    public class DataTransferUploadRequestCommand : SerializableCommandBase
    {
        [Flags]
        public enum TransferMode
        {
            NoOp = 0,
            Write = 1,
            Clear = 2,
        }

        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }

        [Serialize(2), UInt8]
        public uint TransferStoreId { get; set; }

        [Serialize(7), UInt8]
        public uint TransferIndex { get; set; }

        [Serialize(8), Int32]
        public int Size { get; set; }

        [Serialize(13), Enum8]
        public TransferMode Mode { get; set; }
    }
}