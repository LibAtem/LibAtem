using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerClipDuration, 8)]
    public class TransitionStingerClipDurationMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt16]
        [MacroField("ClipDuration")]
        public uint ClipDuration { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.ClipDuration,
                Index = Index,
                ClipDuration = ClipDuration,
            };
        }
    }
}