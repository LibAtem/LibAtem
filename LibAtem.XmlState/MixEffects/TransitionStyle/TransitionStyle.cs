using System.Xml.Serialization;
using LibAtem.Common;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class TransitionStyle
    {
        public TransitionStyle()
        {
            Style = TStyle.Mix;
            NextStyle = TStyle.Mix;

            PreviewTransition = AtemBool.False;
            TransitionPosition = 0;

            MixParameters = new MixTransitionParameters();
            DipParameters = new DipTransitionParameters();
            WipeParameters = new WipeTransitionParameters();
        }

        [XmlAttribute("style")]
        public TStyle Style { get; set; }

        [XmlAttribute("nextStyle")]
        public TStyle NextStyle { get; set; }

        [XmlAttribute("previewTransition")]
        public AtemBool PreviewTransition { get; set; }

        [XmlAttribute("transitionPosition")]
        public int TransitionPosition { get; set; }

        public MixTransitionParameters MixParameters { get; set; }
        public DipTransitionParameters DipParameters { get; set; }
        public WipeTransitionParameters WipeParameters { get; set; }
        public StingerTransitionParameters StingerParameters { get; set; }
        public DveTransitionParameters DVEParameters { get; set; }
    }
}