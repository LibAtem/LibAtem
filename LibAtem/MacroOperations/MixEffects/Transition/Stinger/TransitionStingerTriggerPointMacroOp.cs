using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerTriggerPoint, 8)]
    public class TransitionStingerTriggerPointMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt16]
        [MacroField("TriggerPoint")]
        public uint TriggerPoint { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.TriggerPoint,
                Index = Index,
                TriggerPoint = TriggerPoint,
            };
        }
    }
}