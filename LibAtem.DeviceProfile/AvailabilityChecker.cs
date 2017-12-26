using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.DeviceProfile
{
    public static class AvailabilityChecker
    {
        public static object GetMaxForProperty(DeviceProfile profile, string propName)
        {
            switch (propName)
            {
                case "MediaPlayerSourceClipIndex.Index":
                    return profile.MediaPoolClips - 1;
                case "MediaPlayerSourceStillIndex.Index":
                    return profile.MediaPoolStills - 1;
                case "MacroSleep.Frames":
                    return (uint) 500; // TODO
                default:
                    return null;
            }
        }

        public static bool IsAvailable(DeviceProfile profile, object val)
        {
            if (val is VideoSource)
                return IsAvailable((VideoSource)val, profile);
            if (val is AudioSource)
                return IsAvailable((AudioSource)val, profile);
            if (val is MediaPlayerId)
                return IsAvailable((MediaPlayerId)val, profile);
            if (val is StingerSource)
                return IsAvailable((StingerSource)val, profile);
            if (val is MixEffectBlockId)
                return IsAvailable((MixEffectBlockId)val, profile);
            if (val is UpstreamKeyId)
                return IsAvailable((UpstreamKeyId)val, profile);
            if (val is DownstreamKeyId)
                return IsAvailable((DownstreamKeyId)val, profile);
            if (val is AuxiliaryId)
                return IsAvailable((AuxiliaryId)val, profile);

            // Assume it is available as many types do not need implementing
            return true;
        }

        public static bool IsAvailable(this VideoSource src, DeviceProfile profile, params InternalPortType[] ignorePortTypes)
        {
            if (!src.IsValid())
                return false;
            
            VideoSourceTypeAttribute props = src.GetAttribute<VideoSource, VideoSourceTypeAttribute>();
            if (ignorePortTypes.Contains(props.PortType))
                return false;

            switch (props.PortType)
            {
                case InternalPortType.Auxilary:
                    return props.Me1Index <= profile.Auxiliaries;
                case InternalPortType.Black:
                case InternalPortType.ColorBars:
                    return true;
                case InternalPortType.ColorGenerator:
                    return props.Me1Index <= profile.ColorGenerators;
                case InternalPortType.External:
                    return props.Me1Index <= profile.Sources.Count;
                case InternalPortType.MEOutput:
                    return props.Me1Index <= profile.MixEffectBlocks.Count;
                case InternalPortType.Mask:
                    if (profile.MixEffectBlocks.Count > 1)
                        return props.Me2Index <= profile.UpstreamKeys;
                    return props.Me1Index <= profile.UpstreamKeys;
                case InternalPortType.MediaPlayerFill:
                case InternalPortType.MediaPlayerKey:
                    return props.Me1Index <= profile.MediaPlayers;
                case InternalPortType.SuperSource:
                    return props.Me1Index <= profile.SuperSource;
                default:
                    Debug.Fail(String.Format("Invalid source type:{0}", props.PortType));
                    return false;
            }
        }

        public static bool IsAvailable(this AudioSource src, DeviceProfile profile)
        {
            if (!src.IsValid())
                return false;

            VideoSource? videoSrc = src.GetVideoSource();
            if (videoSrc == null)
                return false;

            return videoSrc.Value.IsAvailable(profile);
        }

        public static bool IsAvailable(this MediaPlayerId id, DeviceProfile profile)
        {
            return id.IsValid() && (int) id < profile.MediaPlayers;
        }

        public static bool IsAvailable(this StingerSource src, DeviceProfile profile)
        {
            return src.IsValid() && src > 0 && (int) src < profile.MediaPlayers + 1;
        }

        public static bool IsAvailable(this MixEffectBlockId id, DeviceProfile profile)
        {
            return id.IsValid() && (int)id < profile.MixEffectBlocks.Count;
        }

        public static bool IsAvailable(this UpstreamKeyId id, DeviceProfile profile)
        {
            return id.IsValid() && (int)id < profile.UpstreamKeys;
        }

        public static bool IsAvailable(this DownstreamKeyId id, DeviceProfile profile)
        {
            return id.IsValid() && (int)id < profile.DownstreamKeys;
        }

        public static bool IsAvailable(this AuxiliaryId id, DeviceProfile profile)
        {
            return id.IsValid() && (int)id < profile.Auxiliaries;
        }
        
        public static MeAvailability FilterProfile(this MeAvailability orig, DeviceProfile profile)
        {
            MeAvailability res = orig;
            if (profile.MixEffectBlocks.Count < 2)
                res &= ~MeAvailability.Me2;

            return res;
        }

        public static SourceAvailability FilterProfile(this SourceAvailability orig, DeviceProfile profile)
        {
            SourceAvailability res = orig;
            if (profile.Auxiliaries == 0)
                res &= ~SourceAvailability.Auxilary;

            if (profile.MultiView == null || profile.MultiView.Count == 0)
                res &= SourceAvailability.Multiviewer;

            if (profile.SuperSource == 0)
                res &= ~(SourceAvailability.SuperSourceArt | SourceAvailability.SuperSourceBox);

            if (profile.UpstreamKeys == 0)
                res &= SourceAvailability.KeySource;

            return res;
        }

        public static IEnumerable<ExternalPortType> FilterVideoMode(this IEnumerable<ExternalPortType> orig, VideoMode mode)
        {
            if (mode.GetStandard() == VideoModeStandard.SDISD)
                return orig.OrderBy(p => p);

            return orig.Where(p => p != ExternalPortType.Composite && p != ExternalPortType.SVideo).OrderBy(p => p);
        }

        public static Tuple<string, string> GetDefaultName(this VideoSource src, DeviceProfile profile)
        {
            if (src == VideoSource.ME1Prog)
                return Tuple.Create(profile.MixEffectBlocks[0].ProgramLong, profile.MixEffectBlocks[0].ProgramShort);
            if (src == VideoSource.ME1Prev)
                return Tuple.Create(profile.MixEffectBlocks[0].PreviewLong, profile.MixEffectBlocks[0].PreviewShort);
            if (src == VideoSource.ME2Prog)
                return Tuple.Create(profile.MixEffectBlocks[1].ProgramLong, profile.MixEffectBlocks[1].ProgramShort);
            if (src == VideoSource.ME2Prev)
                return Tuple.Create(profile.MixEffectBlocks[1].PreviewLong, profile.MixEffectBlocks[1].PreviewShort);

            if (profile.MixEffectBlocks.Count > 1)
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
