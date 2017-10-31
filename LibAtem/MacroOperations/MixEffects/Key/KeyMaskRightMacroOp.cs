using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyMaskRight, 12)]
    public class KeyMaskRightMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65535, -16 * 65535, 16 * 65535)]
        [MacroField("Right")]
        public double Right { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyMaskSetCommand()
            {
                Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskRight,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskRight = Right,
            };
        }
    }
}