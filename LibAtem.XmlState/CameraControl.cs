using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.XmlState
{
    public class CameraControl
    {
        public CameraControl()
        {
            Parameters = new List<CameraControlParameter>();
            Properties = new List<CameraControlProperty>();
        }

        [XmlElement("Parameter")]
        public List<CameraControlParameter> Parameters { get; set; }

        [XmlElement("Property")]
        public List<CameraControlProperty> Properties { get; set; }
    }

    public class CameraControlProperty
    {
        [XmlAttribute("device")]
        public VideoSource Device { get; set; }

        [XmlAttribute("property")]
        public CameraControlPropertyProperty Property { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }

    public enum CameraControlPropertyProperty
    {
        ApertureCoarse,
        Locked,
    }

    public class CameraControlParameter
    {
        [XmlAttribute("device")]
        public VideoSource Device { get; set; }

        [XmlAttribute("category")]
        public CameraControlParameterCategory Category { get; set; }
        [XmlAttribute("parameter")]
        public CameraControlParameterParameter Parameter { get; set; }

        [XmlAttribute("value")]
        public double Value { get; set; }
        public bool ShouldSerializeValue()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ApertureNormalised:
                case CameraControlParameterParameter.SensorGain:
                case CameraControlParameterParameter.ManualWhiteBalance:
                case CameraControlParameterParameter.Exposure:
                case CameraControlParameterParameter.DetailLevel:
                case CameraControlParameterParameter.LumaMix:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("red")]
        public double Red { get; set; }
        public bool ShouldSerializeRed()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("green")]
        public double Green { get; set; }
        public bool ShouldSerializeGreen()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("blue")]
        public double Blue { get; set; }
        public bool ShouldSerializeBlue()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("luma")]
        public double Luma { get; set; }
        public bool ShouldSerializeLuma()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("pivot")]
        public double Pivot { get; set; }
        public bool ShouldSerializePivot()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ContrastAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("adjust")]
        public double Adjust { get; set; }
        public bool ShouldSerializeAdjust()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ContrastAdjust:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("hue")]
        public double Hue { get; set; }
        public bool ShouldSerializeHue()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ColorAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("saturation")]
        public double Saturation { get; set; }
        public bool ShouldSerializeSaturation()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ColorAdjust:
                    return true;
                default:
                    return false;
            }
        }
    }

    public enum CameraControlParameterCategory
    {
        Lens = 0,
        Video = 1,
        Misc = 4,
        ColorCorrection = 8, // aka Chip
        Unknown2 = 11,
    }
    public enum CameraControlParameterParameter
    {
        Unknown = 0,

        ApertureNormalised,

        [CameraControlParameterValue(CameraControlParameterCategory.Lens, 0)]
        Focus,
        [CameraControlParameterValue(CameraControlParameterCategory.Lens, 1)]
        AutoFocus,
        [CameraControlParameterValue(CameraControlParameterCategory.Lens, 3)]
        Iris,
        [CameraControlParameterValue(CameraControlParameterCategory.Lens, 9)]
        Zoom,


        [CameraControlParameterValue(CameraControlParameterCategory.Video, 1)]
        SensorGain,
        [CameraControlParameterValue(CameraControlParameterCategory.Video, 2)]
        ManualWhiteBalance,
        [CameraControlParameterValue(CameraControlParameterCategory.Video, 5)]
        Exposure, // aka Exposure
        [CameraControlParameterValue(CameraControlParameterCategory.Video, 8)]
        DetailLevel,

        [CameraControlParameterValue(CameraControlParameterCategory.ColorCorrection, 0)]
        LiftAdjust,
        [CameraControlParameterValue(CameraControlParameterCategory.ColorCorrection, 1)]
        GammaAdjust,
        [CameraControlParameterValue(CameraControlParameterCategory.ColorCorrection, 2)]
        GainAdjust,
        [CameraControlParameterValue(CameraControlParameterCategory.ColorCorrection, 3)]
        OffsetAdjust, // aka Aperture
        [CameraControlParameterValue(CameraControlParameterCategory.ColorCorrection, 4)]
        ContrastAdjust,
        [CameraControlParameterValue(CameraControlParameterCategory.ColorCorrection, 5)]
        LumaMix,
        [CameraControlParameterValue(CameraControlParameterCategory.ColorCorrection, 6)]
        ColorAdjust,

        [CameraControlParameterValue(CameraControlParameterCategory.Misc, 4)]
        ColorBars,
        [CameraControlParameterValue(CameraControlParameterCategory.Unknown2, 0)]
        Unknown2Unknown,

    }

    public static class CameraControlParameterParameterExtensions
    {
        public static uint GetValue(this CameraControlParameterParameter param)
        {
            var attr = param.GetAttribute<CameraControlParameterParameter, CameraControlParameterValueAttribute>();
            return attr.Value;
        }

        public static bool IsSoemthing(this CameraControlParameterParameter param, CameraControlParameterCategory cat,
            uint val)
        {
            var attr = param.GetPossibleAttribute<CameraControlParameterParameter, CameraControlParameterValueAttribute>();
            if (attr == null)
                return false;

            return attr.Category == cat && attr.Value == val;
        }
    }

    public class CameraControlParameterValueAttribute : Attribute
    {
        public CameraControlParameterCategory Category { get; }
        public uint Value { get; }

        public CameraControlParameterValueAttribute(CameraControlParameterCategory category, uint value)
        {
            Category = category;
            Value = value;
        }
    }
}