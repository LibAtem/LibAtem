using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.TransitionStyle
{
    public class XmlTransitionStyle
    {
        public XmlTransitionStyle()
        {
            Style = Common.TransitionStyle.Mix;
            NextStyle = Common.TransitionStyle.Mix;

            PreviewTransition = AtemBool.False;
            TransitionPosition = 0;

            MixParameters = new MixTransitionParameters();
            DipParameters = new DipTransitionParameters();
            WipeParameters = new WipeTransitionParameters();
        }

        [XmlAttribute("style")]
        public Common.TransitionStyle Style { get; set; }

        [XmlAttribute("nextStyle")]
        public Common.TransitionStyle NextStyle { get; set; }

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