using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Media
{
    [MacroOperation(MacroOperationType.MediaPlayerLoop, 8)]
    public class MediaPlayerLoopMacroOp : MediaPlayerMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Loop")]
        public bool Loop { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return null;// TODO
        }
    }
}