using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Util;

namespace LibAtem.Common
{
    [Flags]
    public enum TransitionLayer
    {
        Background = 1 << 0,

        [KeyIndex(UpstreamKeyId.One)]
        Key1 = 1 << 1,
        [KeyIndex(UpstreamKeyId.Two)]
        Key2 = 1 << 2,
        [KeyIndex(UpstreamKeyId.Three)]
        Key3 = 1 << 3,
        [KeyIndex(UpstreamKeyId.Four)]
        Key4 = 1 << 4,
    }

    public class KeyIndexAttribute : Attribute
    {
        public UpstreamKeyId Index { get; }

        public KeyIndexAttribute(UpstreamKeyId index)
        {
            Index = index;
        }
    }

    public static class TransitionLayerExtensions{
        public static bool HasKeyEnabled(this TransitionLayer trans, UpstreamKeyId index)
        {
            IEnumerable<TransitionLayer> values = Enum.GetValues(typeof(TransitionLayer)).OfType<TransitionLayer>();
            foreach (TransitionLayer val in values)
            {
                if (!trans.HasFlag(val))
                    continue;

                KeyIndexAttribute attr = val.GetPossibleAttribute<TransitionLayer, KeyIndexAttribute>();
                if (attr != null && attr.Index == index)
                    return true;
            }

            return false;
        }

        public static TransitionLayer ToTransitionLayerKey(this UpstreamKeyId index)
        {
            IEnumerable<TransitionLayer> values = Enum.GetValues(typeof(TransitionLayer)).OfType<TransitionLayer>();
            foreach (TransitionLayer val in values)
            {
                KeyIndexAttribute attr = val.GetPossibleAttribute<TransitionLayer, KeyIndexAttribute>();
                if (attr != null && attr.Index == index)
                    return val;
            }

            return 0;
        }
    }
}