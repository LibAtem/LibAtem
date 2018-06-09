using System;
using System.Linq;
using LibAtem.Common;

namespace LibAtem.Util.Media
{
    public static class FrameEncodingUtil
    {
        private const int BlockSize = 8;
        
        public static unsafe byte[] EncodeRLEUnsafe2(ulong[] data)
        {
            var res = new byte[data.Length* BlockSize];
            int used = 0;

            int len = data.Length;

            fixed (ulong* pData = data)
            fixed (byte* pRes = res)
            {

                for (int i = 0; i < len;)
                {
                    int r = CountRun(pData, i, len);
                    if (r == 0)
                        break;

                    if (r <= 2)
                    {
                        for (int o = 0; o < r; o++)
                        {
                            Copy(pData, i, pRes, used, 1);
                            used += BlockSize;
                        }

                        i += r;
                        continue;
                    }

                    AddRLEHeader2(pRes, used, r);
                    used += 16;

                    Copy(pData, i, pRes, used, 1);
                    used += BlockSize;
                    i += r;
                }
            }

            var trimmed = new byte[used];
            Array.Copy(res, trimmed, used);
            return trimmed;
        }

        private static unsafe void AddRLEHeader2(byte* res, int pos, long count)
        {
            ((ulong*) res)[pos] = 0xfefefefefefefefe;

            byte[] size = BitConverter.GetBytes(count).Reverse().ToArray();
            fixed (byte* pSize = size)
                Copy(pSize, 0, res, pos + 8, 8);
        }

        // TODO - this is really slow, taking 64ms per frame (39ms in AreBlocksEqual)
        private static unsafe int CountRun(ulong* data, int pos, int length)
        {
            int i = 1;
            while (pos + BlockSize * i < length && data[pos] == data[pos + 1])
                i++;

            return i;
        }

        public static unsafe void Copy(ulong* src, int srcPos, byte* dest, int destPos, int blockCount)
        {
            // Copy the specified number of bytes from source to target.
            var src2 = (byte*) src;
            for (int o = 0; o < blockCount; o++)
            {
                for (int i = 0; i < BlockSize; i++)
                    dest[destPos + (o * 8) + i] = src2[(srcPos + o) * 8 + (BlockSize - 1 - i)];
            }
        }

        public static unsafe byte[] ToByteArray(ulong[] data)
        {
            var res = new byte[data.Length * 8];

            fixed (ulong* pData = data)
            fixed (byte* pRes = res)
            {
                Copy(pData, 0, pRes, 0, data.Length);
            }

            return res;
        }



        public static unsafe byte[] EncodeRLEUnsafe(byte[] data)
        {
            if (data.Length % 8 != 0)
                return data;

            var res = new byte[data.Length];
            int used = 0;

            int len = data.Length;

            fixed (byte* pData = data, pRes = res)
            {

                for (int i = 0; i < len;)
                {
                    int r = CountRun(pData, i, len);
                    if (r == 0)
                        break;

                    if (r <= 2)
                    {
                        for (int o = 0; o < r; o++)
                        {
                            Copy(pData, i, pRes, used, BlockSize);
                            used += BlockSize;
                        }

                        i += r * BlockSize;
                        continue;
                    }

                    AddRLEHeader(pRes, used, r);
                    used += 16;

                    Copy(pData, i, pRes, used, BlockSize);
                    used += BlockSize;
                    i += r * BlockSize;
                }
            }

            var trimmed = new byte[used];
            Array.Copy(res, trimmed, used);
            return trimmed;
        }

        private static unsafe void Copy(byte* src, int srcPos, byte* dest, int destPos, int len)
        {
            // Copy the specified number of bytes from source to target.
            for (int i = 0; i < len; i++)
                dest[destPos + i] = src[srcPos + i];
        }

        private static unsafe void AddRLEHeader(byte* res, int pos, long count)
        {
            for (int i = 0; i < 8; i++)
                res[pos + i] = 0xfe;

            byte[] size = BitConverter.GetBytes(count).Reverse().ToArray();
            fixed (byte* pSize = size)
                Copy(pSize, 0, res, pos + 8, 8);
        }

        // TODO - this is really slow, taking 64ms per frame (39ms in AreBlocksEqual)
        private static unsafe int CountRun(byte* data, int pos, int length)
        {
            var longData = (ulong*)data;
            var longPos = pos / BlockSize;
            var longLen = length / BlockSize;

            int i = 1;
            while (longPos+ i < longLen && longData[longPos] == longData[longPos+i])
                i++;

            return i;
        }

        private static unsafe bool AreBlocksEqual(long* data, int pos1, int pos2)
        {
            return data[pos1] == data[pos2];
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