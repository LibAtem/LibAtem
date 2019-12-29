using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.State.Tolerance;

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
            public VideoSource Source { get; set; }
            [Tolerance(0.01)]
            public double PositionX { get; set; }
            [Tolerance(0.01)]
            public double PositionY { get; set; }
            [Tolerance(0.01)]
            public double Size { get; set; }

            public bool Cropped { get; set; }
            [Tolerance(0.01)]
            public double CropTop { get; set; }
            [Tolerance(0.01)]
            public double CropBottom { get; set; }
            [Tolerance(0.01)]
            public double CropLeft { get; set; }
            [Tolerance(0.01)]
            public double CropRight { get; set; }
        }
        
        [Serializable]
        public class PropertiesState
        {
            public VideoSource ArtFillSource { get; set; }
            public VideoSource ArtCutSource { get; set; }
            public SuperSourceArtOption ArtOption { get; set; }
            public bool ArtPreMultiplied { get; set; }
            [Tolerance(0.01)]
            public double ArtClip { get; set; }
            [Tolerance(0.01)]
            public double ArtGain { get; set; }
            public bool ArtInvertKey { get; set; }
        }
        
        [Serializable]
        public class BorderState
        {
            public bool Enabled { get; set; }
            public BorderBevel Bevel { get; set; }
            [Tolerance(0.01)]
            public double OuterWidth { get; set; }
            [Tolerance(0.01)]
            public double InnerWidth { get; set; }
            public uint OuterSoftness { get; set; }
            public uint InnerSoftness { get; set; }
            public uint BevelSoftness { get; set; }
            public uint BevelPosition { get; set; }
            [Tolerance(0.01)]
            public double Hue { get; set; }
            [Tolerance(0.01)]
            public double Saturation { get; set; }
            [Tolerance(0.01)]
            public double Luma { get; set; }
            [Tolerance(0.01)]
            public double LightSourceDirection { get; set; }
            [Tolerance(0.01)]
            public double LightSourceAltitude { get; set; }
        }
    }
}