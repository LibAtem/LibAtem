using System.Linq;
using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXMS", 20)]
    public class HyperDeckSettingsGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16Range(0, 4)]
        public uint Id { get; set; }

        [NoSerialize]
        public string NetworkAddress { get; set; }
        [Serialize(2), ByteArray(4)]
        protected byte[] NetworkAddressBytes
        {
            get => IPUtil.ParseAddress(NetworkAddress ?? "0.0.0.0");
            set => NetworkAddress = value.All(v => v == 0) ? null : IPUtil.IPToString(value);
        }

        [Serialize(6), Enum16]
        public VideoSource Input { get; set; }
        [Serialize(8), Bool]
        public bool AutoRoll { get; set; }
        [Serialize(10), UInt8Range(0, 60)]
        public uint AutoRollFrameDelay { get; set; }
    }
}