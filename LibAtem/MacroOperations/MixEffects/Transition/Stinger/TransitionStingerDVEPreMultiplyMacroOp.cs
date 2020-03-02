using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerDVEPreMultiply, 8)]
    public class TransitionStingerDVEPreMultiplyMacroOp : MixEffectMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("PreMultiply")]
        public bool PreMultiply { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.PreMultipliedKey,
                Index = Index,
                PreMultipliedKey = PreMultiply,
            };
        }
    }
}