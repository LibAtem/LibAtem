using System.Linq;
using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXMS", CommandDirection.ToClient, 20)]
    public class HyperDeckSettingsGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16Range(0, 4)]
        public uint Id { get; set; }

        [NoSerialize]
        public string NetworkAddress { get; set; }
        [Serialize(4), ByteArray(4)]
        public byte[] NetworkAddressBytes
        {
            get => IPUtil.ParseAddress(NetworkAddress ?? "0.0.0.0");
            set => NetworkAddress = value.All(v => v == 0) ? null : IPUtil.IPToString(value);
        }

        // TODO - these fields may not be correct
        [Serialize(8), Enum16]
        public VideoSource Input { get; set; }
        [Serialize(10), Bool]
        public bool AutoRoll { get; set; }
        [Serialize(12), UInt16Range(0, 60)]
        public uint AutoRollFrameDelay { get; set; }
    }
}