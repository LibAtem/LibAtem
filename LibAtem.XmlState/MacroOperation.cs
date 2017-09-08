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
        public System.UInt32 AuxiliaryIndex
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
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.DownstreamKeyMaskBottom:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("boxIndex")]
        public System.UInt32 SuperSourceBoxIndex
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
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.DownstreamKeyMaskEnable:
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
                case MacroOperationType.AudioMixerInputGain:
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
                case MacroOperationType.AudioMixerInputGain:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("keyIndex")]
        public System.UInt32 KeyIndex
        {
            get;
            set;
        }

        public bool ShouldSerializeKeyIndex()
        {
            switch (Id)
            {
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyType:
                case MacroOperationType.DownstreamKeyMaskBottom:
                case MacroOperationType.DownstreamKeyMaskEnable:
                case MacroOperationType.DownstreamKeyMaskLeft:
                case MacroOperationType.DownstreamKeyMaskRight:
                case MacroOperationType.DownstreamKeyMaskTop:
                case MacroOperationType.DownstreamKeyOnAir:
                case MacroOperationType.DownstreamKeyPreMultiply:
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
                case MacroOperationType.SuperSourceBoxMaskLeft:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.DownstreamKeyMaskLeft:
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
                case MacroOperationType.PreviewInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionSource:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionStyle:
                case MacroOperationType.TransitionWipeRate:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyMaskBottom:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyType:
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
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionWipeRate:
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
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.DownstreamKeyMaskRight:
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
                    return true;
                default:
                    return false;
            }
        }
    }

    public static class MacroOpExtensions
    {
        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.AuxiliaryInputMacroOp op)
        {
            return new MacroOperation{AuxiliaryIndex = op.Index, Input = op.Source.ToMacroInput()};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MacroSleepMacroOp op)
        {
            return new MacroOperation{Frames = op.Frames};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceArtAboveMacroOp op)
        {
            return new MacroOperation{SuperSourceArtAbove = op.ArtAbove.ToAtemBool()};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceArtCutInputMacroOp op)
        {
            return new MacroOperation{Input = op.Source.ToMacroInput()};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceArtFillInputMacroOp op)
        {
            return new MacroOperation{Input = op.Source.ToMacroInput()};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBorderEnableMacroOp op)
        {
            return new MacroOperation{Enable = op.Enable.ToAtemBool()};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxEnableMacroOp op)
        {
            return new MacroOperation{Enable = op.Enable.ToAtemBool(), SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxInputMacroOp op)
        {
            return new MacroOperation{Input = op.Source.ToMacroInput(), SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskBottomMacroOp op)
        {
            return new MacroOperation{Bottom = op.Bottom, SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskEnableMacroOp op)
        {
            return new MacroOperation{Enable = op.Enable.ToAtemBool(), SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskLeftMacroOp op)
        {
            return new MacroOperation{Left = op.Left, SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskRightMacroOp op)
        {
            return new MacroOperation{Right = op.Right, SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskTopMacroOp op)
        {
            return new MacroOperation{Top = op.Top, SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxSizeMacroOp op)
        {
            return new MacroOperation{Size = op.Size, SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxXPositionMacroOp op)
        {
            return new MacroOperation{PositionX = op.PositionX, SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.SuperSource.SuperSourceBoxYPositionMacroOp op)
        {
            return new MacroOperation{PositionY = op.PositionY, SuperSourceBoxIndex = op.BoxIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp op)
        {
            return new MacroOperation{MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp op)
        {
            return new MacroOperation{MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp op)
        {
            return new MacroOperation{MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp op)
        {
            return new MacroOperation{Input = op.Source.ToMacroInput(), MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp op)
        {
            return new MacroOperation{Input = op.Source.ToMacroInput(), MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionDipRateMacroOp op)
        {
            return new MacroOperation{Rate = op.Rate, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionDVERateMacroOp op)
        {
            return new MacroOperation{Rate = op.Rate, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp op)
        {
            return new MacroOperation{Rate = op.Rate, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp op)
        {
            return new MacroOperation{TransitionSource = op.Source, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerMixRateMacroOp op)
        {
            return new MacroOperation{Rate = op.Rate, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerRateMacroOp op)
        {
            return new MacroOperation{Rate = op.Rate, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp op)
        {
            return new MacroOperation{TransitionStyle = op.Style, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Transition.TransitionWipeRateMacroOp op)
        {
            return new MacroOperation{Rate = op.Rate, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp op)
        {
            return new MacroOperation{Input = op.Source.ToMacroInput(), KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp op)
        {
            return new MacroOperation{Input = op.Source.ToMacroInput(), KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyMaskBottomMacroOp op)
        {
            return new MacroOperation{Bottom = op.Bottom, KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyMaskEnableMacroOp op)
        {
            return new MacroOperation{Enable = op.Enable.ToAtemBool(), KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyMaskLeftMacroOp op)
        {
            return new MacroOperation{Left = op.Left, KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyMaskRightMacroOp op)
        {
            return new MacroOperation{Right = op.Right, KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyMaskTopMacroOp op)
        {
            return new MacroOperation{Top = op.Top, KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyOnAirMacroOp op)
        {
            return new MacroOperation{OnAir = op.OnAir.ToAtemBool(), KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.MixEffects.Key.KeyTypeMacroOp op)
        {
            return new MacroOperation{KeyType = op.KeyType, KeyIndex = op.KeyIndex, MixEffectBlockIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp op)
        {
            return new MacroOperation{MediaPlayerIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp op)
        {
            return new MacroOperation{Loop = op.Loop.ToAtemBool(), MediaPlayerIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp op)
        {
            return new MacroOperation{MediaPlayerIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp op)
        {
            return new MacroOperation{Index = op.MediaIndex, MediaPlayerIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp op)
        {
            return new MacroOperation{MediaPlayerIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp op)
        {
            return new MacroOperation{Index = op.MediaIndex, MediaPlayerIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp op)
        {
            return new MacroOperation{MediaPlayerIndex = op.Index};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskBottomMacroOp op)
        {
            return new MacroOperation{Bottom = op.Bottom, KeyIndex = (System.UInt32)op.KeyIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskEnableMacroOp op)
        {
            return new MacroOperation{Enable = op.Enable.ToAtemBool(), KeyIndex = (System.UInt32)op.KeyIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskLeftMacroOp op)
        {
            return new MacroOperation{Left = op.Left, KeyIndex = (System.UInt32)op.KeyIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskRightMacroOp op)
        {
            return new MacroOperation{Right = op.Right, KeyIndex = (System.UInt32)op.KeyIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskTopMacroOp op)
        {
            return new MacroOperation{Top = op.Top, KeyIndex = (System.UInt32)op.KeyIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.DownStreamKey.DownstreamKeyOnAirMacroOp op)
        {
            return new MacroOperation{OnAir = op.OnAir.ToAtemBool(), KeyIndex = (System.UInt32)op.KeyIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.DownStreamKey.DownstreamKeyPreMultiplyMacroOp op)
        {
            return new MacroOperation{PreMultiply = op.PreMultiply.ToAtemBool(), KeyIndex = (System.UInt32)op.KeyIndex};
        }

        public static MacroOperation ToMacroOperation(this LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp op)
        {
            return new MacroOperation{Input = op.Index.ToMacroInput(), Gain = op.Gain};
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
                case MacroOperationType.PreviewInput:
                    return new LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp{Source = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.ProgramInput:
                    return new LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp{Source = mac.Input.ToVideoSource(), Index = mac.MixEffectBlockIndex};
                case MacroOperationType.TransitionDipRate:
                    return new LibAtem.MacroOperations.MixEffects.Transition.TransitionDipRateMacroOp{Rate = mac.Rate, Index = mac.MixEffectBlockIndex};
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
                case MacroOperationType.KeyCutInput:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp{Source = mac.Input.ToVideoSource(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyFillInput:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp{Source = mac.Input.ToVideoSource(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskBottom:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskBottomMacroOp{Bottom = mac.Bottom, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskLeft:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskLeftMacroOp{Left = mac.Left, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskRight:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskRightMacroOp{Right = mac.Right, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyMaskTop:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyMaskTopMacroOp{Top = mac.Top, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyOnAir:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyOnAirMacroOp{OnAir = mac.OnAir.Value(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyType:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyTypeMacroOp{KeyType = mac.KeyType, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
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
                case MacroOperationType.DownstreamKeyMaskBottom:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskBottomMacroOp{Bottom = mac.Bottom, KeyIndex = (LibAtem.Common.DownstreamKeyId)mac.KeyIndex};
                case MacroOperationType.DownstreamKeyMaskEnable:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = (LibAtem.Common.DownstreamKeyId)mac.KeyIndex};
                case MacroOperationType.DownstreamKeyMaskLeft:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskLeftMacroOp{Left = mac.Left, KeyIndex = (LibAtem.Common.DownstreamKeyId)mac.KeyIndex};
                case MacroOperationType.DownstreamKeyMaskRight:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskRightMacroOp{Right = mac.Right, KeyIndex = (LibAtem.Common.DownstreamKeyId)mac.KeyIndex};
                case MacroOperationType.DownstreamKeyMaskTop:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskTopMacroOp{Top = mac.Top, KeyIndex = (LibAtem.Common.DownstreamKeyId)mac.KeyIndex};
                case MacroOperationType.DownstreamKeyOnAir:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyOnAirMacroOp{OnAir = mac.OnAir.Value(), KeyIndex = (LibAtem.Common.DownstreamKeyId)mac.KeyIndex};
                case MacroOperationType.DownstreamKeyPreMultiply:
                    return new LibAtem.MacroOperations.DownStreamKey.DownstreamKeyPreMultiplyMacroOp{PreMultiply = mac.PreMultiply.Value(), KeyIndex = (LibAtem.Common.DownstreamKeyId)mac.KeyIndex};
                case MacroOperationType.AudioMixerInputGain:
                    return new LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp{Index = mac.Input.ToAudioSource(), Gain = mac.Gain};
                default:
                    return null;
            }
        }
    }
}