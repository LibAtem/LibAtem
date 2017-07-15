using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("ColV", 8)]
    public class ColorGeneratorGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8Range(0, 1)]
        public uint Index { get; set; }
        
        [Serialize(2), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }

        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Saturation { get; set; }
        
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Luma { get; set; }
    }
}