using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("_TlC", 8)]
    public class TallyChannelConfigCommand : SerializableCommandBase
    {
        [ByteArray]
        [Serializable(0)]
        public byte[] Unknown => new byte[] { 0x00, 0x01, 0x00, 0x00 }; // TODO

        [UInt8Range(0, 20)]
        [Serializable(4)]
        public uint InputCount { get; set; }
    }
}