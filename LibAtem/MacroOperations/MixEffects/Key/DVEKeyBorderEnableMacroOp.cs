using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEKeyBorderEnable, 12)]
    public class DVEKeyBorderEnableMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderEnabled,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderEnabled = Enable,
            };
        }
    }
}