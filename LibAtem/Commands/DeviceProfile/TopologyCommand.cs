using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_top", 20), NoCommandId]
    public class TopologyCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint MixEffectBlocks { get; set; }
        [Serialize(1), UInt8]
        public uint VideoSources { get; set; }
        [Serialize(2), UInt8]
        public uint ColorGenerators { get; set; }
        [Serialize(3), UInt8]
        public uint Auxiliaries { get; set; }
        [Serialize(3), UInt8]
        public uint TalkbackOutputs { get; set; }
        [Serialize(5), UInt8]
        public uint MediaPlayers { get; set; }
        [Serialize(6), UInt8]
        public uint SerialPort { get; set; }
        [Serialize(7), UInt8]
        public uint HyperDecks { get; set; }
        [Serialize(8), UInt8]
        public uint DVE { get; set; }
        [Serialize(9), UInt8]
        public uint Stingers { get; set; }
        [Serialize(10), UInt8]
        public uint SuperSource { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);

            // 2ME
            //            cmd.Set(11, 0x01, 0x00, 0x01, 0x01); // Constants
            //            // 1ME is 0x01, 0x01, 0x00, 0x01
            //
            //            cmd.Set(15, 0x00); // ? 1ME is 0x01
            //            cmd.Set(16, 0x00); // ? 1ME is 0x01
            //            cmd.Set(17, 0x01); // ? 1ME is 0x00

            // 1ME
            cmd.Set(11, 0x01, 0x01, 0x00, 0x01); // Constants
            cmd.Set(15, 0x01); // ? 
            cmd.Set(16, 0x01); // ? 
            cmd.Set(17, 0x00); // ?  
        }
    }
}
