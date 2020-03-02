using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyShadowEnable, 8)]
    public class DVEKeyShadowEnableMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderShadowEnabled,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderShadowEnabled = Enable,
            };
        }
    }
}