using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("CClV", CommandDirection.ToServer, 8)]
    public class ColorGeneratorSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Hue = 1 << 0,
            Saturation = 1 << 1,
            Luma = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public ColorGeneratorId Index { get; set; }

        [Serialize(2), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }

        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Saturation { get; set; }

        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Luma { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.Hue))
                yield return new ColorGeneratorHueMacroOp { ColorGeneratorIndex = Index, Hue = Hue };
            if (Mask.HasFlag(MaskFlags.Saturation))
                yield return new ColorGeneratorSaturationMacroOp { ColorGeneratorIndex = Index, Saturation = Saturation };
            if (Mask.HasFlag(MaskFlags.Luma))
                yield return new ColorGeneratorLuminescenceMacroOp { ColorGeneratorIndex = Index, Luma = Luma };
        }
    }
}