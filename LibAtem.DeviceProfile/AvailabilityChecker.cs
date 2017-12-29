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
            if (val is TStyle)
                return IsAvailable((TStyle)val, profile);
            if (val is TransitionLayer)
                return IsAvailable((TransitionLayer)val, profile);

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
                case InternalPortType.Auxiliary:
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
            return src.IsValid() && (int) src < profile.MediaPlayers + 1;
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

        public static bool IsAvailable(this VideoMode mode, DeviceProfile profile)
        {
            return profile.GetStandards().Contains(mode.GetStandard());
        }

        public static bool IsAvailable(this TStyle style, DeviceProfile profile)
        {
            if (!style.IsValid())
                return false;

            switch (style)
            {
                case TStyle.Mix:
                    return true;
                case TStyle.Dip:
                    return true;
                case TStyle.Wipe:
                    return true;
                case TStyle.DVE:
                    return profile.DVE > 0;
                case TStyle.Stinger:
                    return profile.Stingers > 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(style), style, null);
            }
        }

        public static bool IsAvailable(this TransitionLayer layer, DeviceProfile profile)
        {
            if (!layer.IsValid())
                return false;

            List<UpstreamKeyId> unavailableKeyers = Enum.GetValues(typeof(UpstreamKeyId)).OfType<UpstreamKeyId>().Where(i => !i.IsAvailable(profile)).ToList();

            return !unavailableKeyers.Any(k => layer.HasKeyEnabled(k));
        }
    }
}
