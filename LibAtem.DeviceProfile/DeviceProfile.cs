using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.Common;

namespace AtemEmulator.State
{
    [XmlRoot("DeviceProfile", IsNullable = false)]
    public class DeviceProfile
    {
        public string Product { get; set; }

        public uint MixEffectBlocks { get; set; }

        public List<DevicePort> Sources { get; set; }

        public uint ColorGenerators { get; set; }

        public uint Auxiliaries { get; set; }

        public uint DownstreamKeys { get; set; }

        public uint UpstreamKeys { get; set; }

        public uint HyperDecks { get; set; }

        public uint Stingers { get; set; }

        public uint MultiViews { get; set; }

        public uint DVE { get; set; }

        public uint SuperSource { get; set; }

        public uint MediaPlayers { get; set; }

        public uint MediaPoolClips { get; set; }

        public uint MediaPoolStills { get; set; }

        public uint MacroCount { get; set; }

        public uint SerialPort { get; set; }
    }

    public class DevicePort
    {
        [XmlAttribute("id")]
        public VideoSource Id { get; set; }

        [XmlElement("Port")]
        public List<ExternalPortType> Port { get; set; }
    }
}