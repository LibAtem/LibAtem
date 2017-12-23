using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderSaturation, 12)]
    public class DVEKeyBorderSaturationMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), UInt32DScale(65536)]
        [MacroField("Saturation")]
        public double Saturation { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderSaturation,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderSaturation = Saturation,
            };
        }
    }
}