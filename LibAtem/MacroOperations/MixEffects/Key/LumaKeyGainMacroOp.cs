using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.LumaKeyGain, 8)]
    public class LumaKeyGainMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, 0, 1000)] // TODO - check
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyLumaSetCommand()
            {
                Mask = MixEffectKeyLumaSetCommand.MaskFlags.Gain,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Gain = Gain,
            };
        }
    }
}