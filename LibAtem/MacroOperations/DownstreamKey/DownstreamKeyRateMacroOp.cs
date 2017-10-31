using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyRate, 8)]
    public class DownstreamKeyRateMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), UInt16]
        [MacroField("Rate")]
        public uint Rate { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyRateSetCommand()
            {
                Index = KeyIndex,
                Rate = Rate,
            };
        }
    }
}