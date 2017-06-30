using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMvP", 8)]
    public class MultiviewPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Layout = 1 << 0,
            SafeAreaEnabled = 1 << 1,
            ProgramPreviewSwapped = 1 << 2,
        }

        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serializable(1), UInt8]
        public uint MultiviewIndex { get; set; }
        [Serializable(2), Enum8]
        public MultiViewLayout Layout { get; set; }
        [Serializable(3), Bool]
        public bool SafeAreaEnabled { get; set; }
        [Serializable(4), Bool]
        public bool ProgramPreviewSwapped { get; set; }
    }
}