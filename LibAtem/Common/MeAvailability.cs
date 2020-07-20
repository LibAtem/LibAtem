using System;

namespace LibAtem.Common
{
    [Flags]
    public enum MeAvailability
    {
        None = 0,
        Me1 = 1 << 0,
        Me2 = 1 << 1,
        Me3 = 1 << 2,
        Me4 = 1 << 3,
        All = Me1 | Me2 | Me3 | Me4,
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
                case MixEffectBlockId.Three:
                    return me.HasFlag(MeAvailability.Me3);
                case MixEffectBlockId.Four:
                    return me.HasFlag(MeAvailability.Me4);
                default:
                    return false;
            }
        }
    }
}