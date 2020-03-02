using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations
{
    [MacroOperation(MacroOperationType.ColorGeneratorLuminescence, 12)]
    public class ColorGeneratorLuminescenceMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("ColorGeneratorIndex")]
        public ColorGeneratorId ColorGeneratorIndex { get; set; }

        [Serialize(6), UInt32DScale]
        [MacroField("Luminescence")]
        public double Luma { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new ColorGeneratorSetCommand
            {
                Mask = ColorGeneratorSetCommand.MaskFlags.Luma,
                Index = ColorGeneratorIndex,
                Luma = Luma,
            };
        }
    }
}