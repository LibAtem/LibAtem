using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Luma
{
    [MacroOperation(MacroOperationType.LumaKeyInvert, 8)]
    public class LumaKeyInvertMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Invert")]
        public bool Invert { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyLumaSetCommand()
            {
                Mask = MixEffectKeyLumaSetCommand.MaskFlags.Invert,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Invert = Invert,
            };
        }
    }
}