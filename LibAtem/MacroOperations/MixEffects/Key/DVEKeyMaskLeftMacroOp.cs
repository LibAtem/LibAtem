using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEKeyMaskLeft, 12)]
    public class DVEKeyMaskLeftMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int16D(1000, -16000, 16000)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskLeft,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskLeft = Left,
            };
        }
    }
}