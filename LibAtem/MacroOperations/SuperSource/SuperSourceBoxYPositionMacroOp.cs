using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxYPosition, 12)]
    public class SuperSourceBoxYPositionMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, -48 * 65536, 48 * 65536)]
        [MacroField("PositionY", "yPosition")]
        public double PositionY { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.PositionY,
                Index = BoxIndex,
                PositionY = PositionY,
            };
        }
    }
}