using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskRight, 12)]
    public class SuperSourceBoxMaskRightMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(6), UInt16D(1000, 0, 32000)]
        [MacroField("Right")]
        public double Right { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropRight,
                Index = BoxIndex,
                CropRight = Right,
            };
        }
    }
}