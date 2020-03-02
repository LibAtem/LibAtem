using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.Media
{
    [MacroOperation(MacroOperationType.MediaPlayerPlay, 8)]
    public class MediaPlayerPlayMacroOp : MediaPlayerMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return null;// TODO
        }
    }
}