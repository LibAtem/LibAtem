using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderOuterWidth, 12)]
    public class DVEKeyBorderOuterWidthMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 16 * 65536)]
        [MacroField("OuterWidth")]
        public double OuterWidth { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderOuterWidth,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderOuterWidth = OuterWidth,
            };
        }
    }
}