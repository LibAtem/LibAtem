using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class SuperSourceState
    {
        public IReadOnlyList<BoxState> Boxes { get; set; } = new List<BoxState>();

        public PropertiesState Properties { get; } = new PropertiesState();
        public BorderState Border { get; } = new BorderState();

        [Serializable]
        public class BoxState
        {
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
        }
        
        [Serializable]
        public class PropertiesState
        {
            public VideoSource ArtFillInput { get; set; }
            public VideoSource ArtKeyInput { get; set; }
            public SuperSourceArtOption ArtOption { get; set; }
            public bool ArtPreMultiplied { get; set; }
            public double ArtClip { get; set; }
            public double ArtGain { get; set; }
            public bool ArtInvertKey { get; set; }
        }
        
        [Serializable]
        public class BorderState
        {
            public bool Enabled { get; set; }
            public BorderBevel Bevel { get; set; }
            public double OuterWidth { get; set; }
            public double InnerWidth { get; set; }
            public uint OuterSoftness { get; set; }
            public uint InnerSoftness { get; set; }
            public uint BevelSoftness { get; set; }
            public uint BevelPosition { get; set; }
            public double Hue { get; set; }
            public double Saturation { get; set; }
            public double Luma { get; set; }
            public double LightSourceDirection { get; set; }
            public double LightSourceAltitude { get; set; }
        }
    }
}