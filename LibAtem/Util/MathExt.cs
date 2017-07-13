using System;

namespace LibAtem.Util
{
    public static class MathExt
    {
        public static int NextPowerOf2(int v)
        {
            return (int)Math.Pow(2, Math.Ceiling(Math.Log(v) / Math.Log(2)));
        }

        public static int NextMultipleOf4(int v)
        {
            if (v % 4 == 0)
                return v;

            return (int) ((Math.Floor((double) v / 4) + 1) * 4);
        }
    }
}