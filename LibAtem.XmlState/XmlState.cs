using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.XmlState.Media;
using LibAtem.XmlState.MixEffects;
using LibAtem.XmlState.Settings;

namespace LibAtem.XmlState
{
    [XmlRoot("Profile", IsNullable = false)]
    public class XmlState
    {
        public XmlState()
        {
            MixEffectBlocks = new List<MixEffectBlock>();
            DownstreamKeys = new List<DownstreamKey>();
            ColorGenerators = new List<ColorGenerator>();
            Auxiliaries = new List<Auxiliary>();
            Settings = new AtemSettings();
            AudioMixer = new AudioMixer();
            MediaPlayers = new List<MediaPlayer>();
            MediaPool = new MediaPool();
            CameraControl = new CameraControl();
            MacroPool = new List<Macro>();
            MacroControl = new MacroControl();
        }

        public XmlState(string product) : this()
        {
            Product = product;
            MajorVersion = 1; //TODO
            MinorVersion = 1; //TODO
        }

        [XmlAttribute("majorVersion")]
        public int MajorVersion { get; set; }

        [XmlAttribute("minorVersion")]
        public int MinorVersion { get; set; }

        [XmlAttribute("product")]
        public string Product { get; set; }

        public List<MixEffectBlock> MixEffectBlocks { get; set; }

        public List<DownstreamKey> DownstreamKeys { get; set; }

        public List<ColorGenerator> ColorGenerators { get; set; }

        public List<Auxiliary> Auxiliaries { get; set; }

        public AtemSettings Settings { get; set; }

        public List<HyperDeck> HyperDecks { get; set; }
        public bool ShouldSerializeHyperDecks()
        {
            return HyperDecks != null && HyperDecks.Count > 0;
        }

        public AudioMixer AudioMixer { get; set; }

        public List<MediaPlayer> MediaPlayers { get; set; }

        public SuperSource SuperSource { get; set; }

        public MediaPool MediaPool { get; set; }
        public bool ShouldSerializeMediaPool()
        {
            return MediaPool != null && (MediaPool.Clips.Count > 0 || MediaPool.Stills.Count > 0);
        }

        public CameraControl CameraControl { get; set; }

        [XmlArrayItem("Macro")]
        public List<Macro> MacroPool { get; set; }

        public MacroControl MacroControl { get; set; }
    }

    public enum AtemBool
    {
        False,
        True,
    }

    public static class AtemBoolExtensions
    {
        public static bool Value(this AtemBool val)
        {
            return val == AtemBool.True;
        }

        public static AtemBool ToAtemBool(this bool val)
        {
            return val ? AtemBool.True : AtemBool.False;
        }

        public static AtemBool Invert(this AtemBool val)
        {
            return val == AtemBool.True ? AtemBool.False : AtemBool.True;
        }
    }
}