using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderInnerWidth, 8)]
    public class SuperSourceBorderInnerWidthMacroOp : MacroOpBase
    {
        [Serialize(4), UInt32D(65536, 0, 16 * 65536)]
        [MacroField("InnerWidth")]
        public double InnerWidth { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderInnerWidth,
                SSrcId = SuperSourceId.One,
                BorderInnerWidth = InnerWidth,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderInnerWidth, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BorderInnerWidthMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 16 * 65536)]
        [MacroField("InnerWidth")]
        public double InnerWidth { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderInnerWidth,
                SSrcId = SSrcId,
                BorderInnerWidth = InnerWidth,
            };
        }
    }
}