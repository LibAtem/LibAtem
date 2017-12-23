using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderEnable, 8)]
    public class DVEKeyBorderEnableMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Bool]
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