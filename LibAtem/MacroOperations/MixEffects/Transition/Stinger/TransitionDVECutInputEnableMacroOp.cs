using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionDVECutInputEnable, 8)]
    public class TransitionDVECutInputEnableMacroOp : MixEffectMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionDVESetCommand
            {
                Mask = TransitionDVESetCommand.MaskFlags.EnableKey,
                Index = Index,
                EnableKey = Enable,
            };
        }
    }
}