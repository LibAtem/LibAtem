using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Chroma
{
    [MacroOperation(MacroOperationType.ChromaKeyClip, 12)]
    public class ChromaKeyYSuppressMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Clip")]
        public double YSuppress { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyChromaSetCommand()
            {
                Mask = MixEffectKeyChromaSetCommand.MaskFlags.YSuppress,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                YSuppress = YSuppress,
            };
        }
    }
}
