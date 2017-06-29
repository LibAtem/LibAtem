using LibAtem.Common;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSrc")]
    public class SuperSourcePropertiesGetCommand : ICommand
    {
        public VideoSource ArtFillInput { get; set; }
        public VideoSource ArtKeyInput { get; set; }
        public SuperSourceArtOption ArtOption { get; set; }
        public bool ArtPreMultiplied { get; set; }
        public double ArtClip { get; set; }
        public double ArtGain { get; set; }
        public bool ArtInvertKey { get; set; }

        public bool BorderEnabled { get; set; }
        public BorderBevel BorderBevel { get; set; }
        public double BorderWidthOut { get; set; }
        public double BorderWidthIn { get; set; }
        public double BorderSoftnessOut { get; set; }
        public double BorderSoftnessIn { get; set; }
        public double BorderBevelSoftness { get; set; }
        public double BorderBevelPosition { get; set; }
        public double BorderHue { get; set; }
        public double BorderSaturation { get; set; }
        public double BorderLuma { get; set; }
        public double BorderLightSourceDirection { get; set; }
        public double BorderLightSourceAltitude { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16((uint)ArtFillInput);
            cmd.AddUInt16((uint)ArtKeyInput);
            cmd.AddUInt8((int)ArtOption);
            cmd.AddBoolArray(ArtPreMultiplied);
            cmd.AddUInt16(1000, ArtClip);
            cmd.AddUInt16(1000, ArtGain);
            cmd.AddBoolArray(ArtInvertKey);

            cmd.AddBoolArray(BorderEnabled);
            cmd.AddUInt8((int)BorderBevel);
            cmd.Pad();
            cmd.AddUInt16(100, BorderWidthOut);
            cmd.AddUInt16(100, BorderWidthIn);
            cmd.AddUInt8(100, BorderSoftnessOut);
            cmd.AddUInt8(100, BorderSoftnessIn);
            cmd.AddUInt8(100, BorderBevelSoftness);
            cmd.AddUInt8(100, BorderBevelPosition);
            cmd.AddUInt16(10, BorderHue);
            cmd.AddUInt16(10, BorderSaturation);
            cmd.AddUInt16(10, BorderLuma);
            cmd.AddUInt16(10, BorderLightSourceDirection);
            cmd.AddUInt8(1, BorderLightSourceAltitude);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            // TODO
        }
    }
}