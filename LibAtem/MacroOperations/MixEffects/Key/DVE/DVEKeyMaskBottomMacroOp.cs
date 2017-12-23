using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyMaskBottom, 12)]
    public class DVEKeyMaskBottomMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -9 * 65536, 9 * 65536)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskBottom,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskBottom = Bottom,
            };
        }
    }
}