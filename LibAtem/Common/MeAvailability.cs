using System;

namespace LibAtem.Common
{
    [Flags]
    public enum MeAvailability
    {
        None = 0,
        Me1 = 1,
        Me2 = 2,
        All = Me1 | Me2,
    }
}