using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.HyperDeck
{
    [MacroOperation(MacroOperationType.HyperDeckSetSpeed, 8)]
    public class HyperDeckSetSpeedMacroOp : HyperDeckMacroOpBase
    {
        [Serialize(6), UInt16Range(0, 100)]
        [MacroField("HyperDeckSpeedPercent", "speedPercent")]
        public uint SpeedPercent { get; set; }

        public override ICommand ToCommand()
        {
            return null;// TODO
        }
    }
}