using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderInnerSoftness, 8)]
    public class SuperSourceBorderInnerSoftnessMacroOp : MacroOpBase
    {
        [Serialize(4), UInt8Range(0, 100)]
        [MacroField("InnerSoftness")]
        public uint InnerSoftness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderInnerSoftness,
                SSrcId = SuperSourceId.One,
                BorderInnerSoftness = InnerSoftness,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderInnerSoftness, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2BorderInnerSoftnessMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("InnerSoftness")]
        public uint InnerSoftness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderInnerSoftness,
                SSrcId = SSrcId,
                BorderInnerSoftness = InnerSoftness,
            };
        }
    }
}