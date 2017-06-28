using System;

namespace LibAtem.Util
{
    public static class MathExt
    {
        public static int NextPowerOf2(int v)
        {
            return (int)Math.Pow(2, Math.Ceiling(Math.Log(v) / Math.Log(2)));
        }
    }
}