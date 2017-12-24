using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("SRsv", 4), NoCommandId]
    public class StartupStateSaveCommand : SerializableCommandBase
    {
        [Serialize(0), ByteArray(4)]
        public byte[] Data => new byte[] {0x00, 0xce, 0x4f, 0x01};
    }
}