using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderHue, 12)]
    public class DVEKeyBorderHueMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 360 * 65536)]
        [MacroField("Hue")]
        public double Hue { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderHue,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderHue = Hue,
            };
        }
    }
}