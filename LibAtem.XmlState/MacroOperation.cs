using System;
using System.Xml.Serialization;
using LibAtem.Common;
using LibAtem.MacroOperations;

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

        [XmlAttribute("altitude")]
        public System.UInt32 Altitude
        {
            get;
            set;
        }

        public bool ShouldSerializeAltitude()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyShadowAltitude:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("artAbove")]
        public LibAtem.XmlState.AtemBool SuperSourceArtAbove
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

        [XmlAttribute("auxiliaryIndex")]
        public LibAtem.Common.AuxiliaryId AuxiliaryIndex
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

        [XmlIgnore]
        public LibAtem.Common.BorderBevel Bevel
        {
            get;
            set;
        }

        [XmlAttribute("bevel")]
        public string BevelString
        {
            get => Bevel.ToString() ; set => Bevel = (LibAtem.Common.BorderBevel)Enum.Parse(typeof (LibAtem.Common.BorderBevel), value) ; }

        public bool ShouldSerializeBevelString()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderBevel:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("bevelPosition")]
        public System.UInt32 BevelPosition
        {
            get;
            set;
        }

        public bool ShouldSerializeBevelPosition()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderBevelPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("bevelSoftness")]
        public System.UInt32 BevelSoftness
        {
            get;
            set;
        }

        public bool ShouldSerializeBevelSoftness()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderBevelSoftness:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("bottom")]
        public System.Double Bottom
        {
            get;
            set;
        }

        public bool ShouldSerializeBottom()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyMaskBottom:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.SuperSourceBoxMaskBottom:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("boxIndex")]
        public LibAtem.Common.SuperSourceBoxId SuperSourceBoxIndex
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
                case MacroOperationType.SuperSourceBoxMaskBottom:
                case MacroOperationType.SuperSourceBoxMaskEnable:
                case MacroOperationType.SuperSourceBoxMaskLeft:
                case MacroOperationType.SuperSourceBoxMaskRight:
                case MacroOperationType.SuperSourceBoxMaskTop:
                case MacroOperationType.SuperSourceBoxSize:
                case MacroOperationType.SuperSourceBoxXPosition:
                case MacroOperationType.SuperSourceBoxYPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("clip")]
        public System.Double Clip
        {
            get;
            set;
        }

        public bool ShouldSerializeClip()
        {
            switch (Id)
            {
                case MacroOperationType.ChromaKeyClip:
                case MacroOperationType.DownstreamKeyClip:
                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.TransitionStingerDVEClip:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("clipDuration")]
        public System.UInt32 ClipDuration
        {
            get;
            set;
        }

        public bool ShouldSerializeClipDuration()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionStingerClipDuration:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("clipIndex")]
        public System.UInt32 HyperDeckClipIndex
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

        [XmlAttribute("colorGeneratorIndex")]
        public LibAtem.Common.ColorGeneratorId ColorGeneratorIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeColorGeneratorIndex()
        {
            switch (Id)
            {
                case MacroOperationType.ColorGeneratorHue:
                case MacroOperationType.ColorGeneratorLuminescence:
                case MacroOperationType.ColorGeneratorSaturation:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("direction")]
        public System.Double Direction
        {
            get;
            set;
        }

        public bool ShouldSerializeDirection()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyShadowDirection:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("downConvertMode")]
        public LibAtem.Common.DownConvertMode DownConvertMode
        {
            get;
            set;
        }

        public bool ShouldSerializeDownConvertMode()
        {
            switch (Id)
            {
                case MacroOperationType.DownConvertMode:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("enable")]
        public LibAtem.XmlState.AtemBool Enable
        {
            get;
            set;
        }

        public bool ShouldSerializeEnable()
        {
            switch (Id)
            {
                case MacroOperationType.AudioMixerMonitorOut:
                case MacroOperationType.DownstreamKeyMaskEnable:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.HyperDeckSetRollOnTakeFrameDelay:
                case MacroOperationType.KeyFlyEnable:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.SuperSourceBorderEnable:
                case MacroOperationType.SuperSourceBoxEnable:
                case MacroOperationType.SuperSourceBoxMaskEnable:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("externalSerialPortIndex")]
        public System.UInt32 ExternalSerialPortIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeExternalSerialPortIndex()
        {
            switch (Id)
            {
                case MacroOperationType.SetSerialPortFunction:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("flipFlop")]
        public LibAtem.XmlState.AtemBool FlipFlop
        {
            get;
            set;
        }

        public bool ShouldSerializeFlipFlop()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionWipeAndDVEFlipFlop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("follow")]
        public LibAtem.XmlState.AtemBool Follow
        {
            get;
            set;
        }

        public bool ShouldSerializeFollow()
        {
            switch (Id)
            {
                case MacroOperationType.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("frames")]
        public System.UInt32 Frames
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

        [XmlAttribute("function")]
        public LibAtem.Common.SerialMode Function
        {
            get;
            set;
        }

        public bool ShouldSerializeFunction()
        {
            switch (Id)
            {
                case MacroOperationType.SetSerialPortFunction:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("gain")]
        public System.Double Gain
        {
            get;
            set;
        }

        public bool ShouldSerializeGain()
        {
            switch (Id)
            {
                case MacroOperationType.AudioMixerInputGain:
                case MacroOperationType.ChromaKeyGain:
                case MacroOperationType.DownstreamKeyGain:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.TransitionStingerDVEGain:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("hue")]
        public System.Double Hue
        {
            get;
            set;
        }

        public bool ShouldSerializeHue()
        {
            switch (Id)
            {
                case MacroOperationType.ChromaKeyHue:
                case MacroOperationType.ColorGeneratorHue:
                case MacroOperationType.DVEKeyBorderHue:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("hyperDeckIndex")]
        public System.UInt32 HyperDeckIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeHyperDeckIndex()
        {
            switch (Id)
            {
                case MacroOperationType.HyperDeckPlay:
                case MacroOperationType.HyperDeckSetLoop:
                case MacroOperationType.HyperDeckSetSingleClip:
                case MacroOperationType.HyperDeckSetSourceClipIndex:
                case MacroOperationType.HyperDeckSetSpeed:
                case MacroOperationType.HyperDeckStop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("index")]
        public System.UInt32 Index
        {
            get;
            set;
        }

        public bool ShouldSerializeIndex()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerSourceClipIndex:
                case MacroOperationType.MediaPlayerSourceStillIndex:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("innerSoftness")]
        public System.UInt32 InnerSoftness
        {
            get;
            set;
        }

        public bool ShouldSerializeInnerSoftness()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderInnerSoftness:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("innerWidth")]
        public System.Double InnerWidth
        {
            get;
            set;
        }

        public bool ShouldSerializeInnerWidth()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderInnerWidth:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("input")]
        public LibAtem.XmlState.MacroInput Input
        {
            get;
            set;
        }

        public bool ShouldSerializeInput()
        {
            switch (Id)
            {
                case MacroOperationType.AudioMixerInputGain:
                case MacroOperationType.AuxiliaryInput:
                case MacroOperationType.DownstreamKeyCutInput:
                case MacroOperationType.DownstreamKeyFillInput:
                case MacroOperationType.InputVideoPort:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.MultiViewWindowInput:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.SuperSourceArtCutInput:
                case MacroOperationType.SuperSourceArtFillInput:
                case MacroOperationType.SuperSourceBoxInput:
                case MacroOperationType.TransitionDipInput:
                case MacroOperationType.TransitionWipeBorderFillInput:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("invert")]
        public LibAtem.XmlState.AtemBool Invert
        {
            get;
            set;
        }

        public bool ShouldSerializeInvert()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyInvert:
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.TransitionStingerDVEInvert:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("keyFrameIndex")]
        public LibAtem.Common.FlyKeyKeyFrameId KeyFrameIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeKeyFrameIndex()
        {
            switch (Id)
            {
                case MacroOperationType.FlyKeyRunToKeyFrame:
                case MacroOperationType.FlyKeySetKeyFrame:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("keyIndex")]
        public int KeyIndexInt
        {
            get;
            set;
        }

        public bool ShouldSerializeKeyIndexInt()
        {
            switch (Id)
            {
                case MacroOperationType.ChromaKeyClip:
                case MacroOperationType.ChromaKeyGain:
                case MacroOperationType.ChromaKeyHue:
                case MacroOperationType.ChromaKeyLift:
                case MacroOperationType.ChromaKeyNarrow:
                case MacroOperationType.DownstreamKeyAuto:
                case MacroOperationType.DownstreamKeyClip:
                case MacroOperationType.DownstreamKeyCutInput:
                case MacroOperationType.DownstreamKeyFillInput:
                case MacroOperationType.DownstreamKeyGain:
                case MacroOperationType.DownstreamKeyInvert:
                case MacroOperationType.DownstreamKeyMaskBottom:
                case MacroOperationType.DownstreamKeyMaskEnable:
                case MacroOperationType.DownstreamKeyMaskLeft:
                case MacroOperationType.DownstreamKeyMaskRight:
                case MacroOperationType.DownstreamKeyMaskTop:
                case MacroOperationType.DownstreamKeyOnAir:
                case MacroOperationType.DownstreamKeyPreMultiply:
                case MacroOperationType.DownstreamKeyRate:
                case MacroOperationType.DownstreamKeyTie:
                case MacroOperationType.DVEAndFlyKeyRate:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEKeyBorderBevel:
                case MacroOperationType.DVEKeyBorderBevelPosition:
                case MacroOperationType.DVEKeyBorderBevelSoftness:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyBorderHue:
                case MacroOperationType.DVEKeyBorderInnerSoftness:
                case MacroOperationType.DVEKeyBorderInnerWidth:
                case MacroOperationType.DVEKeyBorderLuminescence:
                case MacroOperationType.DVEKeyBorderOpacity:
                case MacroOperationType.DVEKeyBorderOuterSoftness:
                case MacroOperationType.DVEKeyBorderOuterWidth:
                case MacroOperationType.DVEKeyBorderSaturation:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyShadowAltitude:
                case MacroOperationType.DVEKeyShadowDirection:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.FlyKeyRunToFull:
                case MacroOperationType.FlyKeyRunToInfinity:
                case MacroOperationType.FlyKeyRunToKeyFrame:
                case MacroOperationType.FlyKeySetKeyFrame:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyFlyEnable:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyType:
                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.LumaKeyPreMultiply:
                case MacroOperationType.PatternKeyPattern:
                case MacroOperationType.PatternKeySize:
                case MacroOperationType.PatternKeySoftness:
                case MacroOperationType.PatternKeySymmetry:
                case MacroOperationType.PatternKeyXPosition:
                case MacroOperationType.PatternKeyYPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlIgnore]
        public LibAtem.Common.UpstreamKeyId UpstreamKeyIndex
        {
            get => (LibAtem.Common.UpstreamKeyId)KeyIndexInt ; set => KeyIndexInt = (int)value ; }

        [XmlIgnore]
        public LibAtem.Common.DownstreamKeyId DownstreamKeyIndex
        {
            get => (LibAtem.Common.DownstreamKeyId)KeyIndexInt ; set => KeyIndexInt = (int)value ; }

        [XmlAttribute("layout")]
        public LibAtem.Common.MultiViewLayout Layout
        {
            get;
            set;
        }

        public bool ShouldSerializeLayout()
        {
            switch (Id)
            {
                case MacroOperationType.MultiViewLayout:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("left")]
        public System.Double Left
        {
            get;
            set;
        }

        public bool ShouldSerializeLeft()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.SuperSourceBoxMaskLeft:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("lift")]
        public System.Double Lift
        {
            get;
            set;
        }

        public bool ShouldSerializeLift()
        {
            switch (Id)
            {
                case MacroOperationType.ChromaKeyLift:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("location")]
        public LibAtem.Common.FlyKeyLocation Location
        {
            get;
            set;
        }

        public bool ShouldSerializeLocation()
        {
            switch (Id)
            {
                case MacroOperationType.FlyKeyRunToInfinity:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("loop")]
        public LibAtem.XmlState.AtemBool Loop
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

        [XmlAttribute("loopEnabled")]
        public LibAtem.XmlState.AtemBool HyperDeckLoopEnabled
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

        [XmlAttribute("luma")]
        public System.Double Luma
        {
            get;
            set;
        }

        public bool ShouldSerializeLuma()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderLuminescence:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("luminescence")]
        public System.Double Luminescence
        {
            get;
            set;
        }

        public bool ShouldSerializeLuminescence()
        {
            switch (Id)
            {
                case MacroOperationType.ColorGeneratorLuminescence:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("mediaPlayer")]
        public int MediaPlayerInt
        {
            get;
            set;
        }

        public bool ShouldSerializeMediaPlayerInt()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerGoToBeginning:
                case MacroOperationType.MediaPlayerLoop:
                case MacroOperationType.MediaPlayerPlay:
                case MacroOperationType.MediaPlayerSourceClip:
                case MacroOperationType.MediaPlayerSourceClipIndex:
                case MacroOperationType.MediaPlayerSourceStill:
                case MacroOperationType.MediaPlayerSourceStillIndex:
                case MacroOperationType.TransitionStingerSourceMediaPlayer:
                    return true;
                default:
                    return false;
            }
        }

        [XmlIgnore]
        public LibAtem.Common.StingerSource MediaPlayer
        {
            get => (LibAtem.Common.StingerSource)MediaPlayerInt ; set => MediaPlayerInt = (int)value ; }

        [XmlIgnore]
        public LibAtem.Common.MediaPlayerId MediaPlayerIndex
        {
            get => (LibAtem.Common.MediaPlayerId)MediaPlayerInt ; set => MediaPlayerInt = (int)value ; }

        [XmlAttribute("mixEffectBlockIndex")]
        public LibAtem.Common.MixEffectBlockId MixEffectBlockIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeMixEffectBlockIndex()
        {
            switch (Id)
            {
                case MacroOperationType.AutoTransition:
                case MacroOperationType.ChromaKeyClip:
                case MacroOperationType.ChromaKeyGain:
                case MacroOperationType.ChromaKeyHue:
                case MacroOperationType.ChromaKeyLift:
                case MacroOperationType.ChromaKeyNarrow:
                case MacroOperationType.CutTransition:
                case MacroOperationType.DVEAndFlyKeyRate:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEKeyBorderBevel:
                case MacroOperationType.DVEKeyBorderBevelPosition:
                case MacroOperationType.DVEKeyBorderBevelSoftness:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyBorderHue:
                case MacroOperationType.DVEKeyBorderInnerSoftness:
                case MacroOperationType.DVEKeyBorderInnerWidth:
                case MacroOperationType.DVEKeyBorderLuminescence:
                case MacroOperationType.DVEKeyBorderOpacity:
                case MacroOperationType.DVEKeyBorderOuterSoftness:
                case MacroOperationType.DVEKeyBorderOuterWidth:
                case MacroOperationType.DVEKeyBorderSaturation:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyShadowAltitude:
                case MacroOperationType.DVEKeyShadowDirection:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.FadeToBlackAuto:
                case MacroOperationType.FadeToBlackRate:
                case MacroOperationType.FlyKeyRunToFull:
                case MacroOperationType.FlyKeyRunToInfinity:
                case MacroOperationType.FlyKeyRunToKeyFrame:
                case MacroOperationType.FlyKeySetKeyFrame:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyFlyEnable:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyType:
                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.LumaKeyPreMultiply:
                case MacroOperationType.PatternKeyPattern:
                case MacroOperationType.PatternKeySize:
                case MacroOperationType.PatternKeySoftness:
                case MacroOperationType.PatternKeySymmetry:
                case MacroOperationType.PatternKeyXPosition:
                case MacroOperationType.PatternKeyYPosition:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.TransitionDipInput:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionDVEPattern:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionPosition:
                case MacroOperationType.TransitionPreview:
                case MacroOperationType.TransitionSource:
                case MacroOperationType.TransitionStingerClipDuration:
                case MacroOperationType.TransitionStingerDVEClip:
                case MacroOperationType.TransitionStingerDVEGain:
                case MacroOperationType.TransitionStingerDVEInvert:
                case MacroOperationType.TransitionStingerDVEPreMultiply:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionStingerPreRoll:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionStingerResetDurations:
                case MacroOperationType.TransitionStingerSourceMediaPlayer:
                case MacroOperationType.TransitionStingerTriggerPoint:
                case MacroOperationType.TransitionStyle:
                case MacroOperationType.TransitionWipeAndDVEFlipFlop:
                case MacroOperationType.TransitionWipeAndDVEReverse:
                case MacroOperationType.TransitionWipeBorderFillInput:
                case MacroOperationType.TransitionWipeBorderSoftness:
                case MacroOperationType.TransitionWipeBorderWidth:
                case MacroOperationType.TransitionWipePattern:
                case MacroOperationType.TransitionWipeRate:
                case MacroOperationType.TransitionWipeSymmetry:
                case MacroOperationType.TransitionWipeXPosition:
                case MacroOperationType.TransitionWipeYPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("mixRate")]
        public System.UInt32 MixRate
        {
            get;
            set;
        }

        public bool ShouldSerializeMixRate()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionStingerMixRate:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("multiViewIndex")]
        public System.UInt32 MultiViewIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeMultiViewIndex()
        {
            switch (Id)
            {
                case MacroOperationType.MultiViewLayout:
                case MacroOperationType.MultiViewWindowInput:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("narrow")]
        public LibAtem.XmlState.AtemBool Narrow
        {
            get;
            set;
        }

        public bool ShouldSerializeNarrow()
        {
            switch (Id)
            {
                case MacroOperationType.ChromaKeyNarrow:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("onAir")]
        public LibAtem.XmlState.AtemBool OnAir
        {
            get;
            set;
        }

        public bool ShouldSerializeOnAir()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyOnAir:
                case MacroOperationType.KeyOnAir:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("opacity")]
        public System.UInt32 Opacity
        {
            get;
            set;
        }

        public bool ShouldSerializeOpacity()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderOpacity:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("outerSoftness")]
        public System.UInt32 OuterSoftness
        {
            get;
            set;
        }

        public bool ShouldSerializeOuterSoftness()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderOuterSoftness:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("outerWidth")]
        public System.Double OuterWidth
        {
            get;
            set;
        }

        public bool ShouldSerializeOuterWidth()
        {
            switch (Id)
            {
                case MacroOperationType.DVEKeyBorderOuterWidth:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("pattern")]
        public string PatternString
        {
            get;
            set;
        }

        public bool ShouldSerializePatternString()
        {
            switch (Id)
            {
                case MacroOperationType.PatternKeyPattern:
                case MacroOperationType.TransitionDVEPattern:
                case MacroOperationType.TransitionWipePattern:
                    return true;
                default:
                    return false;
            }
        }

        [XmlIgnore]
        public LibAtem.Common.Pattern Pattern
        {
            get => (LibAtem.Common.Pattern)Enum.Parse(typeof (LibAtem.Common.Pattern), PatternString) ; set => PatternString = value.ToString() ; }

        [XmlIgnore]
        public LibAtem.Common.DVEEffect DVEEffectPattern
        {
            get => (LibAtem.Common.DVEEffect)Enum.Parse(typeof (LibAtem.Common.DVEEffect), PatternString) ; set => PatternString = value.ToString() ; }

        [XmlIgnore]
        public LibAtem.Common.Pattern PatternKeyPattern
        {
            get => (LibAtem.Common.Pattern)Enum.Parse(typeof (LibAtem.Common.Pattern), PatternString) ; set => PatternString = value.ToString() ; }

        [XmlAttribute("position")]
        public System.Double Position
        {
            get;
            set;
        }

        public bool ShouldSerializePosition()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("preMultiply")]
        public LibAtem.XmlState.AtemBool PreMultiply
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
                case MacroOperationType.TransitionStingerDVEPreMultiply:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("preRoll")]
        public System.UInt32 PreRoll
        {
            get;
            set;
        }

        public bool ShouldSerializePreRoll()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionStingerPreRoll:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("preview")]
        public LibAtem.XmlState.AtemBool Preview
        {
            get;
            set;
        }

        public bool ShouldSerializePreview()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionPreview:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("rate")]
        public System.UInt32 Rate
        {
            get;
            set;
        }

        public bool ShouldSerializeRate()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyRate:
                case MacroOperationType.DVEAndFlyKeyRate:
                case MacroOperationType.FadeToBlackRate:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionWipeRate:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("reverse")]
        public LibAtem.XmlState.AtemBool Reverse
        {
            get;
            set;
        }

        public bool ShouldSerializeReverse()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionWipeAndDVEReverse:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("right")]
        public System.Double Right
        {
            get;
            set;
        }

        public bool ShouldSerializeRight()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyMaskRight:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.SuperSourceBoxMaskRight:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("rotation")]
        public System.Double Rotation
        {
            get;
            set;
        }

        public bool ShouldSerializeRotation()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyRotation:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("saturation")]
        public System.Double Saturation
        {
            get;
            set;
        }

        public bool ShouldSerializeSaturation()
        {
            switch (Id)
            {
                case MacroOperationType.ColorGeneratorSaturation:
                case MacroOperationType.DVEKeyBorderSaturation:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("singleClipEnabled")]
        public LibAtem.XmlState.AtemBool HyperDeckSingleClipEnabled
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

        [XmlAttribute("size")]
        public System.Double Size
        {
            get;
            set;
        }

        public bool ShouldSerializeSize()
        {
            switch (Id)
            {
                case MacroOperationType.PatternKeySize:
                case MacroOperationType.SuperSourceBoxSize:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("softness")]
        public System.Double Softness
        {
            get;
            set;
        }

        public bool ShouldSerializeSoftness()
        {
            switch (Id)
            {
                case MacroOperationType.PatternKeySoftness:
                case MacroOperationType.TransitionWipeBorderSoftness:
                    return true;
                default:
                    return false;
            }
        }

        [XmlIgnore]
        public LibAtem.Common.TransitionLayer TransitionSource
        {
            get;
            set;
        }

        [XmlAttribute("source")]
        public string TransitionSourceString
        {
            get => TransitionSource.ToString() ; set => TransitionSource = (LibAtem.Common.TransitionLayer)Enum.Parse(typeof (LibAtem.Common.TransitionLayer), value) ; }

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

        [XmlAttribute("speedPercent")]
        public System.UInt32 HyperDeckSpeedPercent
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

        [XmlAttribute("style")]
        public LibAtem.Common.TStyle TransitionStyle
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

        [XmlAttribute("symmetry")]
        public System.Double Symmetry
        {
            get;
            set;
        }

        public bool ShouldSerializeSymmetry()
        {
            switch (Id)
            {
                case MacroOperationType.PatternKeySymmetry:
                case MacroOperationType.TransitionWipeSymmetry:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("tie")]
        public LibAtem.XmlState.AtemBool Tie
        {
            get;
            set;
        }

        public bool ShouldSerializeTie()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyTie:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("top")]
        public System.Double Top
        {
            get;
            set;
        }

        public bool ShouldSerializeTop()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyMaskTop:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.SuperSourceBoxMaskTop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("triggerPoint")]
        public System.UInt32 TriggerPoint
        {
            get;
            set;
        }

        public bool ShouldSerializeTriggerPoint()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionStingerTriggerPoint:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("type")]
        public LibAtem.Common.MixEffectKeyType KeyType
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

        [XmlAttribute("videoMode")]
        public LibAtem.Common.VideoMode VideoMode
        {
            get;
            set;
        }

        public bool ShouldSerializeVideoMode()
        {
            switch (Id)
            {
                case MacroOperationType.VideoMode:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("videoPort")]
        public LibAtem.Common.MacroPortType VideoPort
        {
            get;
            set;
        }

        public bool ShouldSerializeVideoPort()
        {
            switch (Id)
            {
                case MacroOperationType.InputVideoPort:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("width")]
        public System.Double Width
        {
            get;
            set;
        }

        public bool ShouldSerializeWidth()
        {
            switch (Id)
            {
                case MacroOperationType.TransitionWipeBorderWidth:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("windowIndex")]
        public System.UInt32 WindowIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeWindowIndex()
        {
            switch (Id)
            {
                case MacroOperationType.MultiViewWindowInput:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("xPosition")]
        public System.Double PositionX
        {
            get;
            set;
        }

        public bool ShouldSerializePositionX()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.PatternKeyXPosition:
                case MacroOperationType.SuperSourceBoxXPosition:
                case MacroOperationType.TransitionWipeXPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("xSize")]
        public System.Double SizeX
        {
            get;
            set;
        }

        public bool ShouldSerializeSizeX()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyXSize:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("yPosition")]
        public System.Double PositionY
        {
            get;
            set;
        }

        public bool ShouldSerializePositionY()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.PatternKeyYPosition:
                case MacroOperationType.SuperSourceBoxYPosition:
                case MacroOperationType.TransitionWipeYPosition:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("ySize")]
        public System.Double SizeY
        {
            get;
            set;
        }

        public bool ShouldSerializeSizeY()
        {
            switch (Id)
            {
                case MacroOperationType.DVEAndFlyKeyYSize:
                    return true;
                default:
                    return false;
            }
        }
    }

    public static class MacroOpExtensions
    {
        public static MacroOperation ToMacroOperation(this MacroOpBase op)
        {
            switch (op.GetType().FullName)
            {
                case "LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp":
                    var opAudioMixerInputGainMacroOp = (LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AudioMixerInputGain, Input = opAudioMixerInputGainMacroOp.Index.ToMacroInput(), Gain = opAudioMixerInputGainMacroOp.Gain};
                case "LibAtem.MacroOperations.Audio.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp":
                    var opAudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp = (LibAtem.MacroOperations.Audio.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1, Follow = opAudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp.Follow.ToAtemBool()};
                case "LibAtem.MacroOperations.Audio.AudioMixerMonitorOutMacroOp":
                    var opAudioMixerMonitorOutMacroOp = (LibAtem.MacroOperations.Audio.AudioMixerMonitorOutMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AudioMixerMonitorOut, Enable = opAudioMixerMonitorOutMacroOp.Enable.ToAtemBool()};
                case "LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp":
                    var opAutoTransitionMacroOp = (LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AutoTransition, MixEffectBlockIndex = opAutoTransitionMacroOp.Index};
                case "LibAtem.MacroOperations.AuxiliaryInputMacroOp":
                    var opAuxiliaryInputMacroOp = (LibAtem.MacroOperations.AuxiliaryInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AuxiliaryInput, AuxiliaryIndex = opAuxiliaryInputMacroOp.Index, Input = opAuxiliaryInputMacroOp.Source.ToMacroInput()};
                case "LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyYSuppressMacroOp":
                    var opChromaKeyYSuppressMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyYSuppressMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyClip, Clip = opChromaKeyYSuppressMacroOp.YSuppress, UpstreamKeyIndex = opChromaKeyYSuppressMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyYSuppressMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyGainMacroOp":
                    var opChromaKeyGainMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyGain, Gain = opChromaKeyGainMacroOp.Gain, UpstreamKeyIndex = opChromaKeyGainMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyGainMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyHueMacroOp":
                    var opChromaKeyHueMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyHueMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyHue, Hue = opChromaKeyHueMacroOp.Hue, UpstreamKeyIndex = opChromaKeyHueMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyHueMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyLiftMacroOp":
                    var opChromaKeyLiftMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyLiftMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyLift, Lift = opChromaKeyLiftMacroOp.Lift, UpstreamKeyIndex = opChromaKeyLiftMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyLiftMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyNarrowMacroOp":
                    var opChromaKeyNarrowMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyNarrowMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyNarrow, Narrow = opChromaKeyNarrowMacroOp.Narrow.ToAtemBool(), UpstreamKeyIndex = opChromaKeyNarrowMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyNarrowMacroOp.Index};
                case "LibAtem.MacroOperations.ColorGeneratorHueMacroOp":
                    var opColorGeneratorHueMacroOp = (LibAtem.MacroOperations.ColorGeneratorHueMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ColorGeneratorHue, ColorGeneratorIndex = opColorGeneratorHueMacroOp.ColorGeneratorIndex, Hue = opColorGeneratorHueMacroOp.Hue};
                case "LibAtem.MacroOperations.ColorGeneratorLuminescenceMacroOp":
                    var opColorGeneratorLuminescenceMacroOp = (LibAtem.MacroOperations.ColorGeneratorLuminescenceMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ColorGeneratorLuminescence, ColorGeneratorIndex = opColorGeneratorLuminescenceMacroOp.ColorGeneratorIndex, Luminescence = opColorGeneratorLuminescenceMacroOp.Luma};
                case "LibAtem.MacroOperations.ColorGeneratorSaturationMacroOp":
                    var opColorGeneratorSaturationMacroOp = (LibAtem.MacroOperations.ColorGeneratorSaturationMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ColorGeneratorSaturation, ColorGeneratorIndex = opColorGeneratorSaturationMacroOp.ColorGeneratorIndex, Saturation = opColorGeneratorSaturationMacroOp.Saturation};
                case "LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp":
                    var opCutTransitionMacroOp = (LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.CutTransition, MixEffectBlockIndex = opCutTransitionMacroOp.Index};
                case "LibAtem.MacroOperations.Settings.DownConvertModeMacroOp":
                    var opDownConvertModeMacroOp = (LibAtem.MacroOperations.Settings.DownConvertModeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownConvertMode, DownConvertMode = opDownConvertModeMacroOp.DownConvertMode};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyAutoMacroOp":
                    var opDownstreamKeyAutoMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyAutoMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyAuto, DownstreamKeyIndex = opDownstreamKeyAutoMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyClipMacroOp":
                    var opDownstreamKeyClipMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyClipMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyClip, Clip = opDownstreamKeyClipMacroOp.Clip, DownstreamKeyIndex = opDownstreamKeyClipMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyCutInputMacroOp":
                    var opDownstreamKeyCutInputMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyCutInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyCutInput, Input = opDownstreamKeyCutInputMacroOp.Input.ToMacroInput(), DownstreamKeyIndex = opDownstreamKeyCutInputMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyFillInputMacroOp":
                    var opDownstreamKeyFillInputMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyFillInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyFillInput, Input = opDownstreamKeyFillInputMacroOp.Input.ToMacroInput(), DownstreamKeyIndex = opDownstreamKeyFillInputMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyGainMacroOp":
                    var opDownstreamKeyGainMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyGain, Gain = opDownstreamKeyGainMacroOp.Gain, DownstreamKeyIndex = opDownstreamKeyGainMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyInvertMacroOp":
                    var opDownstreamKeyInvertMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyInvertMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyInvert, Invert = opDownstreamKeyInvertMacroOp.Invert.ToAtemBool(), DownstreamKeyIndex = opDownstreamKeyInvertMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskBottomMacroOp":
                    var opDownstreamKeyMaskBottomMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskBottomMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyMaskBottom, Bottom = opDownstreamKeyMaskBottomMacroOp.Bottom, DownstreamKeyIndex = opDownstreamKeyMaskBottomMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskEnableMacroOp":
                    var opDownstreamKeyMaskEnableMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyMaskEnable, Enable = opDownstreamKeyMaskEnableMacroOp.Enable.ToAtemBool(), DownstreamKeyIndex = opDownstreamKeyMaskEnableMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskLeftMacroOp":
                    var opDownstreamKeyMaskLeftMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskLeftMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyMaskLeft, Left = opDownstreamKeyMaskLeftMacroOp.Left, DownstreamKeyIndex = opDownstreamKeyMaskLeftMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskRightMacroOp":
                    var opDownstreamKeyMaskRightMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskRightMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyMaskRight, Right = opDownstreamKeyMaskRightMacroOp.Right, DownstreamKeyIndex = opDownstreamKeyMaskRightMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskTopMacroOp":
                    var opDownstreamKeyMaskTopMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskTopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyMaskTop, Top = opDownstreamKeyMaskTopMacroOp.Top, DownstreamKeyIndex = opDownstreamKeyMaskTopMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyOnAirMacroOp":
                    var opDownstreamKeyOnAirMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyOnAirMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyOnAir, OnAir = opDownstreamKeyOnAirMacroOp.OnAir.ToAtemBool(), DownstreamKeyIndex = opDownstreamKeyOnAirMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyPreMultiplyMacroOp":
                    var opDownstreamKeyPreMultiplyMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyPreMultiplyMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyPreMultiply, PreMultiply = opDownstreamKeyPreMultiplyMacroOp.PreMultiply.ToAtemBool(), DownstreamKeyIndex = opDownstreamKeyPreMultiplyMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyRateMacroOp":
                    var opDownstreamKeyRateMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyRate, Rate = opDownstreamKeyRateMacroOp.Rate, DownstreamKeyIndex = opDownstreamKeyRateMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.DownStreamKey.DownstreamKeyTieMacroOp":
                    var opDownstreamKeyTieMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyTieMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DownstreamKeyTie, Tie = opDownstreamKeyTieMacroOp.Tie.ToAtemBool(), DownstreamKeyIndex = opDownstreamKeyTieMacroOp.KeyIndex};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyRateMacroOp":
                    var opDVEAndFlyKeyRateMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyRate, Rate = opDVEAndFlyKeyRateMacroOp.Rate, UpstreamKeyIndex = opDVEAndFlyKeyRateMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyRotationMacroOp":
                    var opDVEAndFlyKeyRotationMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyRotationMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyRotation, Rotation = opDVEAndFlyKeyRotationMacroOp.Rotation, UpstreamKeyIndex = opDVEAndFlyKeyRotationMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyRotationMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyXPositionMacroOp":
                    var opDVEAndFlyKeyXPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyXPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyXPosition, PositionX = opDVEAndFlyKeyXPositionMacroOp.PositionX, UpstreamKeyIndex = opDVEAndFlyKeyXPositionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyXPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyXSizeMacroOp":
                    var opDVEAndFlyKeyXSizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyXSizeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyXSize, SizeX = opDVEAndFlyKeyXSizeMacroOp.SizeX, UpstreamKeyIndex = opDVEAndFlyKeyXSizeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyXSizeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyYPositionMacroOp":
                    var opDVEAndFlyKeyYPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyYPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyYPosition, PositionY = opDVEAndFlyKeyYPositionMacroOp.PositionY, UpstreamKeyIndex = opDVEAndFlyKeyYPositionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyYPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyYSizeMacroOp":
                    var opDVEAndFlyKeyYSizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyYSizeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyYSize, SizeY = opDVEAndFlyKeyYSizeMacroOp.SizeY, UpstreamKeyIndex = opDVEAndFlyKeyYSizeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyYSizeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelMacroOp":
                    var opDVEKeyBorderBevelMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderBevel, Bevel = opDVEKeyBorderBevelMacroOp.Bevel, UpstreamKeyIndex = opDVEKeyBorderBevelMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderBevelMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelPositionMacroOp":
                    var opDVEKeyBorderBevelPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderBevelPosition, BevelPosition = opDVEKeyBorderBevelPositionMacroOp.BevelPosition, UpstreamKeyIndex = opDVEKeyBorderBevelPositionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderBevelPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelSoftnessMacroOp":
                    var opDVEKeyBorderBevelSoftnessMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelSoftnessMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderBevelSoftness, BevelSoftness = opDVEKeyBorderBevelSoftnessMacroOp.BevelSoftness, UpstreamKeyIndex = opDVEKeyBorderBevelSoftnessMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderBevelSoftnessMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderEnableMacroOp":
                    var opDVEKeyBorderEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderEnable, Enable = opDVEKeyBorderEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opDVEKeyBorderEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderEnableMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderHueMacroOp":
                    var opDVEKeyBorderHueMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderHueMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderHue, Hue = opDVEKeyBorderHueMacroOp.Hue, UpstreamKeyIndex = opDVEKeyBorderHueMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderHueMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderInnerSoftnessMacroOp":
                    var opDVEKeyBorderInnerSoftnessMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderInnerSoftnessMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderInnerSoftness, InnerSoftness = opDVEKeyBorderInnerSoftnessMacroOp.InnerSoftness, UpstreamKeyIndex = opDVEKeyBorderInnerSoftnessMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderInnerSoftnessMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderInnerWidthMacroOp":
                    var opDVEKeyBorderInnerWidthMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderInnerWidthMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderInnerWidth, InnerWidth = opDVEKeyBorderInnerWidthMacroOp.InnerWidth, UpstreamKeyIndex = opDVEKeyBorderInnerWidthMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderInnerWidthMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderLuminescenceMacroOp":
                    var opDVEKeyBorderLuminescenceMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderLuminescenceMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderLuminescence, Luma = opDVEKeyBorderLuminescenceMacroOp.Luma, UpstreamKeyIndex = opDVEKeyBorderLuminescenceMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderLuminescenceMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOpacityMacroOp":
                    var opDVEKeyBorderOpacityMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOpacityMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderOpacity, Opacity = opDVEKeyBorderOpacityMacroOp.Opacity, UpstreamKeyIndex = opDVEKeyBorderOpacityMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderOpacityMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOuterSoftnessMacroOp":
                    var opDVEKeyBorderOuterSoftnessMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOuterSoftnessMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderOuterSoftness, OuterSoftness = opDVEKeyBorderOuterSoftnessMacroOp.OuterSoftness, UpstreamKeyIndex = opDVEKeyBorderOuterSoftnessMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderOuterSoftnessMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOuterWidthMacroOp":
                    var opDVEKeyBorderOuterWidthMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOuterWidthMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderOuterWidth, OuterWidth = opDVEKeyBorderOuterWidthMacroOp.OuterWidth, UpstreamKeyIndex = opDVEKeyBorderOuterWidthMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderOuterWidthMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderSaturationMacroOp":
                    var opDVEKeyBorderSaturationMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderSaturationMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderSaturation, Saturation = opDVEKeyBorderSaturationMacroOp.Saturation, UpstreamKeyIndex = opDVEKeyBorderSaturationMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderSaturationMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskBottomMacroOp":
                    var opDVEKeyMaskBottomMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskBottomMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskBottom, Bottom = opDVEKeyMaskBottomMacroOp.Bottom, UpstreamKeyIndex = opDVEKeyMaskBottomMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskBottomMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskEnableMacroOp":
                    var opDVEKeyMaskEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskEnable, Enable = opDVEKeyMaskEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opDVEKeyMaskEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskEnableMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskLeftMacroOp":
                    var opDVEKeyMaskLeftMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskLeftMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskLeft, Left = opDVEKeyMaskLeftMacroOp.Left, UpstreamKeyIndex = opDVEKeyMaskLeftMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskLeftMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskRightMacroOp":
                    var opDVEKeyMaskRightMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskRightMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskRight, Right = opDVEKeyMaskRightMacroOp.Right, UpstreamKeyIndex = opDVEKeyMaskRightMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskRightMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskTopMacroOp":
                    var opDVEKeyMaskTopMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskTopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskTop, Top = opDVEKeyMaskTopMacroOp.Top, UpstreamKeyIndex = opDVEKeyMaskTopMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskTopMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowAltitudeMacroOp":
                    var opDVEKeyShadowAltitudeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowAltitudeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyShadowAltitude, Altitude = opDVEKeyShadowAltitudeMacroOp.Altitude, UpstreamKeyIndex = opDVEKeyShadowAltitudeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyShadowAltitudeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowDirectionMacroOp":
                    var opDVEKeyShadowDirectionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowDirectionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyShadowDirection, Direction = opDVEKeyShadowDirectionMacroOp.Direction, UpstreamKeyIndex = opDVEKeyShadowDirectionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyShadowDirectionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowEnableMacroOp":
                    var opDVEKeyShadowEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyShadowEnable, Enable = opDVEKeyShadowEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opDVEKeyShadowEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyShadowEnableMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp":
                    var opFadeToBlackAutoMacroOp = (LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FadeToBlackAuto, MixEffectBlockIndex = opFadeToBlackAutoMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.FadeToBlackRateMacroOp":
                    var opFadeToBlackRateMacroOp = (LibAtem.MacroOperations.MixEffects.FadeToBlackRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FadeToBlackRate, Rate = opFadeToBlackRateMacroOp.Rate, MixEffectBlockIndex = opFadeToBlackRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.FlyKeyRunToAllMacroOp":
                    var opFlyKeyRunToAllMacroOp = (LibAtem.MacroOperations.MixEffects.Key.FlyKeyRunToAllMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FlyKeyRunToFull, UpstreamKeyIndex = opFlyKeyRunToAllMacroOp.KeyIndex, MixEffectBlockIndex = opFlyKeyRunToAllMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.FlyKeyRunToInfinityMacroOp":
                    var opFlyKeyRunToInfinityMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.FlyKeyRunToInfinityMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FlyKeyRunToInfinity, Location = opFlyKeyRunToInfinityMacroOp.Location, UpstreamKeyIndex = opFlyKeyRunToInfinityMacroOp.KeyIndex, MixEffectBlockIndex = opFlyKeyRunToInfinityMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.FlyKeyRunToKeyFrameMacroOp":
                    var opFlyKeyRunToKeyFrameMacroOp = (LibAtem.MacroOperations.MixEffects.Key.FlyKeyRunToKeyFrameMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FlyKeyRunToKeyFrame, KeyFrameIndex = opFlyKeyRunToKeyFrameMacroOp.KeyFrameIndex, UpstreamKeyIndex = opFlyKeyRunToKeyFrameMacroOp.KeyIndex, MixEffectBlockIndex = opFlyKeyRunToKeyFrameMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVE.FlyKeySetKeyFrameMacroOp":
                    var opFlyKeySetKeyFrameMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVE.FlyKeySetKeyFrameMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FlyKeySetKeyFrame, KeyFrameIndex = opFlyKeySetKeyFrameMacroOp.KeyFrameIndex, UpstreamKeyIndex = opFlyKeySetKeyFrameMacroOp.KeyIndex, MixEffectBlockIndex = opFlyKeySetKeyFrameMacroOp.Index};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp":
                    var opHyperDeckPlayMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckPlay, HyperDeckIndex = opHyperDeckPlayMacroOp.Index};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp":
                    var opHyperDeckSetLoopMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckSetLoop, HyperDeckLoopEnabled = opHyperDeckSetLoopMacroOp.Loop.ToAtemBool(), HyperDeckIndex = opHyperDeckSetLoopMacroOp.Index};
                case "LibAtem.MacroOperations.Audio.AudioMixerAfvFollowTransitionMacroOp":
                    var opAudioMixerAfvFollowTransitionMacroOp = (LibAtem.MacroOperations.Audio.AudioMixerAfvFollowTransitionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckSetRollOnTakeFrameDelay, Enable = opAudioMixerAfvFollowTransitionMacroOp.Enable.ToAtemBool()};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckSetSingleClipMacroOp":
                    var opHyperDeckSetSingleClipMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetSingleClipMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckSetSingleClip, HyperDeckSingleClipEnabled = opHyperDeckSetSingleClipMacroOp.SingleClipEnabled.ToAtemBool(), HyperDeckIndex = opHyperDeckSetSingleClipMacroOp.Index};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckSetSourceClipIndexMacroOp":
                    var opHyperDeckSetSourceClipIndexMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetSourceClipIndexMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckSetSourceClipIndex, HyperDeckClipIndex = opHyperDeckSetSourceClipIndexMacroOp.ClipIndex, HyperDeckIndex = opHyperDeckSetSourceClipIndexMacroOp.Index};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckSetSpeedMacroOp":
                    var opHyperDeckSetSpeedMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetSpeedMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckSetSpeed, HyperDeckSpeedPercent = opHyperDeckSetSpeedMacroOp.SpeedPercent, HyperDeckIndex = opHyperDeckSetSpeedMacroOp.Index};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckStopMacroOp":
                    var opHyperDeckStopMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckStopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckStop, HyperDeckIndex = opHyperDeckStopMacroOp.Index};
                case "LibAtem.MacroOperations.Settings.InputVideoPortMacroOp":
                    var opInputVideoPortMacroOp = (LibAtem.MacroOperations.Settings.InputVideoPortMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.InputVideoPort, Input = opInputVideoPortMacroOp.Source.ToMacroInput(), VideoPort = opInputVideoPortMacroOp.Port};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp":
                    var opKeyCutInputMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyCutInput, Input = opKeyCutInputMacroOp.Source.ToMacroInput(), UpstreamKeyIndex = opKeyCutInputMacroOp.KeyIndex, MixEffectBlockIndex = opKeyCutInputMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp":
                    var opKeyFillInputMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyFillInput, Input = opKeyFillInputMacroOp.Source.ToMacroInput(), UpstreamKeyIndex = opKeyFillInputMacroOp.KeyIndex, MixEffectBlockIndex = opKeyFillInputMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyFlyEnableMacroOp":
                    var opKeyFlyEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyFlyEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyFlyEnable, Enable = opKeyFlyEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opKeyFlyEnableMacroOp.KeyIndex, MixEffectBlockIndex = opKeyFlyEnableMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyMaskBottomMacroOp":
                    var opKeyMaskBottomMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskBottomMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyMaskBottom, Bottom = opKeyMaskBottomMacroOp.Bottom, UpstreamKeyIndex = opKeyMaskBottomMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskBottomMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyMaskEnableMacroOp":
                    var opKeyMaskEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyMaskEnable, Enable = opKeyMaskEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opKeyMaskEnableMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskEnableMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyMaskLeftMacroOp":
                    var opKeyMaskLeftMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskLeftMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyMaskLeft, Left = opKeyMaskLeftMacroOp.Left, UpstreamKeyIndex = opKeyMaskLeftMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskLeftMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyMaskRightMacroOp":
                    var opKeyMaskRightMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskRightMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyMaskRight, Right = opKeyMaskRightMacroOp.Right, UpstreamKeyIndex = opKeyMaskRightMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskRightMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyMaskTopMacroOp":
                    var opKeyMaskTopMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskTopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyMaskTop, Top = opKeyMaskTopMacroOp.Top, UpstreamKeyIndex = opKeyMaskTopMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskTopMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyOnAirMacroOp":
                    var opKeyOnAirMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyOnAirMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyOnAir, OnAir = opKeyOnAirMacroOp.OnAir.ToAtemBool(), UpstreamKeyIndex = opKeyOnAirMacroOp.KeyIndex, MixEffectBlockIndex = opKeyOnAirMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.KeyTypeMacroOp":
                    var opKeyTypeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyTypeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.KeyType, KeyType = opKeyTypeMacroOp.KeyType, UpstreamKeyIndex = opKeyTypeMacroOp.KeyIndex, MixEffectBlockIndex = opKeyTypeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyClipMacroOp":
                    var opLumaKeyClipMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyClipMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyClip, Clip = opLumaKeyClipMacroOp.Clip, UpstreamKeyIndex = opLumaKeyClipMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyClipMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyGainMacroOp":
                    var opLumaKeyGainMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyGain, Gain = opLumaKeyGainMacroOp.Gain, UpstreamKeyIndex = opLumaKeyGainMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyGainMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyInvertMacroOp":
                    var opLumaKeyInvertMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyInvertMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyInvert, Invert = opLumaKeyInvertMacroOp.Invert.ToAtemBool(), UpstreamKeyIndex = opLumaKeyInvertMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyInvertMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyPreMultiplyMacroOp":
                    var opLumaKeyPreMultiplyMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyPreMultiplyMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyPreMultiply, PreMultiply = opLumaKeyPreMultiplyMacroOp.PreMultiply.ToAtemBool(), UpstreamKeyIndex = opLumaKeyPreMultiplyMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyPreMultiplyMacroOp.Index};
                case "LibAtem.MacroOperations.MacroSleepMacroOp":
                    var opMacroSleepMacroOp = (LibAtem.MacroOperations.MacroSleepMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MacroSleep, Frames = opMacroSleepMacroOp.Frames};
                case "LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp":
                    var opMediaPlayerGoToBeginningMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerGoToBeginning, MediaPlayerIndex = opMediaPlayerGoToBeginningMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp":
                    var opMediaPlayerLoopMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerLoop, Loop = opMediaPlayerLoopMacroOp.Loop.ToAtemBool(), MediaPlayerIndex = opMediaPlayerLoopMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp":
                    var opMediaPlayerPlayMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerPlay, MediaPlayerIndex = opMediaPlayerPlayMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp":
                    var opMediaPlayerSourceClipMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceClip, MediaPlayerIndex = opMediaPlayerSourceClipMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp":
                    var opMediaPlayerSourceClipIndexMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceClipIndex, Index = opMediaPlayerSourceClipIndexMacroOp.MediaIndex, MediaPlayerIndex = opMediaPlayerSourceClipIndexMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp":
                    var opMediaPlayerSourceStillMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceStill, MediaPlayerIndex = opMediaPlayerSourceStillMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp":
                    var opMediaPlayerSourceStillIndexMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceStillIndex, Index = opMediaPlayerSourceStillIndexMacroOp.MediaIndex, MediaPlayerIndex = opMediaPlayerSourceStillIndexMacroOp.Index};
                case "LibAtem.MacroOperations.Settings.MultiViewLayoutMacroOp":
                    var opMultiViewLayoutMacroOp = (LibAtem.MacroOperations.Settings.MultiViewLayoutMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MultiViewLayout, MultiViewIndex = opMultiViewLayoutMacroOp.MultiViewIndex, Layout = opMultiViewLayoutMacroOp.Layout};
                case "LibAtem.MacroOperations.Settings.MultiViewWindowInputMacroOp":
                    var opMultiViewWindowInputMacroOp = (LibAtem.MacroOperations.Settings.MultiViewWindowInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MultiViewWindowInput, MultiViewIndex = opMultiViewWindowInputMacroOp.MultiViewIndex, WindowIndex = opMultiViewWindowInputMacroOp.WindowIndex, Input = opMultiViewWindowInputMacroOp.Source.ToMacroInput()};
                case "LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyPatternMacroOp":
                    var opPatternKeyPatternMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyPatternMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeyPattern, PatternKeyPattern = opPatternKeyPatternMacroOp.Pattern, UpstreamKeyIndex = opPatternKeyPatternMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeyPatternMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySizeMacroOp":
                    var opPatternKeySizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySizeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeySize, Size = opPatternKeySizeMacroOp.Size, UpstreamKeyIndex = opPatternKeySizeMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeySizeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySoftnessMacroOp":
                    var opPatternKeySoftnessMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySoftnessMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeySoftness, Softness = opPatternKeySoftnessMacroOp.Softness, UpstreamKeyIndex = opPatternKeySoftnessMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeySoftnessMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySymmetryMacroOp":
                    var opPatternKeySymmetryMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySymmetryMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeySymmetry, Symmetry = opPatternKeySymmetryMacroOp.Symmetry, UpstreamKeyIndex = opPatternKeySymmetryMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeySymmetryMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyXPositionMacroOp":
                    var opPatternKeyXPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyXPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeyXPosition, PositionX = opPatternKeyXPositionMacroOp.XPosition, UpstreamKeyIndex = opPatternKeyXPositionMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeyXPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyYPositionMacroOp":
                    var opPatternKeyYPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyYPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeyYPosition, PositionY = opPatternKeyYPositionMacroOp.YPosition, UpstreamKeyIndex = opPatternKeyYPositionMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeyYPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp":
                    var opPreviewInputMacroOp = (LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PreviewInput, Input = opPreviewInputMacroOp.Source.ToMacroInput(), MixEffectBlockIndex = opPreviewInputMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp":
                    var opProgramInputMacroOp = (LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ProgramInput, Input = opProgramInputMacroOp.Source.ToMacroInput(), MixEffectBlockIndex = opProgramInputMacroOp.Index};
                case "LibAtem.MacroOperations.Settings.SetSerialPortFunctionMacroOp":
                    var opSetSerialPortFunctionMacroOp = (LibAtem.MacroOperations.Settings.SetSerialPortFunctionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SetSerialPortFunction, ExternalSerialPortIndex = opSetSerialPortFunctionMacroOp.ExternalSerialPortIndex, Function = opSetSerialPortFunctionMacroOp.SerialMode};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceArtAboveMacroOp":
                    var opSuperSourceArtAboveMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceArtAboveMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceArtAbove, SuperSourceArtAbove = opSuperSourceArtAboveMacroOp.ArtAbove.ToAtemBool()};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceArtCutInputMacroOp":
                    var opSuperSourceArtCutInputMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceArtCutInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceArtCutInput, Input = opSuperSourceArtCutInputMacroOp.Source.ToMacroInput()};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceArtFillInputMacroOp":
                    var opSuperSourceArtFillInputMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceArtFillInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceArtFillInput, Input = opSuperSourceArtFillInputMacroOp.Source.ToMacroInput()};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBorderEnableMacroOp":
                    var opSuperSourceBorderEnableMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBorderEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBorderEnable, Enable = opSuperSourceBorderEnableMacroOp.Enable.ToAtemBool()};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxEnableMacroOp":
                    var opSuperSourceBoxEnableMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxEnable, Enable = opSuperSourceBoxEnableMacroOp.Enable.ToAtemBool(), SuperSourceBoxIndex = opSuperSourceBoxEnableMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxInputMacroOp":
                    var opSuperSourceBoxInputMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxInput, Input = opSuperSourceBoxInputMacroOp.Source.ToMacroInput(), SuperSourceBoxIndex = opSuperSourceBoxInputMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskBottomMacroOp":
                    var opSuperSourceBoxMaskBottomMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskBottomMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxMaskBottom, Bottom = opSuperSourceBoxMaskBottomMacroOp.Bottom, SuperSourceBoxIndex = opSuperSourceBoxMaskBottomMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskEnableMacroOp":
                    var opSuperSourceBoxMaskEnableMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxMaskEnable, Enable = opSuperSourceBoxMaskEnableMacroOp.Enable.ToAtemBool(), SuperSourceBoxIndex = opSuperSourceBoxMaskEnableMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskLeftMacroOp":
                    var opSuperSourceBoxMaskLeftMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskLeftMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxMaskLeft, Left = opSuperSourceBoxMaskLeftMacroOp.Left, SuperSourceBoxIndex = opSuperSourceBoxMaskLeftMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskRightMacroOp":
                    var opSuperSourceBoxMaskRightMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskRightMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxMaskRight, Right = opSuperSourceBoxMaskRightMacroOp.Right, SuperSourceBoxIndex = opSuperSourceBoxMaskRightMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskTopMacroOp":
                    var opSuperSourceBoxMaskTopMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskTopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxMaskTop, Top = opSuperSourceBoxMaskTopMacroOp.Top, SuperSourceBoxIndex = opSuperSourceBoxMaskTopMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxSizeMacroOp":
                    var opSuperSourceBoxSizeMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxSizeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxSize, Size = opSuperSourceBoxSizeMacroOp.Size, SuperSourceBoxIndex = opSuperSourceBoxSizeMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxXPositionMacroOp":
                    var opSuperSourceBoxXPositionMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxXPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxXPosition, PositionX = opSuperSourceBoxXPositionMacroOp.PositionX, SuperSourceBoxIndex = opSuperSourceBoxXPositionMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.SuperSource.SuperSourceBoxYPositionMacroOp":
                    var opSuperSourceBoxYPositionMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxYPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.SuperSourceBoxYPosition, PositionY = opSuperSourceBoxYPositionMacroOp.PositionY, SuperSourceBoxIndex = opSuperSourceBoxYPositionMacroOp.BoxIndex};
                case "LibAtem.MacroOperations.MixEffects.Transition.Dip.TransitionDipInputMacroOp":
                    var opTransitionDipInputMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Dip.TransitionDipInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionDipInput, Input = opTransitionDipInputMacroOp.Input.ToMacroInput(), MixEffectBlockIndex = opTransitionDipInputMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Dip.TransitionDipRateMacroOp":
                    var opTransitionDipRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Dip.TransitionDipRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionDipRate, Rate = opTransitionDipRateMacroOp.Rate, MixEffectBlockIndex = opTransitionDipRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.DVE.TransitionDVEPatternMacroOp":
                    var opTransitionDVEPatternMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.DVE.TransitionDVEPatternMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionDVEPattern, DVEEffectPattern = opTransitionDVEPatternMacroOp.Pattern, MixEffectBlockIndex = opTransitionDVEPatternMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.DVE.TransitionDVERateMacroOp":
                    var opTransitionDVERateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.DVE.TransitionDVERateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionDVERate, Rate = opTransitionDVERateMacroOp.Rate, MixEffectBlockIndex = opTransitionDVERateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp":
                    var opTransitionMixRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionMixRate, Rate = opTransitionMixRateMacroOp.Rate, MixEffectBlockIndex = opTransitionMixRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionPositionMacroOp":
                    var opTransitionPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionPosition, Position = opTransitionPositionMacroOp.Position, MixEffectBlockIndex = opTransitionPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionPreviewMacroOp":
                    var opTransitionPreviewMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionPreviewMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionPreview, Preview = opTransitionPreviewMacroOp.Preview.ToAtemBool(), MixEffectBlockIndex = opTransitionPreviewMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp":
                    var opTransitionSourceMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionSource, TransitionSource = opTransitionSourceMacroOp.Source, MixEffectBlockIndex = opTransitionSourceMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerClipDurationMacroOp":
                    var opTransitionStingerClipDurationMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerClipDurationMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerClipDuration, ClipDuration = opTransitionStingerClipDurationMacroOp.ClipDuration, MixEffectBlockIndex = opTransitionStingerClipDurationMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEClipMacroOp":
                    var opTransitionStingerDVEClipMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEClipMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerDVEClip, Clip = opTransitionStingerDVEClipMacroOp.Clip, MixEffectBlockIndex = opTransitionStingerDVEClipMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEGainMacroOp":
                    var opTransitionStingerDVEGainMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerDVEGain, Gain = opTransitionStingerDVEGainMacroOp.Gain, MixEffectBlockIndex = opTransitionStingerDVEGainMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEInvertMacroOp":
                    var opTransitionStingerDVEInvertMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEInvertMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerDVEInvert, Invert = opTransitionStingerDVEInvertMacroOp.Invert.ToAtemBool(), MixEffectBlockIndex = opTransitionStingerDVEInvertMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEPreMultiplyMacroOp":
                    var opTransitionStingerDVEPreMultiplyMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEPreMultiplyMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerDVEPreMultiply, PreMultiply = opTransitionStingerDVEPreMultiplyMacroOp.PreMultiply.ToAtemBool(), MixEffectBlockIndex = opTransitionStingerDVEPreMultiplyMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerMixRateMacroOp":
                    var opTransitionStingerMixRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerMixRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerMixRate, MixRate = opTransitionStingerMixRateMacroOp.MixRate, MixEffectBlockIndex = opTransitionStingerMixRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerPreRollMacroOp":
                    var opTransitionStingerPreRollMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerPreRollMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerPreRoll, PreRoll = opTransitionStingerPreRollMacroOp.Preroll, MixEffectBlockIndex = opTransitionStingerPreRollMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerRateMacroOp":
                    var opTransitionStingerRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerRate, Rate = opTransitionStingerRateMacroOp.Rate, MixEffectBlockIndex = opTransitionStingerRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerResetDurationsMacroOp":
                    var opTransitionStingerResetDurationsMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerResetDurationsMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerResetDurations, MixEffectBlockIndex = opTransitionStingerResetDurationsMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerSourceMediaPlayerMacroOp":
                    var opTransitionStingerSourceMediaPlayerMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerSourceMediaPlayerMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerSourceMediaPlayer, MediaPlayer = opTransitionStingerSourceMediaPlayerMacroOp.Source, MixEffectBlockIndex = opTransitionStingerSourceMediaPlayerMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerTriggerPointMacroOp":
                    var opTransitionStingerTriggerPointMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerTriggerPointMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerTriggerPoint, TriggerPoint = opTransitionStingerTriggerPointMacroOp.TriggerPoint, MixEffectBlockIndex = opTransitionStingerTriggerPointMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp":
                    var opTransitionStyleMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStyle, TransitionStyle = opTransitionStyleMacroOp.Style, MixEffectBlockIndex = opTransitionStyleMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeAndDVEFlipFlopMacroOp":
                    var opTransitionWipeAndDVEFlipFlopMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeAndDVEFlipFlopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeAndDVEFlipFlop, FlipFlop = opTransitionWipeAndDVEFlipFlopMacroOp.FlipFlop.ToAtemBool(), MixEffectBlockIndex = opTransitionWipeAndDVEFlipFlopMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeAndDVEReverseMacroOp":
                    var opTransitionWipeAndDVEReverseMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeAndDVEReverseMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeAndDVEReverse, Reverse = opTransitionWipeAndDVEReverseMacroOp.ReverseDirection.ToAtemBool(), MixEffectBlockIndex = opTransitionWipeAndDVEReverseMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderFillInputMacroOp":
                    var opTransitionWipeBorderFillInputMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderFillInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeBorderFillInput, Input = opTransitionWipeBorderFillInputMacroOp.Input.ToMacroInput(), MixEffectBlockIndex = opTransitionWipeBorderFillInputMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderSoftnessMacroOp":
                    var opTransitionWipeBorderSoftnessMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderSoftnessMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeBorderSoftness, Softness = opTransitionWipeBorderSoftnessMacroOp.BorderSoftness, MixEffectBlockIndex = opTransitionWipeBorderSoftnessMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderWidthMacroOp":
                    var opTransitionWipeBorderWidthMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderWidthMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeBorderWidth, Width = opTransitionWipeBorderWidthMacroOp.BorderWidth, MixEffectBlockIndex = opTransitionWipeBorderWidthMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipePatternMacroOp":
                    var opTransitionWipePatternMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipePatternMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipePattern, Pattern = opTransitionWipePatternMacroOp.Pattern, MixEffectBlockIndex = opTransitionWipePatternMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeRateMacroOp":
                    var opTransitionWipeRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeRate, Rate = opTransitionWipeRateMacroOp.Rate, MixEffectBlockIndex = opTransitionWipeRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeSymmetryMacroOp":
                    var opTransitionWipeSymmetryMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeSymmetryMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeSymmetry, Symmetry = opTransitionWipeSymmetryMacroOp.Symmetry, MixEffectBlockIndex = opTransitionWipeSymmetryMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeXPositionMacroOp":
                    var opTransitionWipeXPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeXPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeXPosition, PositionX = opTransitionWipeXPositionMacroOp.XPosition, MixEffectBlockIndex = opTransitionWipeXPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeYPositionMacroOp":
                    var opTransitionWipeYPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeYPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeYPosition, PositionY = opTransitionWipeYPositionMacroOp.YPosition, MixEffectBlockIndex = opTransitionWipeYPositionMacroOp.Index};
                case "LibAtem.MacroOperations.Settings.VideoModeMacroOp":
                    var opVideoModeMacroOp = (LibAtem.MacroOperations.Settings.VideoModeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.VideoMode, VideoMode = opVideoModeMacroOp.VideoMode};
                default:
                    throw new Exception(string.Format("Unknown type: {0}", op.Id));
            }
        }
    }

    public static class MacroOperationsExtensions
    {
        public static MacroOpBase ToMacroOp(this MacroOperation mac)
        {
            switch (mac.Id)
            {
                case MacroOperationType.AudioMixerInputGain:
                    return new LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp{Index = mac.Input.ToAudioSource(), Gain = mac.Gain};
                case MacroOperationType.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1:
                    return new LibAtem.MacroOperations.Audio.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp{Follow = mac.Follow.Value()};
                case MacroOperationType.AudioMixerMonitorOut:
                    return new LibAtem.MacroOperations.Audio.AudioMixerMonitorOutMacroOp{Enable = mac.Enable.Value()};
                case MacroOperationType.AutoTransition:
                    return new LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp{Index = mac.MixEffectBlockIndex};
                case MacroOperationType.AuxiliaryInput:
                    return new LibAtem.MacroOperations.AuxiliaryInputMacroOp{Index = mac.AuxiliaryIndex, Source = mac.Input.ToVideoSource()};
                case MacroOperationType.ChromaKeyClip:
                    return new LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyYSuppressMacroOp{YSuppress = mac.Clip, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyGain:
                    return new LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyGainMacroOp{Gain = mac.Gain, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyHue:
                    return new LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyHueMacroOp{Hue = mac.Hue, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyLift:
                    return new LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyLiftMacroOp{Lift = mac.Lift, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyNarrow:
                    return new LibAtem.MacroOperations.MixEffects.Key.Chroma.ChromaKeyNarrowMacroOp{Narrow = mac.Narrow.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ColorGeneratorHue:
                    return new LibAtem.MacroOperations.ColorGeneratorHueMacroOp{ColorGeneratorIndex = mac.ColorGeneratorIndex, Hue = mac.Hue};
                case MacroOperationType.ColorGeneratorLuminescence:
                    return new LibAtem.MacroOperations.ColorGeneratorLuminescenceMacroOp{ColorGeneratorIndex = mac.ColorGeneratorIndex, Luma = mac.Luminescence};
                case MacroOperationType.ColorGeneratorSaturation:
                    return new LibAtem.MacroOperations.ColorGeneratorSaturationMacroOp{ColorGeneratorIndex = mac.ColorGeneratorIndex, Saturation = mac.Saturation};
                case MacroOperationType.CutTransition:
                    return new LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp{Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DownConvertMode:
                    return new LibAtem.MacroOperations.Settings.DownConvertModeMacroOp{DownConvertMode = mac.DownConvertMode};
                case MacroOperationType.DownstreamKeyAuto:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyAutoMacroOp{KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyClip:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyClipMacroOp{Clip = mac.Clip, KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyCutInput:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyCutInputMacroOp{Input = mac.Input.ToVideoSource(), KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyFillInput:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyFillInputMacroOp{Input = mac.Input.ToVideoSource(), KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyGain:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyGainMacroOp{Gain = mac.Gain, KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyInvert:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyInvertMacroOp{Invert = mac.Invert.Value(), KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyMaskBottom:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskBottomMacroOp{Bottom = mac.Bottom, KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyMaskEnable:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyMaskLeft:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskLeftMacroOp{Left = mac.Left, KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyMaskRight:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskRightMacroOp{Right = mac.Right, KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyMaskTop:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskTopMacroOp{Top = mac.Top, KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyOnAir:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyOnAirMacroOp{OnAir = mac.OnAir.Value(), KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyPreMultiply:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyPreMultiplyMacroOp{PreMultiply = mac.PreMultiply.Value(), KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyRate:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyRateMacroOp{Rate = mac.Rate, KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DownstreamKeyTie:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyTieMacroOp{Tie = mac.Tie.Value(), KeyIndex = mac.DownstreamKeyIndex};
                case MacroOperationType.DVEAndFlyKeyRate:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyRateMacroOp{Rate = mac.Rate, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyRotation:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyRotationMacroOp{Rotation = mac.Rotation, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyXPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyXPositionMacroOp{PositionX = mac.PositionX, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyXSize:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyXSizeMacroOp{SizeX = mac.SizeX, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyYPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyYPositionMacroOp{PositionY = mac.PositionY, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyYSize:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEAndFlyKeyYSizeMacroOp{SizeY = mac.SizeY, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderBevel:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelMacroOp{Bevel = mac.Bevel, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderBevelPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelPositionMacroOp{BevelPosition = mac.BevelPosition, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderBevelSoftness:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderBevelSoftnessMacroOp{BevelSoftness = mac.BevelSoftness, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderHue:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderHueMacroOp{Hue = mac.Hue, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderInnerSoftness:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderInnerSoftnessMacroOp{InnerSoftness = mac.InnerSoftness, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderInnerWidth:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderInnerWidthMacroOp{InnerWidth = mac.InnerWidth, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderLuminescence:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderLuminescenceMacroOp{Luma = mac.Luma, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderOpacity:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOpacityMacroOp{Opacity = mac.Opacity, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderOuterSoftness:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOuterSoftnessMacroOp{OuterSoftness = mac.OuterSoftness, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderOuterWidth:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderOuterWidthMacroOp{OuterWidth = mac.OuterWidth, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderSaturation:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyBorderSaturationMacroOp{Saturation = mac.Saturation, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskBottom:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskBottomMacroOp{Bottom = mac.Bottom, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskLeft:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskLeftMacroOp{Left = mac.Left, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskRight:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskRightMacroOp{Right = mac.Right, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskTop:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyMaskTopMacroOp{Top = mac.Top, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyShadowAltitude:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowAltitudeMacroOp{Altitude = mac.Altitude, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyShadowDirection:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowDirectionMacroOp{Direction = mac.Direction, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyShadowEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.DVEKeyShadowEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FadeToBlackAuto:
                    return new LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp{Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FadeToBlackRate:
                    return new LibAtem.MacroOperations.MixEffects.FadeToBlackRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FlyKeyRunToFull:
                    return new LibAtem.MacroOperations.MixEffects.Key.FlyKeyRunToAllMacroOp{KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FlyKeyRunToInfinity:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.FlyKeyRunToInfinityMacroOp{Location = mac.Location, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FlyKeyRunToKeyFrame:
                    return new LibAtem.MacroOperations.MixEffects.Key.FlyKeyRunToKeyFrameMacroOp{KeyFrameIndex = mac.KeyFrameIndex, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FlyKeySetKeyFrame:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVE.FlyKeySetKeyFrameMacroOp{KeyFrameIndex = mac.KeyFrameIndex, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.HyperDeckPlay:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp{Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetLoop:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp{Loop = mac.HyperDeckLoopEnabled.Value(), Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetRollOnTakeFrameDelay:
                    return new LibAtem.MacroOperations.Audio.AudioMixerAfvFollowTransitionMacroOp{Enable = mac.Enable.Value()};
                case MacroOperationType.HyperDeckSetSingleClip:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetSingleClipMacroOp{SingleClipEnabled = mac.HyperDeckSingleClipEnabled.Value(), Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetSourceClipIndex:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetSourceClipIndexMacroOp{ClipIndex = mac.HyperDeckClipIndex, Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetSpeed:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetSpeedMacroOp{SpeedPercent = mac.HyperDeckSpeedPercent, Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckStop:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckStopMacroOp{Index = mac.HyperDeckIndex};
                case MacroOperationType.InputVideoPort:
                    return new LibAtem.MacroOperations.Settings.InputVideoPortMacroOp{Source = mac.Input.ToVideoSource(), Port = mac.VideoPort};
                case MacroOperationType.KeyCutInput:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp{Source = mac.Input.ToVideoSource(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyFillInput:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp{Source = mac.Input.ToVideoSource(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyFlyEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyFlyEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskBottom:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskBottomMacroOp{Bottom = mac.Bottom, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskLeft:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskLeftMacroOp{Left = mac.Left, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskRight:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskRightMacroOp{Right = mac.Right, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskTop:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskTopMacroOp{Top = mac.Top, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyOnAir:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyOnAirMacroOp{OnAir = mac.OnAir.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyType:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyTypeMacroOp{KeyType = mac.KeyType, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.LumaKeyClip:
                    return new LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyClipMacroOp{Clip = mac.Clip, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.LumaKeyGain:
                    return new LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyGainMacroOp{Gain = mac.Gain, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.LumaKeyInvert:
                    return new LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyInvertMacroOp{Invert = mac.Invert.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.LumaKeyPreMultiply:
                    return new LibAtem.MacroOperations.MixEffects.Key.Luma.LumaKeyPreMultiplyMacroOp{PreMultiply = mac.PreMultiply.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.MacroSleep:
                    return new LibAtem.MacroOperations.MacroSleepMacroOp{Frames = mac.Frames};
                case MacroOperationType.MediaPlayerGoToBeginning:
                    return new LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerLoop:
                    return new LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp{Loop = mac.Loop.Value(), Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerPlay:
                    return new LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceClip:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceClipIndex:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp{MediaIndex = mac.Index, Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceStill:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceStillIndex:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp{MediaIndex = mac.Index, Index = mac.MediaPlayerIndex};
                case MacroOperationType.MultiViewLayout:
                    return new LibAtem.MacroOperations.Settings.MultiViewLayoutMacroOp{MultiViewIndex = mac.MultiViewIndex, Layout = mac.Layout};
                case MacroOperationType.MultiViewWindowInput:
                    return new LibAtem.MacroOperations.Settings.MultiViewWindowInputMacroOp{MultiViewIndex = mac.MultiViewIndex, WindowIndex = mac.WindowIndex, Source = mac.Input.ToVideoSource()};
                case MacroOperationType.PatternKeyPattern:
                    return new LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyPatternMacroOp{Pattern = mac.PatternKeyPattern, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeySize:
                    return new LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySizeMacroOp{Size = mac.Size, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeySoftness:
                    return new LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySoftnessMacroOp{Softness = mac.Softness, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeySymmetry:
                    return new LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeySymmetryMacroOp{Symmetry = mac.Symmetry, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeyXPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyXPositionMacroOp{XPosition = mac.PositionX, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeyYPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.Pattern.PatternKeyYPositionMacroOp{YPosition = mac.PositionY, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PreviewInput:
                    return new LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp{Source = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ProgramInput:
                    return new LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp{Source = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.SetSerialPortFunction:
                    return new LibAtem.MacroOperations.Settings.SetSerialPortFunctionMacroOp{ExternalSerialPortIndex = mac.ExternalSerialPortIndex, SerialMode = mac.Function};
                case MacroOperationType.SuperSourceArtAbove:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceArtAboveMacroOp{ArtAbove = mac.SuperSourceArtAbove.Value()};
                case MacroOperationType.SuperSourceArtCutInput:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceArtCutInputMacroOp{Source = mac.Input.ToVideoSource()};
                case MacroOperationType.SuperSourceArtFillInput:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceArtFillInputMacroOp{Source = mac.Input.ToVideoSource()};
                case MacroOperationType.SuperSourceBorderEnable:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBorderEnableMacroOp{Enable = mac.Enable.Value()};
                case MacroOperationType.SuperSourceBoxEnable:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxEnableMacroOp{Enable = mac.Enable.Value(), BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxInput:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxInputMacroOp{Source = mac.Input.ToVideoSource(), BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxMaskBottom:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskBottomMacroOp{Bottom = mac.Bottom, BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxMaskEnable:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskEnableMacroOp{Enable = mac.Enable.Value(), BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxMaskLeft:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskLeftMacroOp{Left = mac.Left, BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxMaskRight:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskRightMacroOp{Right = mac.Right, BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxMaskTop:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskTopMacroOp{Top = mac.Top, BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxSize:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxSizeMacroOp{Size = mac.Size, BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxXPosition:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxXPositionMacroOp{PositionX = mac.PositionX, BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.SuperSourceBoxYPosition:
                    return new LibAtem.MacroOperations.SuperSource.SuperSourceBoxYPositionMacroOp{PositionY = mac.PositionY, BoxIndex = mac.SuperSourceBoxIndex};
                case MacroOperationType.TransitionDipInput:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Dip.TransitionDipInputMacroOp{Input = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionDipRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Dip.TransitionDipRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionDVEPattern:
                    return new LibAtem.MacroOperations.MixEffects.Transition.DVE.TransitionDVEPatternMacroOp{Pattern = mac.DVEEffectPattern, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionDVERate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.DVE.TransitionDVERateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionMixRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionPosition:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionPositionMacroOp{Position = mac.Position, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionPreview:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionPreviewMacroOp{Preview = mac.Preview.Value(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionSource:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp{Source = mac.TransitionSource, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerClipDuration:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerClipDurationMacroOp{ClipDuration = mac.ClipDuration, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerDVEClip:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEClipMacroOp{Clip = mac.Clip, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerDVEGain:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEGainMacroOp{Gain = mac.Gain, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerDVEInvert:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEInvertMacroOp{Invert = mac.Invert.Value(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerDVEPreMultiply:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerDVEPreMultiplyMacroOp{PreMultiply = mac.PreMultiply.Value(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerMixRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerMixRateMacroOp{MixRate = mac.MixRate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerPreRoll:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerPreRollMacroOp{Preroll = mac.PreRoll, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerResetDurations:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerResetDurationsMacroOp{Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerSourceMediaPlayer:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerSourceMediaPlayerMacroOp{Source = mac.MediaPlayer, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerTriggerPoint:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Stinger.TransitionStingerTriggerPointMacroOp{TriggerPoint = mac.TriggerPoint, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStyle:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp{Style = mac.TransitionStyle, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeAndDVEFlipFlop:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeAndDVEFlipFlopMacroOp{FlipFlop = mac.FlipFlop.Value(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeAndDVEReverse:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeAndDVEReverseMacroOp{ReverseDirection = mac.Reverse.Value(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeBorderFillInput:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderFillInputMacroOp{Input = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeBorderSoftness:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderSoftnessMacroOp{BorderSoftness = mac.Softness, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeBorderWidth:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeBorderWidthMacroOp{BorderWidth = mac.Width, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipePattern:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipePatternMacroOp{Pattern = mac.Pattern, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeSymmetry:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeSymmetryMacroOp{Symmetry = mac.Symmetry, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeXPosition:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeXPositionMacroOp{XPosition = mac.PositionX, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeYPosition:
                    return new LibAtem.MacroOperations.MixEffects.Transition.Wipe.TransitionWipeYPositionMacroOp{YPosition = mac.PositionY, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.VideoMode:
                    return new LibAtem.MacroOperations.Settings.VideoModeMacroOp{VideoMode = mac.VideoMode};
                default:
                    throw new Exception(string.Format("Unknown type: {0}", mac.Id));
            }
        }
    }
}