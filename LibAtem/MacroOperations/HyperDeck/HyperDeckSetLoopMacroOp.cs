using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.HyperDeck
{
    [MacroOperation(MacroOperationType.HyperDeckSetLoop, 8)]
    public class HyperDeckSetLoopMacroOp : HyperDeckMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("HyperDeckLoopEnabled", "loopEnabled")]
        public bool Loop { get; set; }

        public override ICommand ToCommand()
        {
            return null;// TODO
        }
    }
}