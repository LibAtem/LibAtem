using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Media
{
    [MacroOperation(MacroOperationType.MediaPlayerGoToFrame, 8)]
    public class MediaPlayerGoToFrameMacroOp : MediaPlayerMacroOpBase
    {
        [Serialize(6), UInt16]
        [MacroField("Frame")]
        public uint Frame { get; set; }

        public override ICommand ToCommand()
        {
            return null;// TODO
        }
    }
}