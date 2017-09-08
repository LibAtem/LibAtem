using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.HyperDeck
{
    [MacroOperation(MacroOperationType.HyperDeckSetSingleClip, 8)]
    public class HyperDeckSetSingleClipMacroOp : HyperDeckMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("HyperDeckSingleClipEnabled", "singleClipEnabled")]
        public bool SingleClipEnabled { get; set; }

        public override ICommand ToCommand()
        {
            return null;// TODO
        }
    }
}