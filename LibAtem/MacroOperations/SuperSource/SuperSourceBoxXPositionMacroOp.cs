using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxXPosition, 12)]
    public class SuperSourceBoxXPositionMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(6), Int16D(100, -4800, 4800)]
        [MacroField("PositionX", "xPosition")]
        public double PositionX { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.PositionX,
                Index = BoxIndex,
                PositionX = PositionX,
            };
        }
    }
}