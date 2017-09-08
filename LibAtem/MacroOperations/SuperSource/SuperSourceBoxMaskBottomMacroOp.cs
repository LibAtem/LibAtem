using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskBottom, 12)]
    public class SuperSourceBoxMaskBottomMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(6), UInt16D(1000, 0, 18000)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropBottom,
                Index = BoxIndex,
                CropBottom = Bottom,
            };
        }
    }
}