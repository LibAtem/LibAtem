using System;

namespace LibAtem.Common
{
    [Flags]
    public enum TransitionLayer
    {
        None = 0,
        Background = 1 << 0,
        Key1 = 1 << 1,
        Key2 = 1 << 2,
        Key3 = 1 << 3,
        Key4 = 1 << 4,
    }
}