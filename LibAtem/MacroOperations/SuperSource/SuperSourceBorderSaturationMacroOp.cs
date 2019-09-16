using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderSaturation, 8)]
    public class SuperSourceBorderSaturationMacroOp : MacroOpBase
    {
        [Serialize(4), UInt32DScale(65536)]
        [MacroField("Saturation")]
        public double Saturation { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderSaturation,
                SSrcId = SuperSourceId.One,
                BorderSaturation = Saturation,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderSaturation, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BorderSaturationMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt32DScale(65536)]
        [MacroField("Saturation")]
        public double Saturation { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderSaturation,
                SSrcId = SSrcId,
                BorderSaturation = Saturation,
            };
        }
    }
}