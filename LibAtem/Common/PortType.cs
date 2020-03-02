﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.Common
{
    // TODO - add attribute to describe as audio/video/both
    // TODO - are all these values correct or should it be flags?
    public enum ExternalPortType
    {
        Internal = 0,
        SDI = 1,
        HDMI = 2,
        Composite = 3,
        Component = 4,
        SVideo = 5,
        XLR = 32,
        AESEBU = 64,
        RCA = 128,

        // Note: the below are definitely correct for audio
        TSJack = 512, 
        MADI = 1024,
        TRS = 2048,
    }

    [Flags]
    public enum ExternalPortTypeFlags
    {
        Unknown = 0,
        SDI = 1,
        HDMI = 2,
        Component = 4,
        Composite = 8,
        SVideo = 16,
        Internal = 32,
        XLR = 64,
        AESEBU = 128,
        RCA = 256,
        TSJack = 512,
    }

    public enum InternalPortType
    {
        External = 0,
        Black = 1,
        ColorBars = 2,
        ColorGenerator = 3,
        MediaPlayerFill = 4,
        MediaPlayerKey = 5,
        SuperSource = 6,

        MEOutput = 128,
        Auxiliary = 129,
        Mask = 130,
    }

    public enum AudioPortType
    {
        Unknown = 0,
        SDI = 1,
        HDMI = 2,
        XLR = 32,
        AESEBU = 64,
        RCA = 128,
        Internal = 256,
        Headset = 512
    }

    public enum MacroPortType
    {
        SDI = 0, // TODO Check this
        HDMI = 1,
        Component = 2,
        // TODO - other types
    }

    public static class MacroPortTypeExtensions
    {
        public static MacroPortType ToMacroPortType(this ExternalPortType type)
        {
            switch (type)
            {
                case ExternalPortType.HDMI:
                    return MacroPortType.HDMI;
                case ExternalPortType.Component:
                    return MacroPortType.Component;
                case ExternalPortType.Composite:
                case ExternalPortType.SVideo:
                case ExternalPortType.Internal:
                case ExternalPortType.SDI:
                default:
                    return MacroPortType.SDI;
            }
        }

        public static ExternalPortType ToExternalPortType(this MacroPortType type)
        {
            switch (type)
            {
                case MacroPortType.HDMI:
                    return ExternalPortType.HDMI;
                case MacroPortType.Component:
                    return ExternalPortType.Component;
                case MacroPortType.SDI:
                default:
                    return ExternalPortType.SDI;
            }
        }
    }

    public static class ExternalPortTypeFlagsExtensions
    {
        public static ExternalPortTypeFlags ToFlags(this IEnumerable<ExternalPortType> types)
        {
            ExternalPortTypeFlags res = 0;
            foreach (ExternalPortType t in types)
                res |= t.ToFlag();

            return res;
        }
        public static ExternalPortTypeFlags ToFlag(this ExternalPortType type)
        {
            switch (type)
            {
                case ExternalPortType.HDMI:
                    return ExternalPortTypeFlags.HDMI;
                case ExternalPortType.Component:
                    return ExternalPortTypeFlags.Component;
                case ExternalPortType.Composite:
                    return ExternalPortTypeFlags.Composite;
                case ExternalPortType.SVideo:
                    return ExternalPortTypeFlags.SVideo;
                case ExternalPortType.Internal:
                    return ExternalPortTypeFlags.Internal;
                case ExternalPortType.XLR:
                    return ExternalPortTypeFlags.XLR;
                case ExternalPortType.AESEBU:
                    return ExternalPortTypeFlags.AESEBU;
                case ExternalPortType.RCA:
                    return ExternalPortTypeFlags.RCA;
                case ExternalPortType.TSJack:
                    return ExternalPortTypeFlags.TSJack;
                case ExternalPortType.SDI:
                    return ExternalPortTypeFlags.SDI;
                default:
                    return ExternalPortTypeFlags.Unknown;
            }
        }

        public static List<ExternalPortType> ToExternalPortTypes(this ExternalPortTypeFlags type)
        {
            var res = new List<ExternalPortType>();

            var possibles = Enum.GetValues(typeof(ExternalPortType)).OfType<ExternalPortType>().ToArray();
            foreach (ExternalPortType e in possibles)
            {
                if ((type & e.ToFlag()) != 0)
                    res.Add(e);
            }

            if (res.Count == 0) res.Add(0);
            return res;
        }

        
        public static AudioPortType ToAudioPortType(this ExternalPortTypeFlags type)
        {
            if (type >= ExternalPortTypeFlags.XLR) return (AudioPortType)((int)type >> 1);
            if (type == ExternalPortTypeFlags.Internal) return AudioPortType.Internal;
            return (AudioPortType)type;
        }

        public static ExternalPortTypeFlags ToExternalPortType(this AudioPortType type)
        {
            if (type >= AudioPortType.XLR) return (ExternalPortTypeFlags)((int)type << 1);
            if (type == AudioPortType.Internal) return ExternalPortTypeFlags.Internal;
            return (ExternalPortTypeFlags)type;
        }
    }
}