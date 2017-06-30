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

        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serializable(2), Enum16]
        public VideoSource Id { get; set; }
        [Serializable(4), String(20)]
        public string LongName { get; set; }
        [Serializable(24), String(4)]
        public string ShortName { get; set; }
        [Serializable(30), Enum16]
        public ExternalPortType ExternalPortType { get; set; }
    }
}