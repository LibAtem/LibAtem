using LibAtem.Commands.MixEffects;
using LibAtem.Common;
using LibAtem.Commands;

namespace LibAtem.MacroOperations.MixEffects
{
    [MacroOperation(MacroOperationType.CutTransition, 8)]
    public class CutTransitionMacroOp : MixEffectMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectCutCommand()
            {
                Index = Index,
            };
        }
    }
}
