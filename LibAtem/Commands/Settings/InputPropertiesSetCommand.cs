using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CInL", 32)]
    public class InputPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            LongName = 1 << 0,
            ShortName = 1 << 1,
            ExternalPortType = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(2), Enum16]
        public VideoSource Id { get; set; }
        [Serialize(4), String(20)]
        public string LongName { get; set; }
        [Serialize(24), String(4)]
        public string ShortName { get; set; }
        [Serialize(28), Enum16]
        public ExternalPortType ExternalPortType { get; set; }
    }
}