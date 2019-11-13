using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyMaskBottom, 12)]
    public class KeyMaskBottomMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65535, -9 * 65535, 9 * 65535)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyMaskSetCommand()
            {
                Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskBottom,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskBottom = Bottom,
            };
        }
    }
}