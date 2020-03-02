using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerPreRoll, 8)]
    public class TransitionStingerPreRollMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 250)]
        [MacroField("PreRoll")]
        public uint Preroll { get; set; }
        
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.Preroll,
                Index = Index,
                Preroll = Preroll,
            };
        }
    }
}