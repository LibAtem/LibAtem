using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Common;

namespace LibAtem.Util.Media
{
    public static class FrameEncodingUtil
    {
        private const int BlockSize = 8;
        public static byte[] EncodeRLE(byte[] data)
        {
            if (data.Length % 8 != 0)
                return data;
            
            var res = new byte[data.Length];
            int used = 0;

            for (int i = 0; i < data.Length; )
            {
                int r = CountRun(data, i);
                if (r == 0)
                    break;

                if (r <= 2)
                {
                    for (int o = 0; o < r; o++)
                    {
                        Array.Copy(data, i, res, used, BlockSize);
                        used += BlockSize;
                    }

                    i += r * BlockSize;
                    continue;
                }

                AddRLEHeader(res, used, r);
                used += 16;

                Array.Copy(data, i, res, used, BlockSize);
                used += BlockSize;
                i += r * BlockSize;
            }

            var trimmed = new byte[used];
            Array.Copy(res, trimmed, used);
            return trimmed;
        }

        private static void AddRLEHeader(byte[] res, int pos, long count)
        {
            for (int i = 0; i < 8; i++)
                res[pos + i] = 0xfe;

            byte[] size = BitConverter.GetBytes(count).Reverse().ToArray();
            Array.Copy(size, 0, res, pos + 8, 8);
        }

        // TODO - this is really slow, taking 64ms per frame (39ms in AreBlocksEqual)
        private static int CountRun(byte[] data, int pos)
        {
            int i = 1;
            while (pos + BlockSize * i < data.Length && AreBlocksEqual(data, pos, pos + BlockSize * i))
            {
                i++;
            }

            return i;
        }
        
        private static bool AreBlocksEqual(byte[] data, int pos1, int pos2)
        {
            for (int i = 0; i < BlockSize; i++)
            {
                if (data[pos1 + i] != data[pos2 + i])
                    return false;
            }

            return true;
        }

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