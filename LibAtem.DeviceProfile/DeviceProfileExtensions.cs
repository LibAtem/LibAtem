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

    }
}