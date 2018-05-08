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

        public static (int y, int cb, int cr) ToYCbCr10(byte r, byte g, byte b)
        {
            (int y1, int _, int cb, int cr) = ToYCbCr10Bit422(r, g, b);
            return (y1, cb, cr);
        }

        public static byte[] RGBAToYCbCrA10Bit422(byte[] data)
        {
            var res = new byte[data.Length];
            for (int i = 0; i <= data.Length-8; i += 8)
            {
                (int y1, int y2, int cb, int cr) = ToYCbCr10Bit422(data[i], data[i + 1], data[i + 2], data[i + 4], data[i + 5], data[i + 6]);
                int a1a = ToA10(data[i + 3]);
                int a2a = ToA10(data[i + 7]);

                res[i] = (byte) (a1a >> 4);
                res[i + 1] = (byte) (((a1a & 0x0f) << 4) | (cb >> 6));
                res[i + 2] = (byte) (((cb & 0x3f) << 2) | (y1 >> 8));
                res[i + 3] = res[i] = (byte) (y1 & 0xff);
                res[i + 4] = (byte) (a2a >> 4);
                res[i + 5] = (byte) (((a2a & 0x0f) << 4) | (cr >> 6));
                res[i + 6] = (byte) (((cr & 0x3f) << 2) | (y2 >> 8));
                res[i + 7] = (byte) (y2 & 0xff);
            }

            return res;
        }

        public static (int y1, int y2, int cb, int cr) ToYCbCr10Bit422(byte r1, byte g1, byte b1, byte? r2 = null, byte? g2 = null, byte? b2 = null)
        {
            double y16a = YOffset + KR * YRange * r1 + KG * YRange * g1 + KB * YRange * b1;
            double cb16 = CbCrOffset + (-KRoKBi * r1 - KGoKBi * g1 + HalfCbCrRange * b1);
            double cr16 = CbCrOffset + (HalfCbCrRange * r1 - KGoKRi * g1 - KBoKRi * b1);

            int y10a = (int)Math.Round(y16a) >> 6;
            int cb10 = (int)Math.Round(cb16) >> 6;
            int cr10 = (int)Math.Round(cr16) >> 6;

            int y10b = 0;
            if (r2.HasValue && g2.HasValue && b2.HasValue)
            {
                double y16b = YOffset + KR * YRange * r2.Value + KG * YRange * g2.Value + KB * YRange * b2.Value;
                y10b = (int)Math.Round(y16b) >> 6;
            }

            return (y10a, y10b, cb10, cr10);
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
