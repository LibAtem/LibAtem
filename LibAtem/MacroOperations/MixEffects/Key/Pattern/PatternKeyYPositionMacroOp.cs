using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Pattern
{
    [MacroOperation(MacroOperationType.PatternKeyYPosition, 12)]
    public class PatternKeyYPositionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("PositionY", "yPosition")]
        public double YPosition { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyPatternSetCommand()
            {
                Mask = MixEffectKeyPatternSetCommand.MaskFlags.YPosition,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                YPosition = YPosition,
            };
        }
    }
}
