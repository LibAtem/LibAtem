using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Pattern
{
    [MacroOperation(MacroOperationType.PatternKeySoftness, 12)]
    public class PatternKeySoftnessMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Softness")]
        public double Softness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyPatternSetCommand()
            {
                Mask = MixEffectKeyPatternSetCommand.MaskFlags.Softness,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Softness = Softness,
            };
        }
    }
}
