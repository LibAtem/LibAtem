using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskTop, 12)]
    public class SuperSourceBoxMaskTopMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(6), UInt16D(1000, 0, 18000)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropTop,
                Index = BoxIndex,
                CropTop = Top,
            };
        }
    }
}