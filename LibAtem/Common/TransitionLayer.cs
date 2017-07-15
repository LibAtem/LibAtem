using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Util;

namespace LibAtem.Common
{
    [Flags]
    public enum TransitionLayer
    {
        None = 0,
        Background = 1 << 0,

        [KeyIndex(0)]
        Key1 = 1 << 1,
        [KeyIndex(1)]
        Key2 = 1 << 2,
        [KeyIndex(2)]
        Key3 = 1 << 3,
        [KeyIndex(3)]
        Key4 = 1 << 4,
    }

    public class KeyIndexAttribute : Attribute
    {
        public uint Index { get; }

        public KeyIndexAttribute(uint index)
        {
            Index = index;
        }
    }

    public static class TransitionLayerExtensions{
        public static bool HasKeyEnabled(this TransitionLayer trans, uint index)
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

        public static TransitionLayer ToTransitionLayerKey(this uint index)
        {
            IEnumerable<TransitionLayer> values = Enum.GetValues(typeof(TransitionLayer)).OfType<TransitionLayer>();
            foreach (TransitionLayer val in values)
            {
                KeyIndexAttribute attr = val.GetPossibleAttribute<TransitionLayer, KeyIndexAttribute>();
                if (attr != null && attr.Index == index)
                    return val;
            }

            return TransitionLayer.None;
        }
    }
}