using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyMaskEnable, 8)]
    public class DVEKeyMaskEnableMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskEnabled,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskEnabled = Enable,
            };
        }
    }
}