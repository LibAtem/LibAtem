using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyMaskBottom, 12)]
    public class KeyMaskBottomMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int16D(1000, -9000, 9000)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyMaskSetCommand()
            {
                Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskBottom,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskBottom = Bottom,
            };
        }
    }
}