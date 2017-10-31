using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.PatternKeyYPosition, 12)]
    public class PatternKeyYPositionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Int32D(65535, 0, 65535)] // TODO check
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
