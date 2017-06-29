using LibAtem.Common;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSBP")]
    public class SuperSourceBoxGetCommand : ICommand
    {
        public uint Index { get; set; }
        public bool Enabled { get; set; }
        public VideoSource InputSource { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double Size { get; set; }

        public bool Cropped { get; set; }
        public double CropTop { get; set; }
        public double CropBottom { get; set; }
        public double CropLeft { get; set; }
        public double CropRight { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(Index);
            cmd.AddBoolArray(Enabled);
            cmd.AddUInt16((uint)InputSource);
            cmd.AddInt16(100, PositionX);
            cmd.AddInt16(100, PositionY);
            cmd.AddUInt16(1000, Size);
            cmd.AddBoolArray(Cropped);
            cmd.Pad();
            cmd.AddUInt16(1000, CropTop);
            cmd.AddUInt16(1000, CropBottom);
            cmd.AddUInt16(1000, CropLeft);
            cmd.AddUInt16(1000, CropRight);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = cmd.GetUInt8();
            Enabled = cmd.GetBoolArray()[0];
            InputSource = (VideoSource)cmd.GetUInt16();
            PositionX = cmd.GetInt16(-4800, 4800) / 100d;
            PositionY = cmd.GetInt16(-4800, 4800) / 100d;
            Size = cmd.GetUInt16(70, 1000) / 1000d;

            Cropped = cmd.GetBoolArray()[0];
            cmd.Skip();

            CropTop = cmd.GetUInt16(0, 18000) / 1000d;
            CropBottom = cmd.GetUInt16(0, 18000) / 1000d;
            CropLeft = cmd.GetUInt16(0, 32000) / 1000d;
            CropRight = cmd.GetUInt16(0, 32000) / 1000d;
        }
    }
}