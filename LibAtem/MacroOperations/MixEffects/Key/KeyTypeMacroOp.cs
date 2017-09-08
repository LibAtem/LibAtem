using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyType, 12)]
    public class KeyTypeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Enum16]
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

    [MacroOperation(MacroOperationType.LumaKeyPreMultiply, 12)]
    public class LumaKeyPreMultiplyMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Bool]
        [MacroField("PreMultiply")]
        public bool PreMultiply { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyLumaSetCommand()
            {
                Mask = MixEffectKeyLumaSetCommand.MaskFlags.PreMultiplied,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                PreMultiplied = PreMultiply,
            };
        }
    }
}