using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderLuminescence, 8)]
    public class SuperSourceBorderLuminescenceMacroOp : MacroOpBase
    {
        [Serialize(4), UInt32DScale]
        [MacroField("Luma")]
        public double Luma { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderLuma,
                SSrcId = SuperSourceId.One,
                BorderLuma = Luma,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderLuminescence, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BorderLuminescenceMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt32DScale]
        [MacroField("Luma")]
        public double Luma { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BorderLuma,
                SSrcId = SSrcId,
                BorderLuma = Luma,
            };
        }
    }
}