using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.Util
{
    public static class Collections
    {
        public static IEnumerable<T> Repeat<T>(Func<uint, T> func, uint count)
        {
            for (uint i = 0; i < count; i++)
                yield return func(i);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng = null)
        {
            if (rng == null)
                rng = new Random((int) DateTime.Now.Ticks);

            T[] elements = source.ToArray();
            // Note i > 0 to avoid final pointless iteration
            for (int i = elements.Length - 1; i > 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
                // we don't actually perform the swap, we can forget about the
                // swapped element because we already returned it.
            }

            // there is one item remaining that was not returned - we return it now
            yield return elements[0];
        }
    }
}