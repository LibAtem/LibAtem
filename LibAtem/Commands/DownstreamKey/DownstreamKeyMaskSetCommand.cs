using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.DownStreamKey;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsM", 12)]
    public class DownstreamKeyMaskSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            MaskEnabled = 1 << 0,
            MaskTop = 1 << 1,
            MaskBottom = 1 << 2,
            MaskLeft = 1 << 3,
            MaskRight = 1 << 4,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(2), Bool]
        public bool MaskEnabled { get; set; }
        [Serialize(4), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(6), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(8), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(10), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.MaskEnabled))
                yield return new DownstreamKeyMaskEnableMacroOp() {KeyIndex = Index, Enable = MaskEnabled };

            if (Mask.HasFlag(MaskFlags.MaskTop))
                yield return new DownstreamKeyMaskTopMacroOp() { KeyIndex = Index, Top = MaskTop };

            if (Mask.HasFlag(MaskFlags.MaskBottom))
                yield return new DownstreamKeyMaskBottomMacroOp() { KeyIndex = Index, Bottom = MaskBottom };

            if (Mask.HasFlag(MaskFlags.MaskLeft))
                yield return new DownstreamKeyMaskLeftMacroOp() { KeyIndex = Index, Left = MaskLeft };

            if (Mask.HasFlag(MaskFlags.MaskRight))
                yield return new DownstreamKeyMaskRightMacroOp() { KeyIndex = Index, Right = MaskRight };
        }
    }
}