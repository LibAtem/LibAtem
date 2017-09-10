using LibAtem.Commands;
using LibAtem.Commands.Media;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Media
{
    [MacroOperation(MacroOperationType.MediaPlayerSourceStillIndex, 8)]
    public class MediaPlayerSourceStillIndexMacroOp : MediaPlayerMacroOpBase
    {
        [Serialize(6), UInt16]
        [MacroField("Index")]
        public uint MediaIndex { get; set; }

        public override ICommand ToCommand()
        {
            return new MediaPlayerSourceSetCommand()
            {
                Mask = MediaPlayerSourceSetCommand.MaskFlags.StillIndex,
                Index = Index,
                StillIndex = MediaIndex,
            };
        }
    }
}