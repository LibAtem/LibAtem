using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Wipe
{
    [MacroOperation(MacroOperationType.TransitionWipeBorderWidth, 12)]
    public class TransitionWipeBorderWidthMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Width")]
        public double BorderWidth { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.BorderWidth,
                Index = Index,
                BorderWidth = BorderWidth,
            };
        }
    }
}