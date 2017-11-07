using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Audio;
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

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), UInt8]
        public uint MultiviewIndex { get; set; }
        [Serialize(2), Enum8]
        public MultiViewLayout Layout { get; set; }
        [Serialize(3), Bool]
        public bool SafeAreaEnabled { get; set; }
        [Serialize(4), Bool]
        public bool ProgramPreviewSwapped { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Layout))
                yield return new MultiViewLayoutMacroOp {MultiViewIndex = MultiviewIndex, Layout = Layout};
            if (Mask.HasFlag(MaskFlags.SafeAreaEnabled))
                yield return null;
            if (Mask.HasFlag(MaskFlags.ProgramPreviewSwapped))
                yield return null;
        }
    }
}