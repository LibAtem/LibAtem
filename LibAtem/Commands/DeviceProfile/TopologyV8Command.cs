using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_top", CommandDirection.ToClient, ProtocolVersion.V8_0, 24), NoCommandId]
    public class TopologyV8Command : SerializableCommandBase
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

        [Serialize(17), Bool]
        public bool CameraControl { get; set; }

        [Serialize(21), Bool]
        public bool AdvancedChromaKeyers { get; set; }
        [Serialize(22), Bool]
        public bool OnlyConfigurableOutputs { get; set; }
    }

    [CommandName("_top", CommandDirection.ToClient, ProtocolVersion.V8_1_1, 28), NoCommandId]
    public class TopologyV811Command : SerializableCommandBase
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
        [Serialize(8), UInt8]
        public uint HyperDecks { get; set; }
        [Serialize(9), UInt8]
        public uint DVE { get; set; }
        [Serialize(10), UInt8]
        public uint Stingers { get; set; }
        [Serialize(11), UInt8]
        public uint SuperSource { get; set; }

        [Serialize(18), Bool]
        public bool CameraControl { get; set; }

        [Serialize(22), Bool]
        public bool AdvancedChromaKeyers { get; set; }
        [Serialize(23), Bool]
        public bool OnlyConfigurableOutputs { get; set; }
    }
}
