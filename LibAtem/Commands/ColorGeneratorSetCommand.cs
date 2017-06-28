using System;

namespace LibAtem.Commands
{
    [CommandName("CClV")]
    public class ColorGeneratorSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Hue = 1 << 0,
            Saturation = 1 << 1,
            Luma = 1 << 2,
        }

        public MaskFlags Mask { get; set; }
        public uint Index { get; set; }
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Luma { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((uint) Mask);
            cmd.AddUInt8(Index);
            cmd.AddUInt16(10, Hue);
            cmd.AddUInt16(10, Saturation);
            cmd.AddUInt16(10, Luma);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags)cmd.GetUInt8();
            Index = cmd.GetUInt8();
            Hue = cmd.GetUInt16() / 10d;
            Saturation = cmd.GetUInt16() / 10d;
            Luma = cmd.GetUInt16() / 10d;
        }
    }
}