using System;
using System.Linq;
using LibAtem.Common;

namespace LibAtem.Util.Media
{
    public static class FrameEncodingUtil
    {
        public static byte[] DecodeRLE(VideoModeResolution size, byte[] data)
        {
            byte[] res = new byte[size.GetByteCount()];
            int p = 0;

            const int colBytes = 8;

            for (int i = 0; i < data.Length; i += 8)
            {
                // Ensure it looks correct
                if (!IsTerminator(data, i))
                {
                    Array.Copy(data, i, res, p, colBytes);
                    p += colBytes;
                    continue;
                }

                long count = BitConverter.ToInt64(data.Skip(i + 8).Take(8).Reverse().ToArray(), 0);
                i += 16;
                if (count == 0)
                    continue;

                // Find the pixels to repeat
                for (int o = 0; o < count; o++)
                {
                    Array.Copy(data, i, res, p, colBytes);
                    p += colBytes;
                }
            }

            return res;
        }

        private static bool IsTerminator(byte[] data, int i)
        {
            if (i >= data.Length)
                return true;

            return data[i] == 0xfe &&
                   data[i + 1] == 0xfe &&
                   data[i + 2] == 0xfe &&
                   data[i + 3] == 0xfe &&
                   data[i + 4] == 0xfe &&
                   data[i + 5] == 0xfe &&
                   data[i + 6] == 0xfe &&
                   data[i + 7] == 0xfe;
        }
    }
}