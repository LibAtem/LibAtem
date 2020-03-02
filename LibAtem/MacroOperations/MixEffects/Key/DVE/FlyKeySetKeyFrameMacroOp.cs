using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.FlyKeySetKeyFrame, 8)]
    public class FlyKeySetKeyFrameMacroOp : FlyKeyFrameMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return null;
//            return new MixEffectKeyFlyKeyframeSetCommand()
//            {
//                Mask = MixEffectKeyDVESetCommand.MaskFlags.Rate,
//                MixEffectIndex = Index,
//                KeyerIndex = KeyIndex,
//                KeyFrame = KeyFrameIndex,
//            };
        }
    }
}