using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTSD", CommandDirection.ToServer, 16)] // Client to Server
    public class DataTransferUploadRequestCommand : SerializableCommandBase
    {
        [Flags]
        public enum TransferMode
        {
            NoOp = 0,
            Write = 1,
            Clear = 2, // ?
            Write2 = 256,
            Clear2 = 512,
            Clear2Write = 513,
        }

        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }

        [Serialize(2), UInt16]
        public uint TransferStoreId { get; set; }

        [Serialize(6), UInt16]
        public uint TransferIndex { get; set; }

        [Serialize(8), Int32]
        public int Size { get; set; }

        [Serialize(12), Enum16]
        public TransferMode Mode { get; set; }

        // [Serialize(14), UInt16]
        // public uint Unknown { get; set; } = 0x6411;
    }
}