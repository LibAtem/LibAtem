using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvBC", CommandDirection.ToClient, 12)]
    public class MultiviewBorderColorGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }

        [Serialize(2), UInt16D(1000, 0, 1000)]
        public double Red { get; set; }

        [Serialize(4), UInt16D(1000, 0, 1000)]
        public double Green { get; set; }

        [Serialize(6), UInt16D(1000, 0, 1000)]
        public double Blue { get; set; }

        [Serialize(8), UInt16D(1000, 0, 1000)]
        public double Alpha { get; set; }
    }
}