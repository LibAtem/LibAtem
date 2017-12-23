using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.FlyKeyRunToInfinity, 8)]
    public class FlyKeyRunToInfinityMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("Location")]
        public FlyKeyLocation Location { get; set; }

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