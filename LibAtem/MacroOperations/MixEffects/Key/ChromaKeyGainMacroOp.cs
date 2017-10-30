using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.ChromaKeyGain, 8)]
    public class ChromaKeyGainMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, 0, 1000)] // TODO - check
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyChromaSetCommand()
            {
                Mask = MixEffectKeyChromaSetCommand.MaskFlags.Gain,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Gain = Gain,
            };
        }
    }
}