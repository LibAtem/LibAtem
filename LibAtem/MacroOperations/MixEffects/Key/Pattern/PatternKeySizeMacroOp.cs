using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Pattern
{
    [MacroOperation(MacroOperationType.PatternKeySize, 12)]
    public class PatternKeySizeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Size")]
        public double Size { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyPatternSetCommand()
            {
                Mask = MixEffectKeyPatternSetCommand.MaskFlags.Size,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Size = Size,
            };
        }
    }
}
