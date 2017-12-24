using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.Media
{
    [MacroOperation(MacroOperationType.MediaPlayerPause, 8)]
    public class MediaPlayerPauseMacroOp : MediaPlayerMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return null;// TODO
        }
    }
}