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
                case MacroOperationType.DVEKeyMaskBottom:
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
                case MacroOperationType.LumaKeyPreMultiply:
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
                case MacroOperationType.DVEKeyMaskLeft:
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
                case MacroOperationType.LumaKeyPreMultiply:
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
                case nameof(LibAtem.MacroOperations.AuxiliaryInputMacroOp):
                    var opAuxiliaryInputMacroOp = (LibAtem.MacroOperations.AuxiliaryInputMacroOp)op;
                    return new MacroOperation{AuxiliaryIndex = opAuxiliaryInputMacroOp.Index, Input = opAuxiliaryInputMacroOp.Source.ToMacroInput()};
                case nameof(LibAtem.MacroOperations.MacroSleepMacroOp):
                    var opMacroSleepMacroOp = (LibAtem.MacroOperations.MacroSleepMacroOp)op;
                    return new MacroOperation{Frames = opMacroSleepMacroOp.Frames};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceArtAboveMacroOp):
                    var opSuperSourceArtAboveMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceArtAboveMacroOp)op;
                    return new MacroOperation{SuperSourceArtAbove = opSuperSourceArtAboveMacroOp.ArtAbove.ToAtemBool()};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceArtCutInputMacroOp):
                    var opSuperSourceArtCutInputMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceArtCutInputMacroOp)op;
                    return new MacroOperation{Input = opSuperSourceArtCutInputMacroOp.Source.ToMacroInput()};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceArtFillInputMacroOp):
                    var opSuperSourceArtFillInputMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceArtFillInputMacroOp)op;
                    return new MacroOperation{Input = opSuperSourceArtFillInputMacroOp.Source.ToMacroInput()};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBorderEnableMacroOp):
                    var opSuperSourceBorderEnableMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBorderEnableMacroOp)op;
                    return new MacroOperation{Enable = opSuperSourceBorderEnableMacroOp.Enable.ToAtemBool()};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxEnableMacroOp):
                    var opSuperSourceBoxEnableMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxEnableMacroOp)op;
                    return new MacroOperation{Enable = opSuperSourceBoxEnableMacroOp.Enable.ToAtemBool(), SuperSourceBoxIndex = opSuperSourceBoxEnableMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxInputMacroOp):
                    var opSuperSourceBoxInputMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxInputMacroOp)op;
                    return new MacroOperation{Input = opSuperSourceBoxInputMacroOp.Source.ToMacroInput(), SuperSourceBoxIndex = opSuperSourceBoxInputMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskBottomMacroOp):
                    var opSuperSourceBoxMaskBottomMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskBottomMacroOp)op;
                    return new MacroOperation{Bottom = opSuperSourceBoxMaskBottomMacroOp.Bottom, SuperSourceBoxIndex = opSuperSourceBoxMaskBottomMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskEnableMacroOp):
                    var opSuperSourceBoxMaskEnableMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskEnableMacroOp)op;
                    return new MacroOperation{Enable = opSuperSourceBoxMaskEnableMacroOp.Enable.ToAtemBool(), SuperSourceBoxIndex = opSuperSourceBoxMaskEnableMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskLeftMacroOp):
                    var opSuperSourceBoxMaskLeftMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskLeftMacroOp)op;
                    return new MacroOperation{Left = opSuperSourceBoxMaskLeftMacroOp.Left, SuperSourceBoxIndex = opSuperSourceBoxMaskLeftMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskRightMacroOp):
                    var opSuperSourceBoxMaskRightMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskRightMacroOp)op;
                    return new MacroOperation{Right = opSuperSourceBoxMaskRightMacroOp.Right, SuperSourceBoxIndex = opSuperSourceBoxMaskRightMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskTopMacroOp):
                    var opSuperSourceBoxMaskTopMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxMaskTopMacroOp)op;
                    return new MacroOperation{Top = opSuperSourceBoxMaskTopMacroOp.Top, SuperSourceBoxIndex = opSuperSourceBoxMaskTopMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxSizeMacroOp):
                    var opSuperSourceBoxSizeMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxSizeMacroOp)op;
                    return new MacroOperation{Size = opSuperSourceBoxSizeMacroOp.Size, SuperSourceBoxIndex = opSuperSourceBoxSizeMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxXPositionMacroOp):
                    var opSuperSourceBoxXPositionMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxXPositionMacroOp)op;
                    return new MacroOperation{PositionX = opSuperSourceBoxXPositionMacroOp.PositionX, SuperSourceBoxIndex = opSuperSourceBoxXPositionMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.SuperSource.SuperSourceBoxYPositionMacroOp):
                    var opSuperSourceBoxYPositionMacroOp = (LibAtem.MacroOperations.SuperSource.SuperSourceBoxYPositionMacroOp)op;
                    return new MacroOperation{PositionY = opSuperSourceBoxYPositionMacroOp.PositionY, SuperSourceBoxIndex = opSuperSourceBoxYPositionMacroOp.BoxIndex};
                case nameof(LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp):
                    var opAutoTransitionMacroOp = (LibAtem.MacroOperations.MixEffects.AutoTransitionMacroOp)op;
                    return new MacroOperation{MixEffectBlockIndex = opAutoTransitionMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp):
                    var opCutTransitionMacroOp = (LibAtem.MacroOperations.MixEffects.CutTransitionMacroOp)op;
                    return new MacroOperation{MixEffectBlockIndex = opCutTransitionMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp):
                    var opFadeToBlackAutoMacroOp = (LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp)op;
                    return new MacroOperation{MixEffectBlockIndex = opFadeToBlackAutoMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp):
                    var opPreviewInputMacroOp = (LibAtem.MacroOperations.MixEffects.PreviewInputMacroOp)op;
                    return new MacroOperation{Input = opPreviewInputMacroOp.Source.ToMacroInput(), MixEffectBlockIndex = opPreviewInputMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp):
                    var opProgramInputMacroOp = (LibAtem.MacroOperations.MixEffects.ProgramInputMacroOp)op;
                    return new MacroOperation{Input = opProgramInputMacroOp.Source.ToMacroInput(), MixEffectBlockIndex = opProgramInputMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionDipRateMacroOp):
                    var opTransitionDipRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionDipRateMacroOp)op;
                    return new MacroOperation{Rate = opTransitionDipRateMacroOp.Rate, MixEffectBlockIndex = opTransitionDipRateMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionDVERateMacroOp):
                    var opTransitionDVERateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionDVERateMacroOp)op;
                    return new MacroOperation{Rate = opTransitionDVERateMacroOp.Rate, MixEffectBlockIndex = opTransitionDVERateMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp):
                    var opTransitionMixRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionMixRateMacroOp)op;
                    return new MacroOperation{Rate = opTransitionMixRateMacroOp.Rate, MixEffectBlockIndex = opTransitionMixRateMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp):
                    var opTransitionSourceMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionSourceMacroOp)op;
                    return new MacroOperation{TransitionSource = opTransitionSourceMacroOp.Source, MixEffectBlockIndex = opTransitionSourceMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerMixRateMacroOp):
                    var opTransitionStingerMixRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerMixRateMacroOp)op;
                    return new MacroOperation{Rate = opTransitionStingerMixRateMacroOp.Rate, MixEffectBlockIndex = opTransitionStingerMixRateMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerRateMacroOp):
                    var opTransitionStingerRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionStingerRateMacroOp)op;
                    return new MacroOperation{Rate = opTransitionStingerRateMacroOp.Rate, MixEffectBlockIndex = opTransitionStingerRateMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp):
                    var opTransitionStyleMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionStyleMacroOp)op;
                    return new MacroOperation{TransitionStyle = opTransitionStyleMacroOp.Style, MixEffectBlockIndex = opTransitionStyleMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Transition.TransitionWipeRateMacroOp):
                    var opTransitionWipeRateMacroOp = (LibAtem.MacroOperations.MixEffects.Transition.TransitionWipeRateMacroOp)op;
                    return new MacroOperation{Rate = opTransitionWipeRateMacroOp.Rate, MixEffectBlockIndex = opTransitionWipeRateMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyRotationMacroOp):
                    var opDVEAndFlyKeyRotationMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyRotationMacroOp)op;
                    return new MacroOperation{Rotation = opDVEAndFlyKeyRotationMacroOp.Rotation, KeyIndex = opDVEAndFlyKeyRotationMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyRotationMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXPositionMacroOp):
                    var opDVEAndFlyKeyXPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXPositionMacroOp)op;
                    return new MacroOperation{PositionX = opDVEAndFlyKeyXPositionMacroOp.PositionX, KeyIndex = opDVEAndFlyKeyXPositionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyXPositionMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXSizeMacroOp):
                    var opDVEAndFlyKeyXSizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXSizeMacroOp)op;
                    return new MacroOperation{SizeX = opDVEAndFlyKeyXSizeMacroOp.SizeX, KeyIndex = opDVEAndFlyKeyXSizeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyXSizeMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYPositionMacroOp):
                    var opDVEAndFlyKeyYPositionMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYPositionMacroOp)op;
                    return new MacroOperation{PositionY = opDVEAndFlyKeyYPositionMacroOp.PositionY, KeyIndex = opDVEAndFlyKeyYPositionMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyYPositionMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYSizeMacroOp):
                    var opDVEAndFlyKeyYSizeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYSizeMacroOp)op;
                    return new MacroOperation{SizeY = opDVEAndFlyKeyYSizeMacroOp.SizeY, KeyIndex = opDVEAndFlyKeyYSizeMacroOp.KeyIndex, MixEffectBlockIndex = opDVEAndFlyKeyYSizeMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEKeyBorderEnableMacroOp):
                    var opDVEKeyBorderEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyBorderEnableMacroOp)op;
                    return new MacroOperation{Enable = opDVEKeyBorderEnableMacroOp.Enable.ToAtemBool(), KeyIndex = opDVEKeyBorderEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyBorderEnableMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskBottomMacroOp):
                    var opDVEKeyMaskBottomMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskBottomMacroOp)op;
                    return new MacroOperation{Bottom = opDVEKeyMaskBottomMacroOp.Bottom, KeyIndex = opDVEKeyMaskBottomMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskBottomMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskEnableMacroOp):
                    var opDVEKeyMaskEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskEnableMacroOp)op;
                    return new MacroOperation{Enable = opDVEKeyMaskEnableMacroOp.Enable.ToAtemBool(), KeyIndex = opDVEKeyMaskEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskEnableMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskLeftMacroOp):
                    var opDVEKeyMaskLeftMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskLeftMacroOp)op;
                    return new MacroOperation{Left = opDVEKeyMaskLeftMacroOp.Left, KeyIndex = opDVEKeyMaskLeftMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskLeftMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskRightMacroOp):
                    var opDVEKeyMaskRightMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskRightMacroOp)op;
                    return new MacroOperation{Right = opDVEKeyMaskRightMacroOp.Right, KeyIndex = opDVEKeyMaskRightMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskRightMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskTopMacroOp):
                    var opDVEKeyMaskTopMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskTopMacroOp)op;
                    return new MacroOperation{Top = opDVEKeyMaskTopMacroOp.Top, KeyIndex = opDVEKeyMaskTopMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyMaskTopMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowEnableMacroOp):
                    var opDVEKeyShadowEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowEnableMacroOp)op;
                    return new MacroOperation{Enable = opDVEKeyShadowEnableMacroOp.Enable.ToAtemBool(), KeyIndex = opDVEKeyShadowEnableMacroOp.KeyIndex, MixEffectBlockIndex = opDVEKeyShadowEnableMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp):
                    var opKeyCutInputMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp)op;
                    return new MacroOperation{Input = opKeyCutInputMacroOp.Source.ToMacroInput(), KeyIndex = opKeyCutInputMacroOp.KeyIndex, MixEffectBlockIndex = opKeyCutInputMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp):
                    var opKeyFillInputMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp)op;
                    return new MacroOperation{Input = opKeyFillInputMacroOp.Source.ToMacroInput(), KeyIndex = opKeyFillInputMacroOp.KeyIndex, MixEffectBlockIndex = opKeyFillInputMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyFlyEnableMacroOp):
                    var opKeyFlyEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyFlyEnableMacroOp)op;
                    return new MacroOperation{Enable = opKeyFlyEnableMacroOp.Enable.ToAtemBool(), KeyIndex = opKeyFlyEnableMacroOp.KeyIndex, MixEffectBlockIndex = opKeyFlyEnableMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyMaskBottomMacroOp):
                    var opKeyMaskBottomMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskBottomMacroOp)op;
                    return new MacroOperation{Bottom = opKeyMaskBottomMacroOp.Bottom, KeyIndex = opKeyMaskBottomMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskBottomMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyMaskEnableMacroOp):
                    var opKeyMaskEnableMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskEnableMacroOp)op;
                    return new MacroOperation{Enable = opKeyMaskEnableMacroOp.Enable.ToAtemBool(), KeyIndex = opKeyMaskEnableMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskEnableMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyMaskLeftMacroOp):
                    var opKeyMaskLeftMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskLeftMacroOp)op;
                    return new MacroOperation{Left = opKeyMaskLeftMacroOp.Left, KeyIndex = opKeyMaskLeftMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskLeftMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyMaskRightMacroOp):
                    var opKeyMaskRightMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskRightMacroOp)op;
                    return new MacroOperation{Right = opKeyMaskRightMacroOp.Right, KeyIndex = opKeyMaskRightMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskRightMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyMaskTopMacroOp):
                    var opKeyMaskTopMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyMaskTopMacroOp)op;
                    return new MacroOperation{Top = opKeyMaskTopMacroOp.Top, KeyIndex = opKeyMaskTopMacroOp.KeyIndex, MixEffectBlockIndex = opKeyMaskTopMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyOnAirMacroOp):
                    var opKeyOnAirMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyOnAirMacroOp)op;
                    return new MacroOperation{OnAir = opKeyOnAirMacroOp.OnAir.ToAtemBool(), KeyIndex = opKeyOnAirMacroOp.KeyIndex, MixEffectBlockIndex = opKeyOnAirMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.KeyTypeMacroOp):
                    var opKeyTypeMacroOp = (LibAtem.MacroOperations.MixEffects.Key.KeyTypeMacroOp)op;
                    return new MacroOperation{KeyType = opKeyTypeMacroOp.KeyType, KeyIndex = opKeyTypeMacroOp.KeyIndex, MixEffectBlockIndex = opKeyTypeMacroOp.Index};
                case nameof(LibAtem.MacroOperations.MixEffects.Key.LumaKeyPreMultiplyMacroOp):
                    var opLumaKeyPreMultiplyMacroOp = (LibAtem.MacroOperations.MixEffects.Key.LumaKeyPreMultiplyMacroOp)op;
                    return new MacroOperation{PreMultiply = opLumaKeyPreMultiplyMacroOp.PreMultiply.ToAtemBool(), KeyIndex = opLumaKeyPreMultiplyMacroOp.KeyIndex, MixEffectBlockIndex = opLumaKeyPreMultiplyMacroOp.Index};
                case nameof(LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp):
                    var opMediaPlayerGoToBeginningMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerGoToBeginningMacroOp)op;
                    return new MacroOperation{MediaPlayerIndex = opMediaPlayerGoToBeginningMacroOp.Index};
                case nameof(LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp):
                    var opMediaPlayerLoopMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerLoopMacroOp)op;
                    return new MacroOperation{Loop = opMediaPlayerLoopMacroOp.Loop.ToAtemBool(), MediaPlayerIndex = opMediaPlayerLoopMacroOp.Index};
                case nameof(LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp):
                    var opMediaPlayerPlayMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerPlayMacroOp)op;
                    return new MacroOperation{MediaPlayerIndex = opMediaPlayerPlayMacroOp.Index};
                case nameof(LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp):
                    var opMediaPlayerSourceClipIndexMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceClipIndexMacroOp)op;
                    return new MacroOperation{Index = opMediaPlayerSourceClipIndexMacroOp.MediaIndex, MediaPlayerIndex = opMediaPlayerSourceClipIndexMacroOp.Index};
                case nameof(LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp):
                    var opMediaPlayerSourceClipMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceClipMacroOp)op;
                    return new MacroOperation{MediaPlayerIndex = opMediaPlayerSourceClipMacroOp.Index};
                case nameof(LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp):
                    var opMediaPlayerSourceStillIndexMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceStillIndexMacroOp)op;
                    return new MacroOperation{Index = opMediaPlayerSourceStillIndexMacroOp.MediaIndex, MediaPlayerIndex = opMediaPlayerSourceStillIndexMacroOp.Index};
                case nameof(LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp):
                    var opMediaPlayerSourceStillMacroOp = (LibAtem.MacroOperations.Media.MediaPlayerSourceStillMacroOp)op;
                    return new MacroOperation{MediaPlayerIndex = opMediaPlayerSourceStillMacroOp.Index};
                case nameof(LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp):
                    var opHyperDeckPlayMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckPlayMacroOp)op;
                    return new MacroOperation{HyperDeckIndex = opHyperDeckPlayMacroOp.Index};
                case nameof(LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp):
                    var opHyperDeckSetLoopMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetLoopMacroOp)op;
                    return new MacroOperation{HyperDeckLoopEnabled = opHyperDeckSetLoopMacroOp.Loop.ToAtemBool(), HyperDeckIndex = opHyperDeckSetLoopMacroOp.Index};
                case nameof(LibAtem.MacroOperations.HyperDeck.HyperDeckSetSingleClipMacroOp):
                    var opHyperDeckSetSingleClipMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetSingleClipMacroOp)op;
                    return new MacroOperation{HyperDeckSingleClipEnabled = opHyperDeckSetSingleClipMacroOp.SingleClipEnabled.ToAtemBool(), HyperDeckIndex = opHyperDeckSetSingleClipMacroOp.Index};
                case nameof(LibAtem.MacroOperations.HyperDeck.HyperDeckSetSourceClipIndexMacroOp):
                    var opHyperDeckSetSourceClipIndexMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetSourceClipIndexMacroOp)op;
                    return new MacroOperation{HyperDeckClipIndex = opHyperDeckSetSourceClipIndexMacroOp.ClipIndex, HyperDeckIndex = opHyperDeckSetSourceClipIndexMacroOp.Index};
                case nameof(LibAtem.MacroOperations.HyperDeck.HyperDeckSetSpeedMacroOp):
                    var opHyperDeckSetSpeedMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckSetSpeedMacroOp)op;
                    return new MacroOperation{HyperDeckSpeedPercent = opHyperDeckSetSpeedMacroOp.SpeedPercent, HyperDeckIndex = opHyperDeckSetSpeedMacroOp.Index};
                case nameof(LibAtem.MacroOperations.HyperDeck.HyperDeckStopMacroOp):
                    var opHyperDeckStopMacroOp = (LibAtem.MacroOperations.HyperDeck.HyperDeckStopMacroOp)op;
                    return new MacroOperation{HyperDeckIndex = opHyperDeckStopMacroOp.Index};
                case nameof(LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskBottomMacroOp):
                    var opDownstreamKeyMaskBottomMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskBottomMacroOp)op;
                    return new MacroOperation{Bottom = opDownstreamKeyMaskBottomMacroOp.Bottom, KeyIndex = (System.UInt32)opDownstreamKeyMaskBottomMacroOp.KeyIndex};
                case nameof(LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskEnableMacroOp):
                    var opDownstreamKeyMaskEnableMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskEnableMacroOp)op;
                    return new MacroOperation{Enable = opDownstreamKeyMaskEnableMacroOp.Enable.ToAtemBool(), KeyIndex = (System.UInt32)opDownstreamKeyMaskEnableMacroOp.KeyIndex};
                case nameof(LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskLeftMacroOp):
                    var opDownstreamKeyMaskLeftMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskLeftMacroOp)op;
                    return new MacroOperation{Left = opDownstreamKeyMaskLeftMacroOp.Left, KeyIndex = (System.UInt32)opDownstreamKeyMaskLeftMacroOp.KeyIndex};
                case nameof(LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskRightMacroOp):
                    var opDownstreamKeyMaskRightMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskRightMacroOp)op;
                    return new MacroOperation{Right = opDownstreamKeyMaskRightMacroOp.Right, KeyIndex = (System.UInt32)opDownstreamKeyMaskRightMacroOp.KeyIndex};
                case nameof(LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskTopMacroOp):
                    var opDownstreamKeyMaskTopMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyMaskTopMacroOp)op;
                    return new MacroOperation{Top = opDownstreamKeyMaskTopMacroOp.Top, KeyIndex = (System.UInt32)opDownstreamKeyMaskTopMacroOp.KeyIndex};
                case nameof(LibAtem.MacroOperations.DownStreamKey.DownstreamKeyOnAirMacroOp):
                    var opDownstreamKeyOnAirMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyOnAirMacroOp)op;
                    return new MacroOperation{OnAir = opDownstreamKeyOnAirMacroOp.OnAir.ToAtemBool(), KeyIndex = (System.UInt32)opDownstreamKeyOnAirMacroOp.KeyIndex};
                case nameof(LibAtem.MacroOperations.DownStreamKey.DownstreamKeyPreMultiplyMacroOp):
                    var opDownstreamKeyPreMultiplyMacroOp = (LibAtem.MacroOperations.DownStreamKey.DownstreamKeyPreMultiplyMacroOp)op;
                    return new MacroOperation{PreMultiply = opDownstreamKeyPreMultiplyMacroOp.PreMultiply.ToAtemBool(), KeyIndex = (System.UInt32)opDownstreamKeyPreMultiplyMacroOp.KeyIndex};
                case nameof(LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp):
                    var opAudioMixerInputGainMacroOp = (LibAtem.MacroOperations.Audio.AudioMixerInputGainMacroOp)op;
                    return new MacroOperation{Input = opAudioMixerInputGainMacroOp.Index.ToMacroInput(), Gain = opAudioMixerInputGainMacroOp.Gain};
                default:
                    return null;
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
                case MacroOperationType.DVEAndFlyKeyRotation:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyRotationMacroOp{Rotation = mac.Rotation, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyXPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXPositionMacroOp{PositionX = mac.PositionX, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyXSize:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyXSizeMacroOp{SizeX = mac.SizeX, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyYPosition:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYPositionMacroOp{PositionY = mac.PositionY, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEAndFlyKeyYSize:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEAndFlyKeyYSizeMacroOp{SizeY = mac.SizeY, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyBorderEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyBorderEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskBottom:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskBottomMacroOp{Bottom = mac.Bottom, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskLeft:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskLeftMacroOp{Left = mac.Left, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskRight:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskRightMacroOp{Right = mac.Right, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyMaskTop:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyMaskTopMacroOp{Top = mac.Top, KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.DVEKeyShadowEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.DVEKeyShadowEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyCutInput:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyCutInputMacroOp{Source = mac.Input.ToVideoSource(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyFillInput:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyFillInputMacroOp{Source = mac.Input.ToVideoSource(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
                case MacroOperationType.KeyFlyEnable:
                    return new LibAtem.MacroOperations.MixEffects.Key.KeyFlyEnableMacroOp{Enable = mac.Enable.Value(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
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
                case MacroOperationType.LumaKeyPreMultiply:
                    return new LibAtem.MacroOperations.MixEffects.Key.LumaKeyPreMultiplyMacroOp{PreMultiply = mac.PreMultiply.Value(), KeyIndex = mac.KeyIndex, Index = mac.MixEffectBlockIndex};
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