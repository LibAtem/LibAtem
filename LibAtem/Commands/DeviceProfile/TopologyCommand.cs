using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_top", CommandDirection.ToClient, 20), NoCommandId]
    public class TopologyCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint MixEffectBlocks { get; set; }
        [Serialize(1), UInt8]
        public uint VideoSources { get; set; }
        [Serialize(2), UInt8]
        public uint DownstreamKeyers { get; set; }
        [Serialize(3), UInt8]
        public uint Auxiliaries { get; set; }
        [Serialize(4), UInt8]
        public uint MixMinusOutputs { get; set; }
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

    }
}
