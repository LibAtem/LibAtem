using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("ColV", 8)]
    public class ColorGeneratorGetCommand : SerializableCommandBase
    {
        [UInt8Range(0, 1)]
        [Serializable(0)]
        public uint Index { get; set; }

        [UInt16D(10, 0, 100)]
        [Serializable(2)]
        public double Hue { get; set; }

        [UInt16D(10, 0, 100)]
        [Serializable(4)]
        public double Saturation { get; set; }

        [UInt16D(10, 0, 100)]
        [Serializable(6)]
        public double Luma { get; set; }
    }
}