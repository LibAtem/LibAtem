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
                case MacroOperationType.SuperSourceBoxMaskBottom:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.DownstreamKeyMaskBottom:
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
                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.DownstreamKeyClip:
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
                case MacroOperationType.SuperSourceBorderEnable:
                case MacroOperationType.SuperSourceBoxEnable:
                case MacroOperationType.SuperSourceBoxMaskEnable:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.KeyFlyEnable:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.DownstreamKeyMaskEnable:
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
                case MacroOperationType.ChromaKeyGain:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.DownstreamKeyGain:
                case MacroOperationType.AudioMixerInputGain:
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
                case MacroOperationType.ColorGeneratorHue:
                case MacroOperationType.ChromaKeyHue:
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
                case MacroOperationType.AuxiliaryInput:
                case MacroOperationType.SuperSourceArtCutInput:
                case MacroOperationType.SuperSourceArtFillInput:
                case MacroOperationType.SuperSourceBoxInput:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.DownstreamKeyCutInput:
                case MacroOperationType.DownstreamKeyFillInput:
                case MacroOperationType.AudioMixerInputGain:
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
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.DownstreamKeyInvert:
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
                case MacroOperationType.ChromaKeyGain:
                case MacroOperationType.ChromaKeyHue:
                case MacroOperationType.ChromaKeyLift:
                case MacroOperationType.ChromaKeyNarrow:
                case MacroOperationType.ChromaKeyClip:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyShadowAltitude:
                case MacroOperationType.DVEKeyShadowDirection:
                case MacroOperationType.DVEKeyShadowEnable:
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
                case MacroOperationType.SuperSourceBoxMaskLeft:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.DownstreamKeyMaskLeft:
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
        public LibAtem.Common.MediaPlayerId MediaPlayerIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeMediaPlayerIndex()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerGoToBeginning:
                case MacroOperationType.MediaPlayerLoop:
                case MacroOperationType.MediaPlayerPlay:
                case MacroOperationType.MediaPlayerSourceClipIndex:
                case MacroOperationType.MediaPlayerSourceClip:
                case MacroOperationType.MediaPlayerSourceStillIndex:
                case MacroOperationType.MediaPlayerSourceStill:
                    return true;
                default:
                    return false;
            }
        }

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
                case MacroOperationType.CutTransition:
                case MacroOperationType.FadeToBlackAuto:
                case MacroOperationType.FadeToBlackRate:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionDVEPattern:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionSource:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionStyle:
                case MacroOperationType.TransitionWipeRate:
                case MacroOperationType.ChromaKeyGain:
                case MacroOperationType.ChromaKeyHue:
                case MacroOperationType.ChromaKeyLift:
                case MacroOperationType.ChromaKeyNarrow:
                case MacroOperationType.ChromaKeyClip:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyShadowAltitude:
                case MacroOperationType.DVEKeyShadowDirection:
                case MacroOperationType.DVEKeyShadowEnable:
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
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.DownstreamKeyOnAir:
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
                case MacroOperationType.TransitionDVEPattern:
                case MacroOperationType.PatternKeyPattern:
                    return true;
                default:
                    return false;
            }
        }

        [XmlIgnore]
        public LibAtem.Common.DVEEffect DVEEffectPattern
        {
            get => (LibAtem.Common.DVEEffect)Enum.Parse(typeof (LibAtem.Common.DVEEffect), PatternString) ; set => PatternString = value.ToString() ; }

        [XmlIgnore]
        public LibAtem.Common.Pattern PatternKeyPattern
        {
            get => (LibAtem.Common.Pattern)Enum.Parse(typeof (LibAtem.Common.Pattern), PatternString) ; set => PatternString = value.ToString() ; }

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
                case MacroOperationType.LumaKeyPreMultiply:
                case MacroOperationType.DownstreamKeyPreMultiply:
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
                case MacroOperationType.FadeToBlackRate:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionWipeRate:
                case MacroOperationType.DownstreamKeyRate:
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
                case MacroOperationType.SuperSourceBoxMaskRight:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.DownstreamKeyMaskRight:
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
                case MacroOperationType.SuperSourceBoxSize:
                case MacroOperationType.PatternKeySize:
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
                case MacroOperationType.SuperSourceBoxMaskTop:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.DownstreamKeyMaskTop:
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
                case MacroOperationType.SuperSourceBoxXPosition:
                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.PatternKeyXPosition:
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
                case MacroOperationType.SuperSourceBoxYPosition:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.PatternKeyYPosition:
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
                case "LibAtem.MacroOperations.AuxiliaryInputMacroOp":
                    var opAuxiliaryInputMacroOp = (LibAtem.MacroOperations.AuxiliaryInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AuxiliaryInput, AuxiliaryIndex = opAuxiliaryInputMacroOp.Index, Input = opAuxiliaryInputMacroOp.Source.ToMacroInput()};
                case "LibAtem.MacroOperations.ColorGeneratorHueMacroOp":
                    var opColorGeneratorHueMacroOp = (LibAtem.MacroOperations.ColorGeneratorHueMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ColorGeneratorHue, ColorGeneratorIndex = opColorGeneratorHueMacroOp.ColorGeneratorIndex, Hue = opColorGeneratorHueMacroOp.Hue};
                case "LibAtem.MacroOperations.ColorGeneratorLuminescenceMacroOp":
                    var opColorGeneratorLuminescenceMacroOp = (LibAtem.MacroOperations.ColorGeneratorLuminescenceMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ColorGeneratorLuminescence, ColorGeneratorIndex = opColorGeneratorLuminescenceMacroOp.ColorGeneratorIndex, Luminescence = opColorGeneratorLuminescenceMacroOp.Luma};
                case "LibAtem.MacroOperations.ColorGeneratorSaturationMacroOp":
                    var opColorGeneratorSaturationMacroOp = (LibAtem.MacroOperations.ColorGeneratorSaturationMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ColorGeneratorSaturation, ColorGeneratorIndex = opColorGeneratorSaturationMacroOp.ColorGeneratorIndex, Saturation = opColorGeneratorSaturationMacroOp.Saturation};
                case "LibAtem.MacroOperations.MacroSleepMacroOp":
                    var opMacroSleepMacroOp = (LibAtem.MacroOperations.MacroSleepMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MacroSleep, Frames = opMacroSleepMacroOp.Frames};
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
                case "LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp":
                    var opAutoTransitionMacroOp = (LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AutoTransition, MixEffectBlockIndex = opAutoTransitionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp":
                    var opCutTransitionMacroOp = (LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.CutTransition, MixEffectBlockIndex = opCutTransitionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp":
                    var opFadeToBlackAutoMacroOp = (LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FadeToBlackAuto, MixEffectBlockIndex = opFadeToBlackAutoMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.FadeToBlackRateMacroOp":
                    var opFadeToBlackRateMacroOp = (LibAtem.MacroOperations.MixEffects.FadeToBlackRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.FadeToBlackRate, Rate = opFadeToBlackRateMacroOp.Rate, MixEffectBlockIndex = opFadeToBlackRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp":
                    var opPreviewInputMacroOp = (LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PreviewInput, Input = opPreviewInputMacroOp.Source.ToMacroInput(), MixEffectBlockIndex = opPreviewInputMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp":
                    var opProgramInputMacroOp = (LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ProgramInput, Input = opProgramInputMacroOp.Source.ToMacroInput(), MixEffectBlockIndex = opProgramInputMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionDipRateMacroOp":
                    var opTransitionDipRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionDipRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionDipRate, Rate = opTransitionDipRateMacroOp.Rate, MixEffectBlockIndex = opTransitionDipRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionDVEPatternMacroOp":
                    var opTransitionDVEPatternMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionDVEPatternMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionDVEPattern, DVEEffectPattern = opTransitionDVEPatternMacroOp.Pattern, MixEffectBlockIndex = opTransitionDVEPatternMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionDVERateMacroOp":
                    var opTransitionDVERateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionDVERateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionDVERate, Rate = opTransitionDVERateMacroOp.Rate, MixEffectBlockIndex = opTransitionDVERateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp":
                    var opTransitionMixRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionMixRate, Rate = opTransitionMixRateMacroOp.Rate, MixEffectBlockIndex = opTransitionMixRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp":
                    var opTransitionSourceMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionSource, TransitionSource = opTransitionSourceMacroOp.Source, MixEffectBlockIndex = opTransitionSourceMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerMixRateMacroOp":
                    var opTransitionStingerMixRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerMixRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerMixRate, Rate = opTransitionStingerMixRateMacroOp.Rate, MixEffectBlockIndex = opTransitionStingerMixRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerRateMacroOp":
                    var opTransitionStingerRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStingerRate, Rate = opTransitionStingerRateMacroOp.Rate, MixEffectBlockIndex = opTransitionStingerRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp":
                    var opTransitionStyleMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionStyle, TransitionStyle = opTransitionStyleMacroOp.Style, MixEffectBlockIndex = opTransitionStyleMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Transition.TransitionWipeRateMacroOp":
                    var opTransitionWipeRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionWipeRateMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.TransitionWipeRate, Rate = opTransitionWipeRateMacroOp.Rate, MixEffectBlockIndex = opTransitionWipeRateMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.ChromaKeyGainMacroOp":
                    var opChromaKeyGainMacroOp = (LibAtem.MacroOperations.MixEffects.Key.ChromaKeyGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyGain, Gain = opChromaKeyGainMacroOp.Gain, UpstreamKeyIndex = opChromaKeyGainMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyGainMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.ChromaKeyHueMacroOp":
                    var opChromaKeyHueMacroOp = (LibAtem.MacroOperations.MixEffects.Key.ChromaKeyHueMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyHue, Hue = opChromaKeyHueMacroOp.Hue, UpstreamKeyIndex = opChromaKeyHueMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyHueMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.ChromaKeyLiftMacroOp":
                    var opChromaKeyLiftMacroOp = (LibAtem.MacroOperations.MixEffects.Key.ChromaKeyLiftMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyLift, Lift = opChromaKeyLiftMacroOp.Lift, UpstreamKeyIndex = opChromaKeyLiftMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyLiftMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.ChromaKeyNarrowMacroOp":
                    var opChromaKeyNarrowMacroOp = (LibAtem.MacroOperations.MixEffects.Key.ChromaKeyNarrowMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyNarrow, Narrow = opChromaKeyNarrowMacroOp.Narrow.ToAtemBool(), UpstreamKeyIndex = opChromaKeyNarrowMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyNarrowMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.ChromaKeyYSuppressMacroOp":
                    var opChromaKeyYSuppressMacroOp = (LibAtem.MacroOperations.MixEffects.Key.ChromaKeyYSuppressMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.ChromaKeyClip, Clip = opChromaKeyYSuppressMacroOp.YSuppress, UpstreamKeyIndex = opChromaKeyYSuppressMacroOp.KeyIndex, MixEffectBlockIndex = opChromaKeyYSuppressMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyRotationMacroOp":
                    var opDVEAndFlyKeyRotationMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyRotationMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyRotation, Rotation = opDVEAndFlyKeyRotationMacroOp.Rotation, UpstreamKeyIndex = opDVEAndFlyKeyRotationMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyRotationMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXPositionMacroOp":
                    var opDVEAndFlyKeyXPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyXPosition, PositionX = opDVEAndFlyKeyXPositionMacroOp.PositionX, UpstreamKeyIndex = opDVEAndFlyKeyXPositionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyXPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXSizeMacroOp":
                    var opDVEAndFlyKeyXSizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXSizeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyXSize, SizeX = opDVEAndFlyKeyXSizeMacroOp.SizeX, UpstreamKeyIndex = opDVEAndFlyKeyXSizeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyXSizeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYPositionMacroOp":
                    var opDVEAndFlyKeyYPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyYPosition, PositionY = opDVEAndFlyKeyYPositionMacroOp.PositionY, UpstreamKeyIndex = opDVEAndFlyKeyYPositionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyYPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYSizeMacroOp":
                    var opDVEAndFlyKeyYSizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYSizeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEAndFlyKeyYSize, SizeY = opDVEAndFlyKeyYSizeMacroOp.SizeY, UpstreamKeyIndex = opDVEAndFlyKeyYSizeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyYSizeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyBorderEnableMacroOp":
                    var opDVEKeyBorderEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyBorderEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyBorderEnable, Enable = opDVEKeyBorderEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opDVEKeyBorderEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderEnableMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskBottomMacroOp":
                    var opDVEKeyMaskBottomMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskBottomMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskBottom, Bottom = opDVEKeyMaskBottomMacroOp.Bottom, UpstreamKeyIndex = opDVEKeyMaskBottomMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskBottomMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskEnableMacroOp":
                    var opDVEKeyMaskEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskEnable, Enable = opDVEKeyMaskEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opDVEKeyMaskEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskEnableMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskLeftMacroOp":
                    var opDVEKeyMaskLeftMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskLeftMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskLeft, Left = opDVEKeyMaskLeftMacroOp.Left, UpstreamKeyIndex = opDVEKeyMaskLeftMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskLeftMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskRightMacroOp":
                    var opDVEKeyMaskRightMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskRightMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskRight, Right = opDVEKeyMaskRightMacroOp.Right, UpstreamKeyIndex = opDVEKeyMaskRightMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskRightMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskTopMacroOp":
                    var opDVEKeyMaskTopMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskTopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyMaskTop, Top = opDVEKeyMaskTopMacroOp.Top, UpstreamKeyIndex = opDVEKeyMaskTopMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskTopMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowAltitudeMacroOp":
                    var opDVEKeyShadowAltitudeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowAltitudeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyShadowAltitude, Altitude = opDVEKeyShadowAltitudeMacroOp.Altitude, UpstreamKeyIndex = opDVEKeyShadowAltitudeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyShadowAltitudeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowDirectionMacroOp":
                    var opDVEKeyShadowDirectionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowDirectionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyShadowDirection, Direction = opDVEKeyShadowDirectionMacroOp.Direction, UpstreamKeyIndex = opDVEKeyShadowDirectionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyShadowDirectionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowEnableMacroOp":
                    var opDVEKeyShadowEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowEnableMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.DVEKeyShadowEnable, Enable = opDVEKeyShadowEnableMacroOp.Enable.ToAtemBool(), UpstreamKeyIndex = opDVEKeyShadowEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyShadowEnableMacroOp.Index};
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
                case "LibAtem.MacroOperations.MixEffects.Key.LumaKeyClipMacroOp":
                    var opLumaKeyClipMacroOp = (LibAtem.MacroOperations.MixEffects.Key.LumaKeyClipMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyClip, Clip = opLumaKeyClipMacroOp.Clip, UpstreamKeyIndex = opLumaKeyClipMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyClipMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.LumaKeyGainMacroOp":
                    var opLumaKeyGainMacroOp = (LibAtem.MacroOperations.MixEffects.Key.LumaKeyGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyGain, Gain = opLumaKeyGainMacroOp.Gain, UpstreamKeyIndex = opLumaKeyGainMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyGainMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.LumaKeyInvertMacroOp":
                    var opLumaKeyInvertMacroOp = (LibAtem.MacroOperations.MixEffects.Key.LumaKeyInvertMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyInvert, Invert = opLumaKeyInvertMacroOp.Invert.ToAtemBool(), UpstreamKeyIndex = opLumaKeyInvertMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyInvertMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.LumaKeyPreMultiplyMacroOp":
                    var opLumaKeyPreMultiplyMacroOp = (LibAtem.MacroOperations.MixEffects.Key.LumaKeyPreMultiplyMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.LumaKeyPreMultiply, PreMultiply = opLumaKeyPreMultiplyMacroOp.PreMultiply.ToAtemBool(), UpstreamKeyIndex = opLumaKeyPreMultiplyMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyPreMultiplyMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.PatternKeyPatternMacroOp":
                    var opPatternKeyPatternMacroOp = (LibAtem.MacroOperations.MixEffects.Key.PatternKeyPatternMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeyPattern, PatternKeyPattern = opPatternKeyPatternMacroOp.Pattern, UpstreamKeyIndex = opPatternKeyPatternMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeyPatternMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.PatternKeySizeMacroOp":
                    var opPatternKeySizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.PatternKeySizeMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeySize, Size = opPatternKeySizeMacroOp.Size, UpstreamKeyIndex = opPatternKeySizeMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeySizeMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.PatternKeySoftnessMacroOp":
                    var opPatternKeySoftnessMacroOp = (LibAtem.MacroOperations.MixEffects.Key.PatternKeySoftnessMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeySoftness, Softness = opPatternKeySoftnessMacroOp.Softness, UpstreamKeyIndex = opPatternKeySoftnessMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeySoftnessMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.PatternKeySymmetryMacroOp":
                    var opPatternKeySymmetryMacroOp = (LibAtem.MacroOperations.MixEffects.Key.PatternKeySymmetryMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeySymmetry, Symmetry = opPatternKeySymmetryMacroOp.Symmetry, UpstreamKeyIndex = opPatternKeySymmetryMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeySymmetryMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.PatternKeyXPositionMacroOp":
                    var opPatternKeyXPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.PatternKeyXPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeyXPosition, PositionX = opPatternKeyXPositionMacroOp.XPosition, UpstreamKeyIndex = opPatternKeyXPositionMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeyXPositionMacroOp.Index};
                case "LibAtem.MacroOperations.MixEffects.Key.PatternKeyYPositionMacroOp":
                    var opPatternKeyYPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.PatternKeyYPositionMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.PatternKeyYPosition, PositionY = opPatternKeyYPositionMacroOp.YPosition, UpstreamKeyIndex = opPatternKeyYPositionMacroOp.KeyIndex, MixEffectBlockIndex = opPatternKeyYPositionMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp":
                    var opMediaPlayerGoToBeginningMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerGoToBeginning, MediaPlayerIndex = opMediaPlayerGoToBeginningMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp":
                    var opMediaPlayerLoopMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerLoop, Loop = opMediaPlayerLoopMacroOp.Loop.ToAtemBool(), MediaPlayerIndex = opMediaPlayerLoopMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp":
                    var opMediaPlayerPlayMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerPlay, MediaPlayerIndex = opMediaPlayerPlayMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp":
                    var opMediaPlayerSourceClipIndexMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceClipIndex, Index = opMediaPlayerSourceClipIndexMacroOp.MediaIndex, MediaPlayerIndex = opMediaPlayerSourceClipIndexMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp":
                    var opMediaPlayerSourceClipMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceClip, MediaPlayerIndex = opMediaPlayerSourceClipMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp":
                    var opMediaPlayerSourceStillIndexMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceStillIndex, Index = opMediaPlayerSourceStillIndexMacroOp.MediaIndex, MediaPlayerIndex = opMediaPlayerSourceStillIndexMacroOp.Index};
                case "LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp":
                    var opMediaPlayerSourceStillMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.MediaPlayerSourceStill, MediaPlayerIndex = opMediaPlayerSourceStillMacroOp.Index};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp":
                    var opHyperDeckPlayMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckPlay, HyperDeckIndex = opHyperDeckPlayMacroOp.Index};
                case "LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp":
                    var opHyperDeckSetLoopMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.HyperDeckSetLoop, HyperDeckLoopEnabled = opHyperDeckSetLoopMacroOp.Loop.ToAtemBool(), HyperDeckIndex = opHyperDeckSetLoopMacroOp.Index};
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
                case "LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp":
                    var opAudioMixerInputGainMacroOp = (LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AudioMixerInputGain, Input = opAudioMixerInputGainMacroOp.Index.ToMacroInput(), Gain = opAudioMixerInputGainMacroOp.Gain};
                case "LibAtem.MacroOperations.Audio.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp":
                    var opAudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp = (LibAtem.MacroOperations.Audio.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp)op;
                    return new MacroOperation{Id = MacroOperationType.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1, Follow = opAudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp.Follow.ToAtemBool()};
                default:
                    throw new Exception(string.Format("Unknown type: {0}", op.Id));
            }
        }
    }

    public static class MacroOperationsExtensions
    {
        public static IMacroOperation ToMacroOp(this MacroOperation mac)
        {
            switch (mac.Id)
            {
                case MacroOperationType.AuxiliaryInput:
                    return new LibAtem.MacroOperations.AuxiliaryInputMacroOp{Index = mac.AuxiliaryIndex, Source = mac.Input.ToVideoSource()};
                case MacroOperationType.ColorGeneratorHue:
                    return new LibAtem.MacroOperations.ColorGeneratorHueMacroOp{ColorGeneratorIndex = mac.ColorGeneratorIndex, Hue = mac.Hue};
                case MacroOperationType.ColorGeneratorLuminescence:
                    return new LibAtem.MacroOperations.ColorGeneratorLuminescenceMacroOp{ColorGeneratorIndex = mac.ColorGeneratorIndex, Luma = mac.Luminescence};
                case MacroOperationType.ColorGeneratorSaturation:
                    return new LibAtem.MacroOperations.ColorGeneratorSaturationMacroOp{ColorGeneratorIndex = mac.ColorGeneratorIndex, Saturation = mac.Saturation};
                case MacroOperationType.MacroSleep:
                    return new LibAtem.MacroOperations.MacroSleepMacroOp{Frames = mac.Frames};
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
                case MacroOperationType.AutoTransition:
                    return new LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp{Index = mac.MixEffectBlockIndex};
                case MacroOperationType.CutTransition:
                    return new LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp{Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FadeToBlackAuto:
                    return new LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp{Index = mac.MixEffectBlockIndex};
                case MacroOperationType.FadeToBlackRate:
                    return new LibAtem.MacroOperations.MixEffects.FadeToBlackRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PreviewInput:
                    return new LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp{Source = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ProgramInput:
                    return new LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp{Source = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionDipRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionDipRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionDVEPattern:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionDVEPatternMacroOp{Pattern = mac.DVEEffectPattern, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionDVERate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionDVERateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionMixRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionSource:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp{Source = mac.TransitionSource, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerMixRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerMixRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStingerRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionStyle:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp{Style = mac.TransitionStyle, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionWipeRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionWipeRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyGain:
                    return new LibAtem.MacroOperations.MixEffects.Key.ChromaKeyGainMacroOp{Gain = mac.Gain, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyHue:
                    return new LibAtem.MacroOperations.MixEffects.Key.ChromaKeyHueMacroOp{Hue = mac.Hue, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyLift:
                    return new LibAtem.MacroOperations.MixEffects.Key.ChromaKeyLiftMacroOp{Lift = mac.Lift, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyNarrow:
                    return new LibAtem.MacroOperations.MixEffects.Key.ChromaKeyNarrowMacroOp{Narrow = mac.Narrow.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ChromaKeyClip:
                    return new LibAtem.MacroOperations.MixEffects.Key.ChromaKeyYSuppressMacroOp{YSuppress = mac.Clip, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyRotation:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyRotationMacroOp{Rotation = mac.Rotation, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyXPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXPositionMacroOp{PositionX = mac.PositionX, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyXSize:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXSizeMacroOp{SizeX = mac.SizeX, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyYPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYPositionMacroOp{PositionY = mac.PositionY, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyYSize:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYSizeMacroOp{SizeY = mac.SizeY, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyBorderEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskBottom:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskBottomMacroOp{Bottom = mac.Bottom, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskLeft:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskLeftMacroOp{Left = mac.Left, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskRight:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskRightMacroOp{Right = mac.Right, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskTop:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskTopMacroOp{Top = mac.Top, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyShadowAltitude:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowAltitudeMacroOp{Altitude = mac.Altitude, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyShadowDirection:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowDirectionMacroOp{Direction = mac.Direction, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyShadowEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
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
                    return new LibAtem.MacroOperations.MixEffects.Key.LumaKeyClipMacroOp{Clip = mac.Clip, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.LumaKeyGain:
                    return new LibAtem.MacroOperations.MixEffects.Key.LumaKeyGainMacroOp{Gain = mac.Gain, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.LumaKeyInvert:
                    return new LibAtem.MacroOperations.MixEffects.Key.LumaKeyInvertMacroOp{Invert = mac.Invert.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.LumaKeyPreMultiply:
                    return new LibAtem.MacroOperations.MixEffects.Key.LumaKeyPreMultiplyMacroOp{PreMultiply = mac.PreMultiply.Value(), KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeyPattern:
                    return new LibAtem.MacroOperations.MixEffects.Key.PatternKeyPatternMacroOp{Pattern = mac.PatternKeyPattern, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeySize:
                    return new LibAtem.MacroOperations.MixEffects.Key.PatternKeySizeMacroOp{Size = mac.Size, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeySoftness:
                    return new LibAtem.MacroOperations.MixEffects.Key.PatternKeySoftnessMacroOp{Softness = mac.Softness, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeySymmetry:
                    return new LibAtem.MacroOperations.MixEffects.Key.PatternKeySymmetryMacroOp{Symmetry = mac.Symmetry, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeyXPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.PatternKeyXPositionMacroOp{XPosition = mac.PositionX, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.PatternKeyYPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.PatternKeyYPositionMacroOp{YPosition = mac.PositionY, KeyIndex = mac.UpstreamKeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.MediaPlayerGoToBeginning:
                    return new LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerLoop:
                    return new LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp{Loop = mac.Loop.Value(), Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerPlay:
                    return new LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceClipIndex:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp{MediaIndex = mac.Index, Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceClip:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceStillIndex:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp{MediaIndex = mac.Index, Index = mac.MediaPlayerIndex};
                case MacroOperationType.MediaPlayerSourceStill:
                    return new LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp{Index = mac.MediaPlayerIndex};
                case MacroOperationType.HyperDeckPlay:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp{Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetLoop:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp{Loop = mac.HyperDeckLoopEnabled.Value(), Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetSingleClip:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetSingleClipMacroOp{SingleClipEnabled = mac.HyperDeckSingleClipEnabled.Value(), Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetSourceClipIndex:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetSourceClipIndexMacroOp{ClipIndex = mac.HyperDeckClipIndex, Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckSetSpeed:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckSetSpeedMacroOp{SpeedPercent = mac.HyperDeckSpeedPercent, Index = mac.HyperDeckIndex};
                case MacroOperationType.HyperDeckStop:
                    return new LibAtem.MacroOperations.HyperDeck.HyperDeckStopMacroOp{Index = mac.HyperDeckIndex};
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
                case MacroOperationType.AudioMixerInputGain:
                    return new LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp{Index = mac.Input.ToAudioSource(), Gain = mac.Gain};
                case MacroOperationType.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1:
                    return new LibAtem.MacroOperations.Audio.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp{Follow = mac.Follow.Value()};
                default:
                    throw new Exception(string.Format("Unknown type: {0}", mac.Id));
            }
        }
    }
}