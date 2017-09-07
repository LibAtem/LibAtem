using System;
using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState
{
    public class MacroOperation
    {
        [XmlAttribute("id")]
        public MacroOperationType Id
        {
            get;
            set;
        }

        [XmlAttribute("auxiliaryIndex")]
        public uint AuxiliaryIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeAuxiliaryIndex()
        {
            switch (Id)
            {
                case MacroOperationType.AuxiliaryInput:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("mixEffectBlockIndex")]
        public MixEffectBlockId MixEffectBlockIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeMixEffectBlockIndex()
        {
            switch (Id)
            {
                case MacroOperationType.ProgramInput:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.CutTransition:
                case MacroOperationType.AutoTransition:
                case MacroOperationType.FadeToBlackAuto:
                case MacroOperationType.TransitionStyle:
                case MacroOperationType.TransitionSource:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionWipeRate:
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.DVEKeyShadowAltitude:
                case MacroOperationType.DVEKeyShadowDirection:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyBorderBevel:
                case MacroOperationType.DVEKeyBorderBevelPosition:
                case MacroOperationType.DVEKeyBorderBevelSoftness:
                case MacroOperationType.DVEKeyBorderHue:
                case MacroOperationType.DVEKeyBorderInnerSoftness:
                case MacroOperationType.DVEKeyBorderInnerWidth:
                case MacroOperationType.DVEKeyBorderLuminescence:
                case MacroOperationType.DVEKeyBorderOpacity:
                case MacroOperationType.DVEKeyBorderOuterSoftness:
                case MacroOperationType.DVEKeyBorderOuterWidth:
                case MacroOperationType.DVEKeyBorderSaturation:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.KeyType:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.LumaKeyPreMultiply:
                case MacroOperationType.KeyFlyEnable:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("hyperDeckIndex")]
        public int HyperDeckIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeHyperDeckIndex()
        {
            switch (Id)
            {
                case MacroOperationType.HyperDeckSetSourceClipIndex:
                case MacroOperationType.HyperDeckSetLoop:
                case MacroOperationType.HyperDeckSetSingleClip:
                case MacroOperationType.HyperDeckSetSpeed:
                case MacroOperationType.HyperDeckPlay:
                case MacroOperationType.HyperDeckStop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("keyIndex")]
        public uint KeyIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeKeyIndex()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.DVEKeyShadowAltitude:
                case MacroOperationType.DVEKeyShadowDirection:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyBorderBevel:
                case MacroOperationType.DVEKeyBorderBevelPosition:
                case MacroOperationType.DVEKeyBorderBevelSoftness:
                case MacroOperationType.DVEKeyBorderHue:
                case MacroOperationType.DVEKeyBorderInnerSoftness:
                case MacroOperationType.DVEKeyBorderInnerWidth:
                case MacroOperationType.DVEKeyBorderLuminescence:
                case MacroOperationType.DVEKeyBorderOpacity:
                case MacroOperationType.DVEKeyBorderOuterSoftness:
                case MacroOperationType.DVEKeyBorderOuterWidth:
                case MacroOperationType.DVEKeyBorderSaturation:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DownstreamKeyOnAir:
                case MacroOperationType.DownstreamKeyPreMultiply:
                case MacroOperationType.DownstreamKeyMaskEnable:
                case MacroOperationType.DownstreamKeyMaskTop:
                case MacroOperationType.DownstreamKeyMaskBottom:
                case MacroOperationType.DownstreamKeyMaskLeft:
                case MacroOperationType.DownstreamKeyMaskRight:
                case MacroOperationType.KeyType:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.LumaKeyPreMultiply:
                case MacroOperationType.KeyFlyEnable:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("frames")]
        public uint Frames
        {
            get;
            set;
        }

        public bool ShouldSerializeFrames()
        {
            switch (Id)
            {
                case MacroOperationType.MacroSleep:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("enable")]
        public AtemBool Enable
        {
            get;
            set;
        }

        public bool ShouldSerializeEnable()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxEnable:
                case MacroOperationType.SuperSourceBorderEnable:
                case MacroOperationType.SuperSourceBoxMaskEnable:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DownstreamKeyMaskEnable:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyFlyEnable:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("input")]
        public MacroInput Input
        {
            get;
            set;
        }

        public bool ShouldSerializeInput()
        {
            switch (Id)
            {
                case MacroOperationType.ProgramInput:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.AuxiliaryInput:
                case MacroOperationType.SuperSourceArtFillInput:
                case MacroOperationType.SuperSourceArtCutInput:
                case MacroOperationType.SuperSourceBoxInput:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.AudioMixerInputGain:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("style")]
        public TStyle TransitionStyle
        {
            get;
            set;
        }

        public bool ShouldSerializeTransitionStyle()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionStyle:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("rate")]
        public uint Rate
        {
            get;
            set;
        }

        public bool ShouldSerializeRate()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionWipeRate:
                    return true;
                default:
                    return false;
            }
        }

        [XmlIgnore]
        public TransitionLayer TransitionSource
        {
            get;
            set;
        }

        [XmlAttribute("source")]
        public string TransitionSourceString
        {
            get => TransitionSource.ToString() ; set => TransitionSource = (TransitionLayer)Enum.Parse(typeof (TransitionLayer), value) ; }

        public bool ShouldSerializeTransitionSourceString()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionSource:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("type")]
        public MixEffectKeyType KeyType
        {
            get;
            set;
        }

        public bool ShouldSerializeKeyType()
        {
            switch (Id)
            {
                case MacroOperationType.KeyType:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("preMultiply")]
        public AtemBool PreMultiply
        {
            get;
            set;
        }

        public bool ShouldSerializePreMultiply()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyPreMultiply:
                case MacroOperationType.LumaKeyPreMultiply:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("top")]
        public double Top
        {
            get;
            set;
        }

        public bool ShouldSerializeTop()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskTop:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DownstreamKeyMaskTop:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.FlyKeyFrameMaskTop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("bottom")]
        public double Bottom
        {
            get;
            set;
        }

        public bool ShouldSerializeBottom()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskBottom:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DownstreamKeyMaskBottom:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.FlyKeyFrameMaskBottom:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("left")]
        public double Left
        {
            get;
            set;
        }

        public bool ShouldSerializeLeft()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskLeft:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DownstreamKeyMaskLeft:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.FlyKeyFrameMaskLeft:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("right")]
        public double Right
        {
            get;
            set;
        }

        public bool ShouldSerializeRight()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskRight:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DownstreamKeyMaskRight:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.FlyKeyFrameMaskRight:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("xPosition")]
        public double XPosition
        {
            get;
            set;
        }

        public bool ShouldSerializeXPosition()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxXPosition:
                case MacroOperationType.DVEAndFlyKeyXPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("yPosition")]
        public double YPosition
        {
            get;
            set;
        }

        public bool ShouldSerializeYPosition()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxYPosition:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("rotation")]
        public double Rotation
        {
            get;
            set;
        }

        public bool ShouldSerializeRotation()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.FlyKeyFrameRotation:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("size")]
        public double Size
        {
            get;
            set;
        }

        public bool ShouldSerializeSize()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxSize:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("xSize")]
        public double XSize
        {
            get;
            set;
        }

        public bool ShouldSerializeXSize()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyXSize:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("ySize")]
        public double YSize
        {
            get;
            set;
        }

        public bool ShouldSerializeYSize()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyYSize:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("mediaPlayer")]
        public MediaPlayerId MediaPlayer
        {
            get;
            set;
        }

        public bool ShouldSerializeMediaPlayer()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerSourceStillIndex:
                case MacroOperationType.MediaPlayerSourceClipIndex:
                case MacroOperationType.MediaPlayerSourceStill:
                case MacroOperationType.MediaPlayerSourceClip:
                case MacroOperationType.MediaPlayerPlay:
                case MacroOperationType.MediaPlayerGoToBeginning:
                case MacroOperationType.MediaPlayerLoop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("index")]
        public uint Index
        {
            get;
            set;
        }

        public bool ShouldSerializeIndex()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerSourceStillIndex:
                case MacroOperationType.MediaPlayerSourceClipIndex:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("loop")]
        public AtemBool Loop
        {
            get;
            set;
        }

        public bool ShouldSerializeLoop()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerLoop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("boxIndex")]
        public uint SuperSourceBoxIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeSuperSourceBoxIndex()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxEnable:
                case MacroOperationType.SuperSourceBoxInput:
                case MacroOperationType.SuperSourceBoxXPosition:
                case MacroOperationType.SuperSourceBoxYPosition:
                case MacroOperationType.SuperSourceBoxSize:
                case MacroOperationType.SuperSourceBorderEnable:
                case MacroOperationType.SuperSourceBoxMaskEnable:
                case MacroOperationType.SuperSourceBoxMaskTop:
                case MacroOperationType.SuperSourceBoxMaskBottom:
                case MacroOperationType.SuperSourceBoxMaskLeft:
                case MacroOperationType.SuperSourceBoxMaskRight:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("artAbove")]
        public AtemBool SuperSourceArtAbove
        {
            get;
            set;
        }

        public bool ShouldSerializeSuperSourceArtAbove()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceArtAbove:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("gain")]
        public int Gain
        {
            get;
            set;
        }

        public bool ShouldSerializeGain()
        {
            switch (Id)
            {
                case MacroOperationType.AudioMixerInputGain:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("clipIndex")]
        public int HyperDeckClipIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeHyperDeckClipIndex()
        {
            switch (Id)
            {
                case MacroOperationType.HyperDeckSetSourceClipIndex:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("loopEnabled")]
        public AtemBool HyperDeckLoopEnabled
        {
            get;
            set;
        }

        public bool ShouldSerializeHyperDeckLoopEnabled()
        {
            switch (Id)
            {
                case MacroOperationType.HyperDeckSetLoop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("singleClipEnabled")]
        public AtemBool HyperDeckSingleClipEnabled
        {
            get;
            set;
        }

        public bool ShouldSerializeHyperDeckSingleClipEnabled()
        {
            switch (Id)
            {
                case MacroOperationType.HyperDeckSetSingleClip:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("speedPercent")]
        public int HyperDeckSpeedPercent
        {
            get;
            set;
        }

        public bool ShouldSerializeHyperDeckSpeedPercent()
        {
            switch (Id)
            {
                case MacroOperationType.HyperDeckSetSpeed:
                    return true;
                default:
                    return false;
            }
        }
    }
}