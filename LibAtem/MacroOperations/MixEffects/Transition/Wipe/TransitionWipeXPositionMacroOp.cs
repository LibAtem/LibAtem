using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Wipe
{
    [MacroOperation(MacroOperationType.TransitionWipeXPosition, 12)]
    public class TransitionWipeXPositionMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("PositionX", "xPosition")]
        public double XPosition { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.XPosition,
                Index = Index,
                XPosition = XPosition,
            };
        }
    }
}