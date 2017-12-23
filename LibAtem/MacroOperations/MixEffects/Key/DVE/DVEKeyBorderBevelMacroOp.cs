using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderBevel, 8)]
    public class DVEKeyBorderBevelMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("Bevel")]
        public BorderBevel Bevel { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderBevel,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderBevel = Bevel,
            };
        }
    }
}