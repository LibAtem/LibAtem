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

        public FadeToBlackState FadeToBlack { get; } = new FadeToBlackState();

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
            public TransitionPositionState Position { get; } = new TransitionPositionState();

            public TransitionMixState Mix { get; set; }
            public TransitionDipState Dip { get; set; }
            public TransitionWipeState Wipe { get; set; }
            public TransitionStingerState Stinger { get; set; }
            public TransitionDVEState DVE { get; set; }
        }

        [Serializable]
        public class TransitionPropertiesState
        {
            public TransitionStyle Style { get; set; }
            public TransitionStyle NextStyle { get; set; }
            public TransitionLayer Selection { get; set; }
            public TransitionLayer NextSelection { get; set; }

            public bool PreviewTransition { get; set; }
        }

        [Serializable]
        public class TransitionPositionState
        {
            public bool InTransition { get; set; }
            public uint RemainingFrames { get; set; }
            public double HandlePosition { get; set; }
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
            public KeyerAdvancedChromaState AdvancedChroma { get; set; }
            public KeyerPatternState Pattern { get; set; }
            public KeyerDVEState DVE { get; set; }
            public IReadOnlyList<KeyerFlyFrameState> FlyFrames { get; set; }

            public bool OnAir { get; set; }
            
            public KeyerPropertiesState Properties { get; } = new KeyerPropertiesState();

            public KeyerFlyProperties FlyProperties { get; set; }
        }

        [Serializable]
        public class KeyerPropertiesState
        {
            public MixEffectKeyType KeyType { get; set; }
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

            public bool CanFlyKey { get; set; }
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
        public class KeyerAdvancedChromaState
        {
            public KeyerAdvancedChromaSampleState Sample { get; } = new KeyerAdvancedChromaSampleState();
            public KeyerAdvancedChromaPropertiesState Properties { get; } = new KeyerAdvancedChromaPropertiesState();
        }

        [Serializable]
        public class KeyerAdvancedChromaSampleState
        {
            public bool EnableCursor { get; set; }
            public bool Preview { get; set; }
            [Tolerance(0.001)]
            public double CursorX { get; set; }
            [Tolerance(0.001)]
            public double CursorY { get; set; }
            [Tolerance(0.01)]
            public double CursorSize { get; set; }

            [Tolerance(0.0001)]
            public double SampledY { get; set; }
            [Tolerance(0.0001)]
            public double SampledCb { get; set; }
            [Tolerance(0.0001)]
            public double SampledCr { get; set; }
        }

        [Serializable]
        public class KeyerAdvancedChromaPropertiesState
        {
            [Tolerance(0.1)]
            public double ForegroundLevel { get; set; }
            [Tolerance(0.1)]
            public double BackgroundLevel { get; set; }
            [Tolerance(0.1)]
            public double KeyEdge { get; set; }

            [Tolerance(0.1)]
            public double SpillSuppression { get; set; }
            [Tolerance(0.1)]
            public double FlareSuppression { get; set; }

            [Tolerance(0.1)]
            public double Brightness { get; set; }
            [Tolerance(0.1)]
            public double Contrast { get; set; }
            [Tolerance(0.1)]
            public double Saturation { get; set; }
            [Tolerance(0.1)]
            public double Red { get; set; }
            [Tolerance(0.1)]
            public double Green { get; set; }
            [Tolerance(0.1)]
            public double Blue { get; set; }
        }

        [Serializable]
        public class KeyerPatternState
        {
            public Pattern Pattern { get; set; }
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
            // public bool CanScaleUp { get; set; }
            // public bool CanRotate { get; set; }

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
        public class KeyerFlyProperties
        {
            public bool IsASet { get; set; }
            public bool IsBSet { get; set; }

            public FlyKeyKeyFrameType RunningToKeyFrame { get; set; }
            public FlyKeyLocation RunningToInfinite { get; set; }
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

        #region FadeToBlack

        [Serializable]
        public class FadeToBlackState
        {
            public FadeToBlackStatusState Status { get; } = new FadeToBlackStatusState();
            public FadeToBlackPropertiesState Properties { get; } = new FadeToBlackPropertiesState();
        }

        [Serializable]
        public class FadeToBlackPropertiesState
        {
            public uint Rate { get; set; }
        }

        [Serializable]
        public class FadeToBlackStatusState
        {
            public bool IsFullyBlack { get; set; }
            public bool InTransition { get; set; }
            public uint RemainingFrames { get; set; }
        }

        #endregion FadeToBlack

    }
}