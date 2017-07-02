using LibAtem.Common;
using LibAtem.Util;

namespace AtemEmulator.State
{
    public static class AudioSourceExtensions
    {
        public static bool IsAvailable(this AudioSource src, DeviceProfile profile)
        {
            if (!src.IsValid())
                return false;

            VideoSource? videoSrc = src.GetVideoSource();
            if (videoSrc == null)
                return false;

            return videoSrc.Value.IsAvailable(profile);
        }
    }
}