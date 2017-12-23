using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Chroma
{
    [MacroOperation(MacroOperationType.ChromaKeyGain, 12)]
    public class ChromaKeyGainMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
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