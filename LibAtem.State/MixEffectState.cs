using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.State.Tolerance;

namespace LibAtem.State
{
    [Serializable]
    public class MixEffectState
    {
        public IReadOnlyList<KeyerState> Keyers { get; set; } = new List<KeyerState>();
        
        public TransitionState Transition { get; } = new TransitionState();
        public SourcesState Sources { get; } = new SourcesState();
        
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
            [Tolerance(0.01)]
            public double BorderWidth { get; set; }
            public VideoSource BorderInput { get; set; }
            [Tolerance(0.01)]
            public double Symmetry { get; set; }
            [Tolerance(0.01)]
            public double BorderSoftness { get; set; }
            [Tolerance(0.01)]
            public double XPosition { get; set; }
            [Tolerance(0.01)]
            public double YPosition { get; set; }
            public bool ReverseDirection { get; set; }
            public bool FlipFlop { get; set; }
        }

        [Serializable]
        public class TransitionStingerState
        {
            public StingerSource Source { get; set; }
            public bool PreMultipliedKey { get; set; }

            [Tolerance(0.01)]
            public double Clip { get; set; }
            [Tolerance(0.01)]
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
            [Tolerance(0.01)]
            public double Clip { get; set; }
            [Tolerance(0.01)]
            public double Gain { get; set; }
            public bool InvertKey { get; set; }
            public bool Reverse { get; set; }
            public bool FlipFlop { get; set; }
        }

        
        #endregion Transition
        
        #region Keyer
        
        [Serializable]
        public class KeyerState
        {
            public KeyerLumaState Luma { get; set; }
            public KeyerChromaState Chroma { get; set; }
            public KeyerPatternState Pattern { get; set; }
            public KeyerDVEState DVE { get; set; }
            public IReadOnlyList<KeyerFlyFrameState> FlyFrames { get; set; }

            public bool OnAir { get; set; }
            
            public KeyerPropertiesState Properties { get; } = new KeyerPropertiesState();
        }

        [Serializable]
        public class KeyerPropertiesState
        {
            public MixEffectKeyType Mode { get; set; }
            public bool FlyEnabled { get; set; }
            public VideoSource FillSource { get; set; }
            public VideoSource CutSource { get; set; }

            public bool MaskEnabled { get; set; }
            [Tolerance(0.01)]
            public double MaskTop { get; set; }
            [Tolerance(0.01)]
            public double MaskBottom { get; set; }
            [Tolerance(0.01)]
            public double MaskLeft { get; set; }
            [Tolerance(0.01)]
            public double MaskRight { get; set; }
        }
        
        [Serializable]
        public class KeyerLumaState
        {
            public bool PreMultiplied { get; set; }

            [Tolerance(0.01)]
            public double Clip { get; set; }
            [Tolerance(0.01)]
            public double Gain { get; set; }

            public bool Invert { get; set; }
        }

        [Serializable]
        public class KeyerChromaState
        {
            [Tolerance(0.01)]
            public double Hue { get; set; }
            [Tolerance(0.01)]
            public double Gain { get; set; }
            [Tolerance(0.01)]
            public double YSuppress { get; set; }
            [Tolerance(0.01)]
            public double Lift { get; set; }
            public bool Narrow { get; set; }
        }

        [Serializable]
        public class KeyerPatternState
        {
            public Pattern Style { get; set; }
            [Tolerance(0.01)]
            public double Size { get; set; }
            [Tolerance(0.01)]
            public double Symmetry { get; set; }
            [Tolerance(0.01)]
            public double Softness { get; set; }
            [Tolerance(0.01)]
            public double XPosition { get; set; }
            [Tolerance(0.01)]
            public double YPosition { get; set; }
            public bool Inverse { get; set; }
        }

        [Serializable]
        public class KeyerDVEState
        {
            [Tolerance(0.01)]
            public double SizeX { get; set; }
            [Tolerance(0.01)]
            public double SizeY { get; set; }
            [Tolerance(0.01)]
            public double PositionX { get; set; }
            [Tolerance(0.01)]
            public double PositionY { get; set; }
            [Tolerance(0.01)]
            public double Rotation { get; set; }
            
            public uint Rate { get; set; }
            
            public bool BorderEnabled { get; set; }
            public bool BorderShadowEnabled { get; set; }
            public BorderBevel BorderBevel { get; set; }
            [Tolerance(0.01)]
            public double BorderOuterWidth { get; set; }
            [Tolerance(0.01)]
            public double BorderInnerWidth { get; set; }
            public uint BorderOuterSoftness { get; set; }
            public uint BorderInnerSoftness { get; set; }
            public uint BorderBevelSoftness { get; set; }
            public uint BorderBevelPosition { get; set; }

            public uint BorderOpacity { get; set; }
            [Tolerance(0.01)]
            public double BorderHue { get; set; }
            [Tolerance(0.01)]
            public double BorderSaturation { get; set; }
            [Tolerance(0.01)]
            public double BorderLuma { get; set; }

            [Tolerance(0.01)]
            public double LightSourceDirection { get; set; }
            public uint LightSourceAltitude { get; set; }

            public bool MaskEnabled { get; set; }
            [Tolerance(0.01)]
            public double MaskTop { get; set; }
            [Tolerance(0.01)]
            public double MaskBottom { get; set; }
            [Tolerance(0.01)]
            public double MaskLeft { get; set; }
            [Tolerance(0.01)]
            public double MaskRight { get; set; }
        }
        
        [Serializable]
        public class KeyerFlyFrameState
        {
            [Tolerance(0.01)]
            public double SizeX { get; set; }
            [Tolerance(0.01)]
            public double SizeY { get; set; }
            [Tolerance(0.01)]
            public double PositionX { get; set; }
            [Tolerance(0.01)]
            public double PositionY { get; set; }
            [Tolerance(0.01)]
            public double Rotation { get; set; }

            [Tolerance(0.01)]
            public double OuterWidth { get; set; }
            [Tolerance(0.01)]
            public double InnerWidth { get; set; }
            [UintTolerance(1)]
            public uint OuterSoftness { get; set; }
            [UintTolerance(1)]
            public uint InnerSoftness { get; set; }
            [UintTolerance(1)]
            public uint BevelSoftness { get; set; }
            [UintTolerance(1)]
            public uint BevelPosition { get; set; }

            public uint BorderOpacity { get; set; }
            [Tolerance(0.01)]
            public double BorderHue { get; set; }
            [Tolerance(0.01)]
            public double BorderSaturation { get; set; }
            [Tolerance(0.01)]
            public double BorderLuma { get; set; }

            [Tolerance(0.01)]
            public double LightSourceDirection { get; set; }
            [UintTolerance(1)]
            public uint LightSourceAltitude { get; set; }

            [Tolerance(0.01)]
            public double MaskTop { get; set; }
            [Tolerance(0.01)]
            public double MaskBottom { get; set; }
            [Tolerance(0.01)]
            public double MaskLeft { get; set; }
            [Tolerance(0.01)]
            public double MaskRight { get; set; }
        }
        
        #endregion Keyer
        
    }
}