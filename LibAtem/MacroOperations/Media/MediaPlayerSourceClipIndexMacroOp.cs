using LibAtem.Commands;
using LibAtem.Commands.Media;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Media
{
    [MacroOperation(MacroOperationType.MediaPlayerSourceClipIndex, 8)]
    public class MediaPlayerSourceClipIndexMacroOp : MediaPlayerMacroOpBase
    {
        [Serialize(6), UInt8]
        [MacroField("Index")]
        public uint MediaIndex { get; set; }

        public override ICommand ToCommand()
        {
            return new MediaPlayerSourceSetCommand()
            {
                Mask = MediaPlayerSourceSetCommand.MaskFlags.ClipIndex,
                Index = Index,
                ClipIndex = MediaIndex,
            };
        }
    }
}