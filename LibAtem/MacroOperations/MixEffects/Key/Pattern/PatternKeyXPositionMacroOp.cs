using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Pattern
{
    [MacroOperation(MacroOperationType.PatternKeyXPosition, 12)]
    public class PatternKeyXPositionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("PositionX", "xPosition")]
        public double XPosition { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyPatternSetCommand()
            {
                Mask = MixEffectKeyPatternSetCommand.MaskFlags.XPosition,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                XPosition = XPosition,
            };
        }
    }
}
