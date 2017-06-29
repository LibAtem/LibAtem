using System;
using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsG")]
    public class DownstreamKeyGeneralSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            PreMultiply = 1 << 0,
            Clip = 1 << 1,
            Gain = 1 << 2,
            Invert = 1 << 3,
        }

        public MaskFlags Mask { get; set; }
        public DownstreamKeyId Index { get; set; }
        public bool PreMultiply { get; set; }
        public double Clip { get; set; }
        public double Gain { get; set; }
        public bool Invert { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) Index);

            cmd.AddBoolArray(PreMultiply);
            cmd.Pad();

            cmd.AddUInt16(10, Clip);
            cmd.AddUInt16(10, Gain);
            cmd.AddBoolArray(Invert);

            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            Index = (DownstreamKeyId)cmd.GetUInt8();

            PreMultiply = cmd.GetBoolArray()[0];
            cmd.Skip();

            Clip = cmd.GetUInt16(0, 1000) / 10d;
            Gain = cmd.GetUInt16(0, 1000) / 10d;
            Invert = cmd.GetBoolArray()[0];

            cmd.Skip(3);
        }
    }
}