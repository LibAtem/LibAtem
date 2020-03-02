using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderInnerSoftness, 8)]
    public class DVEKeyBorderInnerSoftnessMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("InnerSoftness")]
        public uint InnerSoftness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderInnerSoftness,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderInnerSoftness = InnerSoftness,
            };
        }
    }
}