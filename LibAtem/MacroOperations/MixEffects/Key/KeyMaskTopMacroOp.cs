using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyMaskTop, 12)]
    public class KeyMaskTopMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int16D(1000, -9000, 9000)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyMaskSetCommand()
            {
                Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskTop,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskTop = Top,
            };
        }
    }
}