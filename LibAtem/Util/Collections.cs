using System;
using System.Collections.Generic;

namespace LibAtem.Util
{
    public static class Collections
    {
        public static IEnumerable<T> Repeat<T>(Func<uint, T> func, uint count)
        {
            for (uint i = 0; i < count; i++)
                yield return func(i);
        }
    }
}