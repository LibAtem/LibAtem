using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionPreview, 8)]
    public class TransitionPreviewMacroOp : MixEffectMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Preview")]
        public bool Preview { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionPreviewSetCommand
            {
                Index = Index,
                PreviewTransition = Preview,
            };
        }
    }
}