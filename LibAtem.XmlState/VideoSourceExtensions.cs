using System;
using System.Linq;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.XmlState
{

    public static class VideoSourceLists
    {
        public static VideoSource[] All => Enum.GetValues(typeof(VideoSource)).OfType<VideoSource>().ToArray();

        public static VideoSource[] Inputs => All
            .Where(s =>s.GetPortType() == InternalPortType.External)
            .ToArray();

        public static VideoSource[] ColorGenerators => new[]
        {
            VideoSource.Color1,
            VideoSource.Color2,
        };

        public static VideoSource[] MediaPlayers => new[]
        {
            VideoSource.MediaPlayer1,
            VideoSource.MediaPlayer2,
            VideoSource.MediaPlayer3,
            VideoSource.MediaPlayer4,
        };

        public static VideoSource[] MediaPlayerKeys => new[]
        {
            VideoSource.MediaPlayer1Key,
            VideoSource.MediaPlayer2Key,
            VideoSource.MediaPlayer3Key,
            VideoSource.MediaPlayer4Key,
        };

        public static VideoSource[] UpstreamKeyMasks => new[]
        {
            VideoSource.Key1Mask,
            VideoSource.Key2Mask,
            VideoSource.Key3Mask,
            VideoSource.Key4Mask,
        };

        public static VideoSource[] DownstreamKeyMasks => new[]
        {
            VideoSource.DSK1Mask,
            VideoSource.DSK2Mask,
        };

        public static VideoSource[] MixEffectPrograms => new[]
        {
            VideoSource.ME1Prog,
            VideoSource.ME2Prog,
        };

        public static VideoSource[] MixEffectPreviews => new[]
        {
            VideoSource.ME1Prev,
            VideoSource.ME2Prev,
        };
    }

    public static class VideoSourceExtensions
    {
        public static InternalPortType GetPortType(this VideoSource src)
        {
            return src.GetAttribute<VideoSource, VideoSourceTypeAttribute>().PortType;
        }
    }
}
