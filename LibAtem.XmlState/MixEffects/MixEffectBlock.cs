using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.XmlState.MixEffects.Key;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects
{
    public class MixEffectBlock
    {
        public MixEffectBlock()
        {
        }

        public MixEffectBlock(MixEffectBlockId id)
        {
            Index = id;

            Program = new ProgramPreview(VideoSource.ColorBars);
            Preview = new ProgramPreview(VideoSource.Input1);

            NextTransition = new NextTransition();
            TransitionStyle = new TransitionStyle.XmlTransitionStyle();

            Keys = new List<MixEffectsKey>();
            FadeToBlack = new FadeToBlack();
        }

        public class ProgramPreview
        {
            public ProgramPreview() : this(VideoSource.Black)
            {
            }

            public ProgramPreview(VideoSource input)
            {
                Input = input;
            }

            [XmlAttribute("input")]
            public VideoSource Input { get; set; }
        }

        [XmlAttribute("index")]
        public MixEffectBlockId Index { get; set; }

        public ProgramPreview Program { get; set; }
        public ProgramPreview Preview { get; set; }

        public NextTransition NextTransition { get; set; }

        public TransitionStyle.XmlTransitionStyle TransitionStyle { get; set; }

        [XmlArrayItem("Key")]
        public List<MixEffectsKey> Keys { get; set; }

        public FadeToBlack FadeToBlack { get; set; }
    }

    public class FadeToBlack
    {
        public FadeToBlack()
        {
            Rate = 50;
            IsFullyBlack = AtemBool.False;
        }

        [XmlAttribute("rate")]
        public uint Rate { get; set; }

        [XmlAttribute("isFullyBlack")]
        public AtemBool IsFullyBlack { get; set; }
    }

}