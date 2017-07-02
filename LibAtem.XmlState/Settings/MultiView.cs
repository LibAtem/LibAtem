using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.Common;

namespace AtemEmulator.State.Settings
{
    public class MultiView
    {
        public const int WindowCount = 10;

        public MultiView() : this(0)
        {
        }

        public MultiView(uint index)
        {
            Index = index;
            Layout = MultiViewLayout.ProgramTop;
            VuMeterOpacity = 1;
            SafeAreaEnabled = AtemBool.True;
            ProgramPreviewSwapped = AtemBool.False;

            Windows = new List<MultiViewWindow>();
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("layout")]
        public MultiViewLayout Layout { get; set; }

        [XmlAttribute("vuMeterOpacity")]
        public double VuMeterOpacity { get; set; }

        [XmlAttribute("safeAreaEnabled")]
        public AtemBool SafeAreaEnabled { get; set; }

        [XmlAttribute("programPreviewSwapped")]
        public AtemBool ProgramPreviewSwapped { get; set; }

        [XmlArrayItem("Window")]
        public List<MultiViewWindow> Windows { get; set; }
    }

    public class MultiViewWindow
    {
        public MultiViewWindow():this(0, VideoSource.Input1)
        {
        }

        public MultiViewWindow(uint index, VideoSource input)
        {
            Index = index;
            Input = input;
            VuMeterEnabled = AtemBool.True;
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }

        [XmlAttribute("vuMeterEnabled")]
        public AtemBool VuMeterEnabled { get; set; }
    }
}