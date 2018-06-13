using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderOuterSoftness, 8)]
    public class DVEKeyBorderOuterSoftnessMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("OuterSoftness")]
        public uint OuterSoftness { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderOuterSoftness,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderOuterSoftness = OuterSoftness,
            };
        }
    }
}