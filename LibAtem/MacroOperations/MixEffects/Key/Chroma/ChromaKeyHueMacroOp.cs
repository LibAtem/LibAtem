using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Chroma
{
    [MacroOperation(MacroOperationType.ChromaKeyHue, 12)]
    public class ChromaKeyHueMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 65536 * 360)]
        [MacroField("Hue")]
        public double Hue { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyChromaSetCommand()
            {
                Mask = MixEffectKeyChromaSetCommand.MaskFlags.Hue,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Hue = Hue,
            };
        }
    }
}