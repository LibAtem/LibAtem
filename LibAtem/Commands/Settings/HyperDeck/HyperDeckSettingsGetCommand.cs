using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXMS", 20)]
    public class HyperDeckSettingsGetCommand : SerializableCommandBase
    {
        [Serializable(0), UInt16Range(0, 4)]
        public uint Id { get; set; }

        [NonSerialized]
        public string NetworkAddress { get; set; }
        [Serializable(2), ByteArray(4)]
        protected byte[] NetworkAddressBytes
        {
            get => IPUtil.ParseAddress(NetworkAddress);
            set => NetworkAddress = IPUtil.IPToString(value);
        }

        [Serializable(6), Enum16]
        public VideoSource Input { get; set; }
        [Serializable(8), Bool]
        public bool AutoRoll { get; set; }
        [Serializable(10), UInt8Range(0, 60)]
        public uint AutoRollFrameDelay { get; set; }
    }
}