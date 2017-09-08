using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.HyperDeck
{
    [MacroOperation(MacroOperationType.HyperDeckPlay, 8)]
    public class HyperDeckPlayMacroOp : HyperDeckMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return null;// TODO
        }
    }
}