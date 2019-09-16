using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyOnAir, 8)]
    public class KeyOnAirMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("OnAir")]
        public bool OnAir { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyOnAirSetCommand()
            {
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                OnAir = OnAir,
            };
        }
    }
}