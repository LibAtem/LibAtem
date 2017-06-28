using System;

namespace LibAtem.Util
{
    public static class EnumExtensions
    {
        public static bool IsValid<T>(this T src)
        {
            return Enum.IsDefined(typeof(T), src);
        }
    }
}
