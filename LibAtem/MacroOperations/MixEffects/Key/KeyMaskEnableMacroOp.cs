using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyMaskEnable, 12)]
    public class KeyMaskEnableMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyMaskSetCommand()
            {
                Mask = MixEffectKeyMaskSetCommand.MaskFlags.Enabled,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskEnabled = Enable,
            };
        }
    }
}