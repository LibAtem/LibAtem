using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.FlyKeyRunToKeyFrame, 8)]
    public class FlyKeyRunToKeyFrameMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("KeyFrameIndex")]
        public FlyKeyKeyFrameId KeyFrameIndex { get; set; }

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