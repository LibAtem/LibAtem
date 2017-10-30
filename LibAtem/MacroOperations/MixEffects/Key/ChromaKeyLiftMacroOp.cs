using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.ChromaKeyLift, 8)]
    public class ChromaKeyLiftMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, 0, 1000)] // TODO - check
        [MacroField("Lift")]
        public double Lift { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyChromaSetCommand()
            {
                Mask = MixEffectKeyChromaSetCommand.MaskFlags.Lift,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Lift = Lift,
            };
        }
    }

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