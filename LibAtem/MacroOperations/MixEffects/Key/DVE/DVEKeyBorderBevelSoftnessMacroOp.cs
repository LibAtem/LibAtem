using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderBevelSoftness, 8)]
    public class DVEKeyBorderBevelSoftnessMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("BevelSoftness")]
        public uint BevelSoftness { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderBevelSoftness,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderBevelSoftness = BevelSoftness,
            };
        }
    }
}