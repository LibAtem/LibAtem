using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations
{
    [MacroOperation(MacroOperationType.ColorGeneratorHue, 12)]
    public class ColorGeneratorHueMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("ColorGeneratorIndex")]
        public ColorGeneratorId ColorGeneratorIndex { get; set; }

        [Serialize(8), UInt32D(65536, 0, 360 *65536)]
        [MacroField("Hue")]
        public double Hue { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new ColorGeneratorSetCommand
            {
                Mask = ColorGeneratorSetCommand.MaskFlags.Hue,
                Index = ColorGeneratorIndex,
                Hue = Hue,
            };
        }
    }
}