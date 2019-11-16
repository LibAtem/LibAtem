using System;
using System.Collections.Generic;

namespace LibAtem.State.Builder
{
    internal static class UpdaterUtil
    {
        public static void TryForIndex<T>(UpdateResultImpl result, IReadOnlyList<T> arr, int index, Action<T> func)
        {
            var obj = arr[index];
            if (obj != null)
            {
                func(obj);
            }
            else
            {
                result.AddError($"Update for unknown {typeof(T).Name}: {index}");
            }
        }
        
    }
}