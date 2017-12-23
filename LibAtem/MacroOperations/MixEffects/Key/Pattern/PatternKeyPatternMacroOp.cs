using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Pattern
{
    [MacroOperation(MacroOperationType.PatternKeyPattern, 8)]
    public class PatternKeyPatternMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("PatternKeyPattern", "pattern")]
        public Common.Pattern Pattern { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyPatternSetCommand()
            {
                Mask = MixEffectKeyPatternSetCommand.MaskFlags.Pattern,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Pattern = Pattern,
            };
        }
    }
}
