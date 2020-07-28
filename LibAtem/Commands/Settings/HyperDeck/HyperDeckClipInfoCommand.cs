using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCS", CommandDirection.ToClient, 84)]
    public class HyperDeckClipInfoCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint HyperdeckId { get; set; }
        [CommandId]
        [Serialize(2), UInt16]
        public uint ClipId { get; set; }

        [Serialize(4), String(64)]
        public string Name { get; set; }

        [Serialize(69), UInt8]
        public uint StartHour { get; set; }
        [Serialize(70), UInt8]
        public uint StartMinute { get; set; }
        [Serialize(71), UInt8]
        public uint StartSecond{ get; set; }
        [Serialize(72), UInt8]
        public uint StartFrame { get; set; }

        [Serialize(74), UInt8]
        public uint EndHour { get; set; }
        [Serialize(75), UInt8]
        public uint EndMinute { get; set; }
        [Serialize(76), UInt8]
        public uint EndSecond { get; set; }
        [Serialize(77), UInt8]
        public uint EndFrame { get; set; }

        [Serialize(79), UInt8]
        public uint DurationHour { get; set; }
        [Serialize(80), UInt8]
        public uint DurationMinute { get; set; }
        [Serialize(81), UInt8]
        public uint DurationSecond { get; set; }
        [Serialize(82), UInt8]
        public uint DurationFrame { get; set; }
    }
}