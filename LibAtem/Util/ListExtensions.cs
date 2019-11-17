using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.Util
{
    public static class ListExtensions
    {
        public static void AddIfNotNull<T>(this List<T> list, T obj)
        {
            if (obj == null)
                return;

            list.Add(obj);
        }

        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> e)
        {
            return e.Where(o => o != null);
        }

        public static void AddRange<T>(this ICollection<T> col, IEnumerable<T> objs)
        {
            objs.ForEach(col.Add);
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> func)
        {
            foreach (T elm in list)
                func(elm);
        }
        public static void ForEach<T>(this IReadOnlyList<T> list, Action<int, T> func)
        {
            for (int i = 0; i < list.Count; i++)
                func(i, list[i]);
        }

        public static void SetToLength<T>(this List<T> list, uint target, Func<int, T> generator)
        {
            while (generator != null && list.Count < target)
                list.Add(generator(list.Count));
            if (list.Count > target)
                list.RemoveRange((int) target, (int) (list.Count - target));
        }
    }
}
