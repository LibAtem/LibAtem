using System;

namespace LibAtem.Common
{
    [Flags]
    public enum SourceAvailability
    {
        None = 0,
        Auxiliary = 1 << 0,
        Multiviewer = 1 << 1,
        SuperSourceArt = 1 << 2,
        SuperSourceBox = 1 << 3,
        KeySource = 1 << 4,
        Aux1Output = 1 << 5,
        Aux2Output = 1 << 6,
        WebcamOutput = 1 << 7,
        All = Auxiliary | Multiviewer | SuperSourceArt | SuperSourceBox | KeySource | Aux1Output | Aux2Output | WebcamOutput,
    }
}
