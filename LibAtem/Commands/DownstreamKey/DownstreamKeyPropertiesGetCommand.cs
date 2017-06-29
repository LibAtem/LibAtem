using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskP")]
    public class DownstreamKeyPropertiesGetCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }
        public bool Tie { get; set; }
        public uint Rate { get; set; }
        public bool PreMultipliedKey { get; set; }
        public double Clip { get; set; }
        public double Gain { get; set; }
        public bool Invert { get; set; }
        public bool MaskEnabled { get; set; }
        public double MaskTop { get; set; }
        public double MaskBottom { get; set; }
        public double MaskLeft { get; set; }
        public double MaskRight { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddBoolArray(Tie);
            cmd.AddUInt8(Rate);

            cmd.AddBoolArray(PreMultipliedKey);
            cmd.AddUInt16(10, Clip);
            cmd.AddUInt16(10, Gain);
            cmd.AddBoolArray(Invert);

            cmd.AddBoolArray(MaskEnabled);
            cmd.AddInt16(1000, MaskTop);
            cmd.AddInt16(1000, MaskBottom);
            cmd.AddInt16(1000, MaskLeft);
            cmd.AddInt16(1000, MaskRight);

            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId)cmd.GetUInt8();
            Tie = cmd.GetBoolArray()[0];
            Rate = cmd.GetUInt8();

            PreMultipliedKey = cmd.GetBoolArray()[0];
            Clip = cmd.GetUInt16() / 10d;
            Gain = cmd.GetUInt16() / 10d;
            Invert = cmd.GetBoolArray()[0];

            MaskEnabled = cmd.GetBoolArray()[0];
            MaskTop = cmd.GetInt16() / 1000d;
            MaskBottom = cmd.GetInt16() / 1000d;
            MaskLeft = cmd.GetInt16() / 1000d;
            MaskRight = cmd.GetInt16() / 1000d;

            cmd.Skip(2);
        }
    }
}