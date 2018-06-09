using System;

namespace LibAtem.Util.Media
{
    public static class BT709ColourSpaceConverter
    {
        // Bt.601
        // const double KR = 0.299;
        // const double KB = 0.114;
        // Bt.709
        const double KR = 0.2126;
        const double KB = 0.0722;
        const double KG = 1 - KR - KB;

        const double KRi = 1 - KR;
        const double KBi = 1 - KB;

        const double KBG = KB / KG;
        const double KRG = KR / KG;

        const int YRange = 219;
        const int CbCrRange = 224;
        private const int HalfCbCrRange = CbCrRange / 2;

        private const int YOffset = 16 << 8;
        private const int CbCrOffset = 128 << 8;

        private const double KRoKBi = KR / KBi * HalfCbCrRange;
        private const double KGoKBi = KG / KBi * HalfCbCrRange;
        private const double KBoKRi = KB / KRi * HalfCbCrRange;
        private const double KGoKRi = KG / KRi * HalfCbCrRange;

        private const double KBiRange = KBi / HalfCbCrRange;
        private const double KRiRange = KRi / HalfCbCrRange;

        public static int ToA10(byte a)
        {
            return ((a << 2) * 219 / 255) + (16 << 2);
        }
        
        // TODO - tidy up these consts
        private const int Scale3 = 1 << 14;

        const int KRy3 = (int)(KR * YRange * Scale3 + 0.5);
        const int KGy3 = (int)(KG * YRange * Scale3 + 0.5);
        const int KBy3 = (int)(KB * YRange * Scale3 + 0.5);

        private const int KRoKBi3 = (int)(KRoKBi * Scale3 + 0.5);
        private const int KGoKBi3 = (int)(KGoKBi * Scale3 + 0.5);
        private const int KGoKRi3 = (int)(KGoKRi * Scale3 + 0.5);
        private const int KBoKRi3 = (int)(KBoKRi * Scale3 + 0.5);

        // Note: This is a little less accurate than doing the conversion with doubles, but it is much more efficient
        public static ulong RGBAToYCbCrA10Bit422(byte[] data, int o)
        {
            int y1 = (YOffset * Scale3 + KRy3 * data[o] + KGy3 * data[o + 1] + KBy3 * data[o + 2]) >> 20;
            int y2 = (YOffset * Scale3 + KRy3 * data[o + 4] + KGy3 * data[o + 5] + KBy3 * data[o + 6]) >> 20;
            int cb = (CbCrOffset * Scale3 + (-KRoKBi3 * data[o] - KGoKBi3 * data[o + 1] + HalfCbCrRange * Scale3 * data[o + 2])) >> 20;
            int cr = (CbCrOffset * Scale3 + (HalfCbCrRange * Scale3 * data[o] - KGoKRi3 * data[o + 1] - KBoKRi3 * data[o + 2])) >> 20;

            int a1a = ToA10(data[o + 3]);
            int a2a = ToA10(data[o + 7]);

            // TODO ensure endianness

            ulong val = (ulong) y2;
            val |= (ulong) cr << 10;
            val |= (ulong) a2a << 20;
            val |= (ulong) y1 << 32;
            val |= (ulong) cb << 42;
            val |= (ulong) a1a << 52;

            return val;
        }

        // TODO - this is way too slow at 50ms-100ms (25%) slower than Safe2
        public static unsafe byte[] RGBAToYCbCrA10Bit422Safe4(byte[] data)
        {
            var res = new byte[data.Length];

            fixed (byte* pRes = res)
            {
                var len = data.Length / 8;
                for (int i = 0; i < len; i++)
                {
                    ulong val = RGBAToYCbCrA10Bit422(data, i * 8);
                    FrameEncodingUtil.Copy(&val, 0, pRes, i * 8, 1);
                }
            }

            return res;
        }

        public static ulong[] RGBAToYCbCrA10Bit422Safe2(byte[] data)
        {
            var len = data.Length / 8;
            var res = new ulong[len];

            for (int i = 0; i < len; i++)
            {
                res[i] = RGBAToYCbCrA10Bit422(data, i * 8);
            }

            return res;
        }

        public static byte[] ToRGBA8(byte[] data)
        {
            var res = new byte[data.Length];
            for (int i = 0; i <= data.Length - 8; i += 8)
            {
                int a1 = (data[i] << 4) + ((data[i + 1] & 0xf0) >> 4);
                int a2 = (data[i + 4] << 4) + ((data[i + 5] & 0xf0) >> 4);
                int cb = ((data[i + 1] & 0x0f) << 6) + ((data[i + 2] & 0xfc) >> 2);
                int y1 = ((data[i + 2] & 0x03) << 8) + (data[i + 3]);
                int cr = ((data[i + 5] & 0x0f) << 6) + ((data[i + 6] & 0xfc) >> 2);
                int y2 = ((data[i + 6] & 0x03) << 8) + (data[i + 7]);

                byte a1a = ToA8(a1);
                byte a2a = ToA8(a2);
                (byte r1, byte g1, byte b1) = ToRGB8(y1, cb, cr);
                (byte r2, byte g2, byte b2) = ToRGB8(y2, cb, cr);

                res[i] = r1;
                res[i + 1] = g1;
                res[i + 2] = b1;
                res[i + 3] = a1a;
                res[i + 4] = r2;
                res[i + 5] = g2;
                res[i + 6] = b2;
                res[i + 7] = a2a;
            }

            return res;
        }

        public static (byte r1, byte g1, byte b1) ToRGB8(int y10, int cb10, int cr10)
        {
            double cb1 = KBiRange * ((cb10 << 6) - CbCrOffset);
            double cr1 = KRiRange * ((cr10 << 6) - CbCrOffset);

            double y1 = ((double)(y10 << 6) - YOffset) / YRange;
            byte r1 = Clamp((int)Math.Round(y1 + cr1));
            byte g1 = Clamp((int)Math.Round(y1 - cb1 * KBG - cr1 * KRG));
            byte b1 = Clamp((int)Math.Round(y1 + cb1));

            return (r1, g1, b1);
        }

        public static byte ToA8(int a)
        {
            return Clamp((a - 16 << 2) * 255 / (YRange >> 2)); // TODO - use more consts
        }

        private static byte Clamp(int v)
        {
            if (v < 0)
                return 0;
            if (v > 255)
                return 255;
            return (byte)v;
        }
    }
}
