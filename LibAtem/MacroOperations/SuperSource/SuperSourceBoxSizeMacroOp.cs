using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxSize, 12)]
    public class SuperSourceBoxSizeMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(6), UInt16D(1000, 70, 1000)]
        [MacroField("Size")]
        public double Size { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.Size,
                Index = BoxIndex,
                Size = Size,
            };
        }
    }
}