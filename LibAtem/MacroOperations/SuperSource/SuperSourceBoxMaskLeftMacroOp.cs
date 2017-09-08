using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskLeft, 12)]
    public class SuperSourceBoxMaskLeftMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(6), UInt16D(1000, 0, 32000)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropLeft,
                Index = BoxIndex,
                CropLeft = Left,
            };
        }
    }
}