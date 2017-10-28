using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTCD", 12)] // Client to Server
    public class DataTransferUploadContinueCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
        
        [Serialize(2), UInt8]
        public uint Count => 26; // TODO - why this number?

        [Serialize(6), UInt16]
        public uint Test => 0x0574;
        [Serialize(8), UInt16]
        public uint Test2 => 0x0142;
        [Serialize(10), UInt16]
        public uint Test3 => 0x8b00;
    }
}