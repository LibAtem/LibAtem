using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionPreview, 8)]
    public class TransitionPreviewMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Preview")]
        public bool Preview { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionPreviewSetCommand
            {
                Index = Index,
                PreviewTransition = Preview,
            };
        }
    }
}