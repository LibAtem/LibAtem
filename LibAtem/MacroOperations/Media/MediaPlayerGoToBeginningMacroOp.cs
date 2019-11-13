using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.Media
{
    [MacroOperation(MacroOperationType.MediaPlayerGoToBeginning, 8)]
    public class MediaPlayerGoToBeginningMacroOp : MediaPlayerMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return null;// TODO
        }
    }
}