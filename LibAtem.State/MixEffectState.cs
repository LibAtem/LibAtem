using System;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class MixEffectState
    {
        public MixEffectState()
        {
            Sources = new SourcesState();
            Transition = new TransitionState();
        }
        
        // TODO Keyers
        
        public TransitionState Transition { get; }
        
        public SourcesState Sources { get; }
        
        [Serializable]
        public class SourcesState
        {
            public VideoSource Program { get; set; }
            public VideoSource Preview { get; set; }
        }
        
        #region Transition
        
        [Serializable]
        public class TransitionState
        {
            public TransitionPropertiesState Properties { get; } = new TransitionPropertiesState();
            
            public TransitionMixState Mix { get; set; }
            public TransitionDipState Dip { get; set; }
            public TransitionWipeState Wipe { get; set; }
            public TransitionStingerState Stinger { get; set; }
            public TransitionDVEState DVE { get; set; }
        }

        [Serializable]
        public class TransitionPropertiesState
        {
            public TStyle Style { get; set; }
            public TStyle NextStyle { get; set; }
            public TransitionLayer Selection { get; set; }
            public TransitionLayer NextSelection { get; set; }
        }

        [Serializable]
        public class TransitionMixState
        {
            public uint Rate { get; set; }
        }

        [Serializable]
        public class TransitionDipState
        {
            public VideoSource Input { get; set; }
            public uint Rate { get; set; }
        }
        
        [Serializable]
        public class TransitionWipeState
        {
            public uint Rate { get; set; }
            public Pattern Pattern { get; set; }
            public double BorderWidth { get; set; }
            public VideoSource BorderInput { get; set; }
            public double Symmetry { get; set; }
            public double BorderSoftness { get; set; }
            public double XPosition { get; set; }
            public double YPosition { get; set; }
            public bool ReverseDirection { get; set; }
            public bool FlipFlop { get; set; }
        }

        [Serializable]
        public class TransitionStingerState
        {
            public StingerSource Source { get; set; }
            public bool PreMultipliedKey { get; set; }

            public double Clip { get; set; }
            public double Gain { get; set; }
            public bool Invert { get; set; }

            public uint Preroll { get; set; }
            public uint ClipDuration { get; set; }
            public uint TriggerPoint { get; set; }
            public uint MixRate { get; set; }
        }

        [Serializable]
        public class TransitionDVEState
        {
            public uint Rate { get; set; }
            public uint LogoRate { get; set; }
            public DVEEffect Style { get; set; }

            public VideoSource FillSource { get; set; }
            public VideoSource KeySource { get; set; }

            public bool EnableKey { get; set; }
            public bool PreMultiplied { get; set; }
            public double Clip { get; set; }
            public double Gain { get; set; }
            public bool InvertKey { get; set; }
            public bool Reverse { get; set; }
            public bool FlipFlop { get; set; }
        }

        
        #endregion Transition
        
    }
}