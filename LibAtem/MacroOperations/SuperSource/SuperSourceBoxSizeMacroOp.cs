using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxSize, 12)]
    public class SuperSourceBoxSizeMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, (int)(0.07 * 65536), 65536)]
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