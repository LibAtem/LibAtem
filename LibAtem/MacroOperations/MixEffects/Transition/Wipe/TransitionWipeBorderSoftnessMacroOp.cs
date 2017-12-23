using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Wipe
{
    [MacroOperation(MacroOperationType.TransitionWipeBorderSoftness, 12)]
    public class TransitionWipeBorderSoftnessMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Softness")]
        public double BorderSoftness { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.BorderSoftness,
                Index = Index,
                BorderSoftness = BorderSoftness,
            };
        }
    }
}