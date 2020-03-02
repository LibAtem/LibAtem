using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects
{
    [MacroOperation(MacroOperationType.AutoTransition, 8)]
    public class AutoTransitionMacroOp : MixEffectMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectAutoCommand()
            {
                Index = Index,
            };
        }
    }
}