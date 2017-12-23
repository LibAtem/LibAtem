using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.FlyKeySetKeyFrame, 8)]
    public class FlyKeySetKeyFrameMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("KeyFrameIndex")]
        public FlyKeyKeyFrameId KeyFrameIndex { get; set; }

        public override ICommand ToCommand()
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