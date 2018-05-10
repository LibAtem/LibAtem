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
            Clear = 2, // ?
            WriteAudio = 256, // TODO - name of this?
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
        public TransferMode Mode { get; set; } // TODO - should this be split into 2x enum8?
    }
}