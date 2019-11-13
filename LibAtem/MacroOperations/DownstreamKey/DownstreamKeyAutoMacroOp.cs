using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyAuto, 8)]
    public class DownstreamKeyAutoMacroOp : DownstreamKeyMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyAutoCommand()
            {
                Index = KeyIndex,
            };
        }
    }
}