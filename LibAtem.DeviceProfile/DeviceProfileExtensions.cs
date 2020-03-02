using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.DeviceProfile
{
    public static class DeviceProfileExtensions
    {
        public static uint MaxClipLength(this VideoMode mode, DeviceProfile profile)
        {
            VideoModeResolution res = mode.GetResolution();
            switch (res)
            {
                case VideoModeResolution.PAL:
                case VideoModeResolution.NTSC:
                    return profile.VideoModes.MaxFrames.SD;
                case VideoModeResolution._720:
                    return profile.VideoModes.MaxFrames._720;
                case VideoModeResolution._1080:
                    return profile.VideoModes.MaxFrames._1080;
                case VideoModeResolution._4K:
                    return profile.VideoModes.MaxFrames._4K;
                default:
                    throw new Exception("Unknown VideoModeResolution in DeviceProfileExtensions.MaxClipLength: ");
            }
        }

        public static MeAvailability FilterProfile(this MeAvailability orig, DeviceProfile profile)
        {
            MeAvailability res = orig;
            if (profile.MixEffectBlocks < 2)
                res &= ~MeAvailability.Me2;

            return res;
        }

        public static SourceAvailability FilterProfile(this SourceAvailability orig, DeviceProfile profile)
        {
            SourceAvailability res = orig;
            if (profile.Auxiliaries == 0)
                res &= ~SourceAvailability.Auxiliary;

            if (profile.MultiView == null || profile.MultiView.Count == 0)
                res &= SourceAvailability.Multiviewer;

            if (profile.SuperSource == 0)
                res &= ~(SourceAvailability.SuperSourceArt | SourceAvailability.SuperSourceBox);

            if (profile.UpstreamKeys == 0)
                res &= ~SourceAvailability.KeySource;
            
            return res;
        }

        public static IEnumerable<ExternalPortType> FilterVideoMode(this IEnumerable<ExternalPortType> orig, VideoMode mode)
        {
            if (mode.GetStandard() == VideoModeStandard.SDISD)
                return orig.OrderBy(p => p);

            return orig.Where(p => p != ExternalPortType.Composite && p != ExternalPortType.SVideo).OrderBy(p => p);
        }

        /*
        public static IEnumerable<VideoModeStandard> GetStandards(this DeviceProfile profile)
        {
            return Enum.GetValues(typeof(VideoModeStandard))
                .OfType<VideoModeStandard>()
                .Where(s => s >= profile.VideoModes.MinimumSupported && s <= profile.VideoModes.MaximumSupported);
        }
        */

        public static Tuple<string, string> GetDefaultName(this VideoSource src, DeviceProfile profile)
        {
            if (src == VideoSource.SuperSource && profile.Model == ModelId.Constellation8K)
            {
                return Tuple.Create("SuperSource 1", "SS1");
            }
            switch (profile.Model)
            {
                case ModelId.TwoME:
                    switch (src)
                    {
                        case VideoSource.ME1Prev:
                            return Tuple.Create("ME 1 PVW", "Pvw1");
                        case VideoSource.ME1Prog:
                            return Tuple.Create("ME 1 PGM", "M/E1");
                        case VideoSource.ME2Prev:
                            return Tuple.Create("ME 2 PVW", "Pvw2");
                        case VideoSource.ME2Prog:
                            return Tuple.Create("ME 2 PGM", "M/E2");
                    }
                    break;
                case ModelId.TwoMe4K:
                case ModelId.TwoMEBS4K:
                    switch (src)
                    {
                        case VideoSource.ME1Prev:
                            return Tuple.Create("ME 1 PVW", "Pvw1");
                        case VideoSource.ME1Prog:
                            return Tuple.Create("ME 1 PGM", "Pgm1");
                        case VideoSource.ME2Prev:
                            return Tuple.Create("ME 2 PVW", "Pvw2");
                        case VideoSource.ME2Prog:
                            return Tuple.Create("ME 2 PGM", "Pgm2");
                    }
                    break;
                case ModelId.OneME:
                case ModelId.OneME4K:
                case ModelId.TVStudio:
                case ModelId.TVStudioHD:
                    switch (src)
                    {
                        case VideoSource.ME1Prev:
                            return Tuple.Create("Preview", "Pvw");
                        case VideoSource.ME1Prog:
                            return Tuple.Create("Program", "Pgm");
                    }
                    break;
            }

            if (profile.MixEffectBlocks > 1)
            {
                switch (src)
                {
                    case VideoSource.Key1Mask:
                        return Tuple.Create("ME 1 Key 1 Mask", "M1K1");
                    case VideoSource.Key2Mask:
                        return Tuple.Create("ME 1 Key 2 Mask", "M1K2");
                    case VideoSource.Key3Mask:
                        return Tuple.Create("ME 2 Key 1 Mask", "M2K1");
                    case VideoSource.Key4Mask:
                        return Tuple.Create("ME 2 Key 2 Mask", "M2K2");
                }
            }
            else
            {
                switch (src)
                {
                    case VideoSource.Key1Mask:
                        return Tuple.Create("Key 1 Mask", "M1K1");
                    case VideoSource.Key2Mask:
                        return Tuple.Create("Key 2 Mask", "M1K2");
                    case VideoSource.Key3Mask:
                        return Tuple.Create("Key 3 Mask", "M1K3");
                    case VideoSource.Key4Mask:
                        return Tuple.Create("Key 4 Mask", "M1K4");
                }
            }

            var nameAttr = src.GetAttribute<VideoSource, VideoSourceDefaultsAttribute>();
            return Tuple.Create(nameAttr.LongName, nameAttr.ShortName);
        }
    }
}