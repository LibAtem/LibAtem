using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations
{
    [MacroOperation(MacroOperationType.ColorGeneratorSaturation, 12)]
    public class ColorGeneratorSaturationMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("ColorGeneratorIndex")]
        public ColorGeneratorId ColorGeneratorIndex { get; set; }

        [Serialize(6), UInt32DScale]
        [MacroField("Saturation")]
        public double Saturation { get; set; }

        public override ICommand ToCommand()
        {
            return new ColorGeneratorSetCommand
            {
                Mask = ColorGeneratorSetCommand.MaskFlags.Saturation,
                Index = ColorGeneratorIndex,
                Saturation = Saturation,
            };
        }
    }
}