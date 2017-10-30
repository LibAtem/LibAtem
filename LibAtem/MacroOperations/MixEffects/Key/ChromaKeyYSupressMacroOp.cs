using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.ChromaKeyClip, 8)]
    public class ChromaKeyYSuppressMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, 0, 1000)] // TODO - check
        [MacroField("Clip")]
        public double YSuppress { get; set; }

        public override ICommand ToCommand()
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
