using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.Key
{
    public class MixEffectsKey
    {
        public MixEffectsKey() : this(0)
        {
        }

        public MixEffectsKey(uint index)
        {
            Index = index;
            Mode = MixEffectKeyType.Luma;

            FillSource = VideoSource.Black;
            CutSource = VideoSource.Black;

            OnAir = AtemBool.False;
            MaskEnabled = AtemBool.False;

            LumaParameters = new LumaKeyParameters();
            ChromaParameters = new ChromaKeyParameters();
            PatternParameters = new PatternKeyParameters();
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("type")]
        public MixEffectKeyType Mode { get; set; }

        [XmlAttribute("inputFill")]
        public VideoSource FillSource { get; set; }
        [XmlAttribute("inputCut")]
        public VideoSource CutSource { get; set; }

        [XmlAttribute("onAir")]
        public AtemBool OnAir { get; set; }

        [XmlAttribute("masked")]
        public AtemBool MaskEnabled { get; set; }

        [XmlAttribute("maskTop")]
        public double MaskTop { get; set; }
        [XmlAttribute("maskBottom")]
        public double MaskBottom { get; set; }
        [XmlAttribute("maskLeft")]
        public double MaskLeft { get; set; }
        [XmlAttribute("maskRight")]
        public double MaskRight { get; set; }

        public LumaKeyParameters LumaParameters { get; set; }
        public ChromaKeyParameters ChromaParameters { get; set; }
        public PatternKeyParameters PatternParameters { get; set; }
        public DveKeyParameters DVEParameters { get; set; }
        public FlyKeyParameters FlyParameters { get; set; }
    }
}
