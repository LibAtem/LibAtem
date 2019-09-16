using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Chroma
{
    [MacroOperation(MacroOperationType.ChromaKeyLift, 12)]
    public class ChromaKeyLiftMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Lift")]
        public double Lift { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
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
}