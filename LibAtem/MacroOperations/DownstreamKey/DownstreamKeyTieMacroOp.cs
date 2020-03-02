using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyTie, 8)]
    public class DownstreamKeyTieMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Tie")]
        public bool Tie { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyTieSetCommand()
            {
                Index = KeyIndex,
                Tie = Tie,
            };
        }
    }
}