using System;
using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects
{
    public class NextTransition
    {
        public NextTransition()
        {
            Selection = TransitionLayer.Background;
            NextSelection = TransitionLayer.Background;
        }

        [XmlIgnore]
        public TransitionLayer Selection { get; set; }

        [XmlAttribute("selection")]
        public string SelectionString
        {
            get => Selection.ToString();
            set => Selection = (TransitionLayer) Enum.Parse(typeof(TransitionLayer), value);
        }

        [XmlIgnore]
        public TransitionLayer NextSelection { get; set; }

        [XmlAttribute("nextSelection")]
        public string NextSelectionString
        {
            get => NextSelection.ToString();
            set => NextSelection = (TransitionLayer)Enum.Parse(typeof(TransitionLayer), value);
        }
    }
}