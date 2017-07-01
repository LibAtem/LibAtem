using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_top", 20)]
    public class TopologyCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint MixEffectBlocks { get; set; }
        [Serializable(1), UInt8]
        public uint VideoSources { get; set; }
        [Serializable(2), UInt8]
        public uint ColorGenerators { get; set; }
        [Serializable(3), UInt8]
        public uint Auxiliaries { get; set; }
        [Serializable(5), UInt8]
        public uint MediaPlayers { get; set; }
        [Serializable(6), UInt8]
        public uint SerialPort { get; set; }
        [Serializable(7), UInt8]
        public uint HyperDecks { get; set; }
        [Serializable(8), UInt8]
        public uint DVE { get; set; }
        [Serializable(9), UInt8]
        public uint Stingers { get; set; }
        [Serializable(10), UInt8]
        public uint SuperSource { get; set; }

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.Set(4, 0x00); // Constants
            cmd.Set(11, 0x01, 0x00, 0x01, 0x01); // Constants

            cmd.Set(15, 0x00); // ?
            cmd.Set(16, 0x00); // ?
            cmd.Set(17, 0x01); // Constants
        }
    }
}