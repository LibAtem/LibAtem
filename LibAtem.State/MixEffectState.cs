using System;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class MixEffectState
    {
        public MixEffectState()
        {
            Sources = new MixEffectSources();
        }
        
        // TODO Keyers
        // TODO Transition
        
        public MixEffectSources Sources { get; }
    }

    [Serializable]
    public class MixEffectSources
    {
        public VideoSource Program { get; set; }
        public VideoSource Preview { get; set; }
    }
}