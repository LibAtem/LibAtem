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
                    return true;
                default:
                    return false;
            }
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
                case MacroOperationType.AuxiliaryInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.PreviewInput:
                case MacroOperationType.AudioMixerInputGain:
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
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("enable")]
        public AtemBool Enable { get; set; }
        public bool ShouldSerializeEnable()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxEnable:
                    return true;
                default:
                    return false;
            }
        }

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

        MediaPlayer1 = 3010,

        ME1Program = 10010,

        ExternalXLR = 20000,
    }

    public class MacroControl
    {
        [XmlAttribute("loop")]
        public AtemBool Loop { get; set; }
    }
}