using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("_TlC", 8)]
    public class TallyChannelConfigCommand : SerializableCommandBase
    {
        [Serialize(0), ByteArray]
        public byte[] Unknown => new byte[] { 0x00, 0x01, 0x00, 0x00 }; // TODO
        
        [Serialize(4), UInt8Range(0, 20)]
        public uint InputCount { get; set; }
    }
}