using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects
{
    [MacroOperation(MacroOperationType.FadeToBlackAuto, 8)]
    public class FadeToBlackAutoMacroOp : MixEffectMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new FadeToBlackAutoCommand()
            {
                Index = Index,
            };
        }
    }
}