using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.FlyKeyRunToKeyFrame, 8)]
    public class FlyKeyRunToKeyFrameMacroOp : FlyKeyFrameMacroOpBase
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