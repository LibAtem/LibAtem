using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyMaskTop, 12)]
    public class KeyMaskTopMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65535, -9 * 65535, 9 * 65535)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyMaskSetCommand()
            {
                Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskTop,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskTop = Top,
            };
        }
    }
}