using System;
using System.Linq;

namespace LibAtem.Util
{
    public static class StringExtenstions 
    {
        public static byte[] HexToByteArray(this string hex)
        {
            hex = hex.Replace("-", "");
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}