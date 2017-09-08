using LibAtem.Commands;
using LibAtem.Commands.Media;
using LibAtem.Common;

namespace LibAtem.MacroOperations.Media
{

    [MacroOperation(MacroOperationType.MediaPlayerSourceStill, 8)]
    public class MediaPlayerSourceStillMacroOp : MediaPlayerMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return new MediaPlayerSourceSetCommand()
            {
                Mask = MediaPlayerSourceSetCommand.MaskFlags.SourceType,
                Index = Index,
                SourceType = MediaPlayerSource.Still,
            };
        }
    }
}