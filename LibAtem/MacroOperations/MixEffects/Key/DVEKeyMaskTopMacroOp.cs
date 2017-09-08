using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEKeyMaskTop, 12)]
    public class DVEKeyMaskTopMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int16D(1000, -9000, 9000)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskTop,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskTop = Top,
            };
        }
    }
}