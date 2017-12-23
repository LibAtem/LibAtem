using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Chroma
{
    [MacroOperation(MacroOperationType.ChromaKeyNarrow, 8)]
    public class ChromaKeyNarrowMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Narrow")]
        public bool Narrow { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyChromaSetCommand()
            {
                Mask = MixEffectKeyChromaSetCommand.MaskFlags.Narrow,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Narrow = Narrow,
            };
        }
    }
}
