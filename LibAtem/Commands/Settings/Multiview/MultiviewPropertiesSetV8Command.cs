using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Settings;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMvP", CommandDirection.ToServer, ProtocolVersion.V8_0, 4)]
    public class MultiviewPropertiesSetV8Command : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Layout = 1 << 0,
            ProgramPreviewSwapped = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), UInt8]
        public uint MultiviewIndex { get; set; }
        [Serialize(2), Enum8]
        public MultiViewLayoutV8 Layout { get; set; }
        [Serialize(3), Bool]
        public bool ProgramPreviewSwapped { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.Layout))
            {
                if (!Enum.TryParse(Layout.ToString(), true, out MultiViewLayout layout))
                    layout = 0;

                yield return new MultiViewLayoutMacroOp { MultiViewIndex = MultiviewIndex, Layout = layout };
            }
            if (Mask.HasFlag(MaskFlags.ProgramPreviewSwapped))
                yield return null;
        }
    }
}