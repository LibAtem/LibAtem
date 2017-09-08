using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyOnAir, 12)]
    public class KeyOnAirMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Bool]
        [MacroField("OnAir")]
        public bool OnAir { get; set; }

        public override ICommand ToCommand()
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