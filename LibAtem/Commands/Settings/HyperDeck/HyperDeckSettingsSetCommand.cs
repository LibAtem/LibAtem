using System;
using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("CXMS", 16)]
    public class HyperDeckSettingsSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Address = 1 << 0,
            Input = 1 << 1,
            AutoRoll = 1 << 2,
            AutoRollFrameDelay = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), UInt16Range(0, 4)]
        public uint Id { get; set; }
        
        [NoSerialize]
        public string NetworkAddress { get; set; }
        [Serialize(4), ByteArray(4)]
        protected byte[] NetworkAddressBytes
        {
            get => IPUtil.ParseAddress(NetworkAddress);
            set => NetworkAddress = IPUtil.IPToString(value);
        }

        [Serialize(8), Enum16]
        public VideoSource Input { get; set; }
        [Serialize(10), Bool]
        public bool AutoRoll { get; set; }
        [Serialize(12), UInt8Range(0, 60)]
        public uint AutoRollFrameDelay { get; set; }
    }
}