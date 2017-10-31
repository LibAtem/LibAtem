using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyFillInput, 8)]
    public class DownstreamKeyFillInputMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Input { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyFillSourceSetCommand()
            {
                Index = KeyIndex,
                Source = Input,
            };
        }
    }
}