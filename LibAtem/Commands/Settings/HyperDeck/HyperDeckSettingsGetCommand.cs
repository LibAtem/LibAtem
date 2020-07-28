using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{

    [CommandName("RXMS", CommandDirection.ToClient, 20)]
    public class HyperDeckSettingsGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16Range(0, 4)]
        public uint Id { get; set; }

        [Serialize(4), IpAddress]
        public string NetworkAddress { get; set; }

        [Serialize(8), Enum16]
        public VideoSource Input { get; set; }
        [Serialize(10), Bool]
        public bool AutoRoll { get; set; }
        [Serialize(12), UInt16Range(0, 60)]
        public uint AutoRollFrameDelay { get; set; }

        [Serialize(14), Enum8]
        public HyperDeckConnectionStatus Status { get; set; }

        [Serialize(16), UInt16]
        public uint StorageMediaCount { get; set; }
        [Serialize(18), Bool]
        public bool IsRemoteEnabled { get; set; }
    }
}