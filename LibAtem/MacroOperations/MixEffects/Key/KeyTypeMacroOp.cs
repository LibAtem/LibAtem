using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyType, 8)]
    public class KeyTypeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("KeyType", "type")]
        public MixEffectKeyType KeyType { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyTypeSetCommand()
            {
                Mask = MixEffectKeyTypeSetCommand.MaskFlags.Type,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                KeyType = KeyType,
            };
        }
    }
}