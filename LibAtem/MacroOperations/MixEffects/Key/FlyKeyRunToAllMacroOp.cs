using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.FlyKeyRunToFull, 8)]
    public class FlyKeyRunToAllMacroOp : MixEffectKeyMacroOpBase
    {
        public override ICommand ToCommand()
        {
            //            return new MixEffectKeyPatternSetCommand()
            //            {
            //                Mask = MixEffectKeyPatternSetCommand.MaskFlags.YPosition,
            //                MixEffectIndex = Index,
            //                KeyerIndex = KeyIndex,
            //                YPosition = YPosition,
            //            };
            return null;
        }
    }
}