using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState
{
    public class Macro
    {
        public Macro() : this(0)
        {
        }

        public Macro(uint index)
        {
            Index = index;
            Operations = new List<MacroOperation>();    
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlElement("Op")]
        public List<MacroOperation> Operations { get; set; }
    }

    public class MacroOperation
    {
        [XmlAttribute("id")]
        public MacroOperationType Id { get; set; }

        public bool IsWait()
        {
            return Id == MacroOperationType.MacroUserWait || Id == MacroOperationType.MacroSleep;
        }


        [XmlAttribute("index")]
        public uint Index { get; set; }
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

        [XmlAttribute("frames")]
        public uint Frames { get; set; }
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

        [XmlAttribute("mixEffectBlockIndex")]
        public MixEffectBlockId MixEffectBlockIndex { get; set; }
        public bool ShouldSerializeMixEffectBlockIndex()
        {
            switch (Id)
            {
                case MacroOperationType.CutTransition:
                case MacroOperationType.AutoTransition:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.FadeToBlackAuto:

                case MacroOperationType.TransitionStyle:
                case MacroOperationType.TransitionSource:
                case MacroOperationType.TransitionMixRate:
                case MacroOperationType.TransitionStingerRate:
                case MacroOperationType.TransitionDVERate:
                case MacroOperationType.TransitionDipRate:
                case MacroOperationType.TransitionStingerMixRate:
                case MacroOperationType.TransitionWipeRate:

                case MacroOperationType.KeyType:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFlyEnable:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyMaskBottom:

                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.LumaKeyPreMultiply:

                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyMaskBottom:
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
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("auxiliaryIndex")]
        public uint AuxiliaryIndex { get; set; }
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

        [XmlAttribute("boxIndex")]
        public uint BoxIndex { get; set; }
        public bool ShouldSerializeBoxIndex()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxEnable:
                case MacroOperationType.SuperSourceBoxInput:
                case MacroOperationType.SuperSourceBoxXPosition:
                case MacroOperationType.SuperSourceBoxYPosition:
                case MacroOperationType.SuperSourceBoxSize:
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

        #region Media Player

        [XmlAttribute("mediaPlayer")]
        public MediaPlayerId MediaPlayer { get; set; }
        public bool ShouldSerializeMediaPlayer()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerSourceStillIndex:
                case MacroOperationType.MediaPlayerSourceStill:
                case MacroOperationType.MediaPlayerSourceClipIndex:
                case MacroOperationType.MediaPlayerSourceClip:
                case MacroOperationType.MediaPlayerPlay:
                case MacroOperationType.MediaPlayerGoToBeginning:
                case MacroOperationType.MediaPlayerLoop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("loop")]
        public AtemBool Loop { get; set; }
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

        #endregion Media Player
        
        #region Keyer

        [XmlAttribute("keyIndex")]
        public uint KeyIndex { get; set; }
        public bool ShouldSerializeKeyIndex()
        {
            switch (Id)
            {
                case MacroOperationType.DownstreamKeyOnAir:

                case MacroOperationType.KeyType:
                case MacroOperationType.KeyOnAir:
                case MacroOperationType.KeyFillInput:
                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFlyEnable:
                case MacroOperationType.KeyMaskEnable:
                case MacroOperationType.KeyMaskLeft:
                case MacroOperationType.KeyMaskRight:
                case MacroOperationType.KeyMaskTop:
                case MacroOperationType.KeyMaskBottom:

                case MacroOperationType.LumaKeyClip:
                case MacroOperationType.LumaKeyGain:
                case MacroOperationType.LumaKeyInvert:
                case MacroOperationType.LumaKeyPreMultiply:

                case MacroOperationType.DVEAndFlyKeyXPosition:
                case MacroOperationType.DVEAndFlyKeyYPosition:
                case MacroOperationType.DVEAndFlyKeyXSize:
                case MacroOperationType.DVEAndFlyKeyYSize:
                case MacroOperationType.DVEAndFlyKeyRotation:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DVEKeyMaskBottom:
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
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("type")]
        public MixEffectKeyType KeyType { get; set; }
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
        public AtemBool PreMultiply { get; set; }
        public bool ShouldSerializePreMultiply()
        {
            switch (Id)
            {
                case MacroOperationType.LumaKeyPreMultiply:
                case MacroOperationType.DownstreamKeyPreMultiply:
                case MacroOperationType.SuperSourceArtPreMultiply:
                case MacroOperationType.TransitionStingerDVEPreMultiply:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("onAir")]
        public AtemBool OnAir { get; set; }
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

        #endregion Keyer

        #region Common
        
        [XmlAttribute("enable")]
        public AtemBool Enable { get; set; }
        public bool ShouldSerializeEnable()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxEnable:
                case MacroOperationType.SuperSourceBoxMaskEnable:
                case MacroOperationType.SuperSourceBorderEnable:
                case MacroOperationType.DVEKeyShadowEnable:
                case MacroOperationType.DVEKeyMaskEnable:
                case MacroOperationType.KeyFlyEnable:
                case MacroOperationType.DVEKeyBorderEnable:
                case MacroOperationType.DownstreamKeyMaskEnable:
                case MacroOperationType.KeyMaskEnable:
                    return true;
                default:
                    return false;
            }
        }
        
        [XmlAttribute("input")]
        public MacroInput Input { get; set; }
        public bool ShouldSerializeInput()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceArtFillInput:
                case MacroOperationType.SuperSourceArtCutInput:
                case MacroOperationType.SuperSourceBoxInput:
                case MacroOperationType.AuxiliaryInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.AudioMixerInputGain:

                case MacroOperationType.KeyCutInput:
                case MacroOperationType.KeyFillInput:
                    return true;
                default:
                    return false;
            }
        }

        #endregion Common

        #region Geometry

        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }
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
        public double YPosition { get; set; }
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
        public double Rotation { get; set; }
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
        public double Size { get; set; }
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
        public double XSize { get; set; }
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
        public double YSize { get; set; }
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

        #endregion Geometry
        
        #region Audio

        [XmlAttribute("gain")]
        public int Gain { get; set; }
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

        #endregion Audio

        #region Transition

        [XmlAttribute("style")]
        public TStyle TransitionStyle { get; set; }
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

        [XmlIgnore]
        public TransitionLayer TransitionSource { get; set; }

        [XmlAttribute("source")]
        public string TransitionSourceString
        {
            get => TransitionSource.ToString();
            set => TransitionSource = (TransitionLayer)Enum.Parse(typeof(TransitionLayer), value);
        }
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

        [XmlAttribute("rate")]
        public uint Rate { get; set; }
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

        #endregion Transition

        #region Mask

        [XmlAttribute("left")]
        public double Left { get; set; }
        public bool ShouldSerializeLeft()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskLeft:
                case MacroOperationType.DVEKeyMaskLeft:
                case MacroOperationType.DownstreamKeyMaskLeft:
                case MacroOperationType.FlyKeyFrameMaskLeft:
                case MacroOperationType.KeyMaskLeft:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("right")]
        public double Right { get; set; }
        public bool ShouldSerializeRight()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskRight:
                case MacroOperationType.DVEKeyMaskRight:
                case MacroOperationType.DownstreamKeyMaskRight:
                case MacroOperationType.FlyKeyFrameMaskRight:
                case MacroOperationType.KeyMaskRight:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("top")]
        public double Top { get; set; }
        public bool ShouldSerializeTop()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskTop:
                case MacroOperationType.DVEKeyMaskTop:
                case MacroOperationType.DownstreamKeyMaskTop:
                case MacroOperationType.FlyKeyFrameMaskTop:
                case MacroOperationType.KeyMaskTop:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("bottom")]
        public double Bottom { get; set; }
        public bool ShouldSerializeBottom()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxMaskBottom:
                case MacroOperationType.DVEKeyMaskBottom:
                case MacroOperationType.DownstreamKeyMaskBottom:
                case MacroOperationType.FlyKeyFrameMaskBottom:
                case MacroOperationType.KeyMaskBottom:
                    return true;
                default:
                    return false;
            }
        }

        #endregion Mask

        #region SuperSource
        
        [XmlAttribute("artAbove")]
        public AtemBool ArtAbove { get; set; }
        public bool ShouldSerializeArtAbove()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceArtAbove:
                    return true;
                default:
                    return false;
            }
        }

        #endregion SuperSource

        #region HyperDeck

        [XmlAttribute("hyperDeckIndex")]
        public int HyperDeckIndex { get; set; }
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

        [XmlAttribute("clipIndex")]
        public int HyperDeckClipIndex { get; set; }
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
        public AtemBool HyperDeckLoopEnabled { get; set; }
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
        public AtemBool HyperDeckSingleClipEnabled { get; set; }
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
        public int HyperDeckSpeedPercent { get; set; }
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

        #endregion HyperDeck
    }

    public enum MacroInput
    {
        Black = 0,

        Camera1 = 1,
        Camera2 = 2,
        Camera3 = 3,
        Camera4 = 4,
        Camera5 = 5,
        Camera6 = 6,
        Camera7 = 7,
        Camera8 = 8,
        Camera9 = 9,
        Camera10 = 10,
        Camera11 = 11,
        Camera12 = 12,
        Camera13 = 13,
        Camera14 = 14,
        Camera15 = 15,
        Camera16 = 16,
        Camera17 = 17,
        Camera18 = 18,
        Camera19 = 19,
        Camera20 = 20,

        Color1 = 2001,
        Color2 = 2002,

        MediaPlayer1    = 3010,
        MediaPlayer1Key = 3011,
        MediaPlayer2    = 3020,
        MediaPlayer2Key = 3021,
        MediaPlayer3    = 3030,
        MediaPlayer3Key = 3031,
        MediaPlayer4    = 3040,
        MediaPlayer4Key = 3041,

        SuperSource = 6000,

        ME1Program = 10010,
        ME2Program = 10020,

        ExternalXLR = 20000,
    }

    public class MacroControl
    {
        [XmlAttribute("loop")]
        public AtemBool Loop { get; set; }
    }
}