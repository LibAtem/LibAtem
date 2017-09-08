using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEKeyShadowEnable, 12)]
    public class DVEKeyShadowEnableMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.ShadowEnabled,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                ShadowEnabled = Enable,
            };
        }
    }
}