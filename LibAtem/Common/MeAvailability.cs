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

    public static class MeAvailabilityExtensions
    {
        public static bool Includes(this MeAvailability me, MixEffectBlockId id)
        {
            switch (id)
            {
                case MixEffectBlockId.One:
                    return me.HasFlag(MeAvailability.Me1);
                case MixEffectBlockId.Two:
                    return me.HasFlag(MeAvailability.Me2);
                default:
                    return false;
            }
        }
    }
}