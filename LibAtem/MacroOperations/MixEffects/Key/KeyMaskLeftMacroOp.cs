using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyMaskLeft, 12)]
    public class KeyMaskLeftMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int16D(1000, -16000, 16000)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyMaskSetCommand()
            {
                Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskLeft,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskLeft = Left,
            };
        }
    }
}