using System;

namespace LibAtem.Common
{
    [Flags]
    public enum SourceAvailability
    {
        None = 0,
        Auxilary = 1 << 0,
        Multiviewer = 1 << 1,
        SuperSourceArt = 1 << 2,
        SuperSourceBox = 1 << 3,
        KeySource = 1 << 4,
        All = Auxilary | Multiviewer | SuperSourceArt | SuperSourceBox | KeySource,
    }
}