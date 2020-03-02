using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionSource, 8)]
    public class TransitionSourceMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("TransitionSource", "source")]
        public TransitionLayer Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionPropertiesSetCommand()
            {
                Mask = TransitionPropertiesSetCommand.MaskFlags.NextSelection,
                Index = Index,
                NextSelection = Source,
            };
        }
    }
}