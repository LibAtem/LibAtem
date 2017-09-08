using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.HyperDeck
{
    [MacroOperation(MacroOperationType.HyperDeckStop, 8)]
    public class HyperDeckStopMacroOp : HyperDeckMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return null;// TODO
        }
    }
}