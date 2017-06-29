using System;
using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsM")]
    public class DownstreamKeyMaskSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Enabled = 1 << 0,
            Top = 1 << 1,
            Bottom = 1 << 2,
            Left = 1 << 3,
            Right = 1 << 4,
        }

        public MaskFlags Mask { get; set; }
        public DownstreamKeyId Index { get; set; }
        public bool Enabled { get; set; }
        public double Top { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Mask);
            cmd.AddUInt8((int)Index);

            cmd.AddBoolArray(Enabled);
            cmd.Pad();

            cmd.AddInt16(1000, Top);
            cmd.AddInt16(1000, Bottom);
            cmd.AddInt16(1000, Left);
            cmd.AddInt16(1000, Right);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags)cmd.GetUInt8();
            Index = (DownstreamKeyId)cmd.GetUInt8();

            Enabled = cmd.GetBoolArray()[0];
            cmd.Skip();

            Top = cmd.GetInt16(-9000, 9000) / 1000d;
            Bottom = cmd.GetInt16(-9000, 9000) / 1000d;
            Left = cmd.GetInt16(-16000, 16000) / 1000d;
            Right = cmd.GetInt16(-16000, 16000) / 1000d;
        }
    }
}