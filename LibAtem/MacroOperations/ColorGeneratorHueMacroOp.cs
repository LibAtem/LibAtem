using System;
using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations
{
    [MacroOperation(MacroOperationType.ColorGeneratorHue, 12)]
    public class ColorGeneratorHueMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), UInt16]
        [MacroField("ColorGeneratorIndex")]
        public uint ColorGeneratorIndex { get; set; }

        [Serialize(6), UInt32D(1, 0, UInt32.MaxValue)]
        [MacroField("Hue")]
        public double Hue { get; set; }

        public override ICommand ToCommand()
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