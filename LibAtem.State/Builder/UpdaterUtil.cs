using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LibAtem.State.Builder
{
    internal static class UpdaterUtil
    {
        public static void TryForIndex<T>(UpdateResultImpl result, IReadOnlyList<T> arr, int index, Action<T> func)
        {
            T obj = arr.ElementAtOrDefault(index);
            if (obj != null)
            {
                func(obj);
            }
            else
            {
                result.AddError($"Update for unknown {typeof(T).Name}: {index}");
            }
        }
        public static void TryForKey<TK, TV>(UpdateResultImpl result, IDictionary<TK, TV> dict, TK key, Action<TV> func)
        {
            if (dict.TryGetValue(key, out TV obj))
            {
                func(obj);
            }
            else
            {
                result.AddError($"Update for unknown {typeof(TV).Name}: {key}");
            }
        }

        public static IReadOnlyList<T> CreateList<T>(uint count, Func<int, T> func)
        {
            return Enumerable.Range(0, (int) count).Select(func).ToList();
        }
        
        public static void CopyAllProperties<TSrc, TDest>(TSrc src, TDest dest, IEnumerable<string> skipSrc = null, IEnumerable<string> ignoreDest = null)
        {
            Dictionary<string, PropertyInfo> srcPropMap = typeof(TSrc).GetProperties().Where(p => skipSrc == null || !skipSrc.Contains(p.Name)).ToDictionary(p => p.Name);
            Dictionary<string, PropertyInfo> destPropMap = typeof(TDest).GetProperties().Where(p => ignoreDest == null || !ignoreDest.Contains(p.Name)).ToDictionary(p => p.Name);
            
            // Do the copy and and ensure types are good
            foreach (KeyValuePair<string, PropertyInfo> srcProp in srcPropMap)
            {
                if (!destPropMap.TryGetValue(srcProp.Key, out PropertyInfo destProp) || destProp.PropertyType != srcProp.Value.PropertyType)
                {
#if DEBUG
                    throw new Exception($"Property {typeof(TSrc).Name}.{srcProp.Key} mismatch in {typeof(TDest).Name}");
#endif // DEBUG
                }
                else
                {
                    // Now set it
                    destProp.SetValue(dest, srcProp.Value.GetValue(src));
                }
            }
            
#if DEBUG
            // Ensure all the dest properties are accounted for
            foreach (KeyValuePair<string, PropertyInfo> destProp in destPropMap)
            {
                if (!srcPropMap.ContainsKey(destProp.Key))
                {
                    throw new Exception($"Property {typeof(TDest).Name}.{destProp.Key} missing in {typeof(TSrc).Name}");
                }
            }
#endif // DEBUG
        }
    }
}