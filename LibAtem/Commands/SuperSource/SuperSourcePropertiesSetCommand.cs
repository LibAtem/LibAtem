using System;
using LibAtem.Common;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("CSSc")]
    public class SuperSourcePropertiesSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            FillSource = 1 << 0,
            CutSource = 1 << 1,
            ArtForeground = 1 << 2,
            PreMultiplied = 1 << 3,
            Clip = 1 << 4,
            Gain = 1 << 5,
            InvertKey = 1 << 6,
            BorderEnabled = 1 << 7,
            BorderBevel = 1 << 8,
            BorderOuterWidth = 1 << 9,
            BorderInnerWidth = 1 << 10,
            BorderOuterSoftness = 1 << 11,
            BorderInnerSoftness = 1 << 12,
            BorderBevelSoftness = 1 << 13,
            BorderBevelPosition = 1 << 14,
            BorderHue = 1 << 15,
            BorderSaturation = 1 << 16,
            BorderLuma = 1 << 17,
            LightSourceDirection = 1 << 18,
            LightSourceAltitude = 1 << 19,
        }

        public MaskFlags Mask { get; set; }
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
            cmd.AddInt32((int) Mask);
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
            Mask = (MaskFlags) cmd.GetInt32();
            ArtFillInput = (VideoSource)cmd.GetUInt16();
            ArtKeyInput = (VideoSource)cmd.GetUInt16();
            ArtOption = (SuperSourceArtOption) cmd.GetUInt8();
            ArtPreMultiplied = cmd.GetBoolArray()[0];
            ArtClip = cmd.GetUInt16(0, 1000) / 1000d;
            ArtGain = cmd.GetUInt16(0, 1000) / 1000d;
            ArtInvertKey = cmd.GetBoolArray()[0];

            BorderEnabled = cmd.GetBoolArray()[0];
            BorderBevel = (BorderBevel) cmd.GetUInt8();
            cmd.Skip();
            BorderWidthOut = cmd.GetUInt16(0, 1600) / 100d;
            BorderWidthIn = cmd.GetUInt16(0, 1600) / 100d;
            BorderSoftnessOut = cmd.GetUInt8(0, 100) / 100d;
            BorderSoftnessIn = cmd.GetUInt8(0, 100) / 100d;
            BorderBevelSoftness = cmd.GetUInt8(0, 100) / 100d;
            BorderBevelPosition = cmd.GetUInt8(0, 100) / 100d;
            BorderHue = cmd.GetUInt16(0, 3599) / 10d;
            BorderSaturation = cmd.GetUInt16(0, 1000) / 10d;
            BorderLuma = cmd.GetUInt16(0, 1000) / 10d;

            BorderLightSourceDirection = cmd.GetUInt16(0, 3590) / 10d;
            BorderLightSourceAltitude = cmd.GetUInt8(10, 100);

            cmd.Skip();
        }
    }
}