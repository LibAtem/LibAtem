using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderInnerWidth, 12)]
    public class DVEKeyBorderInnerWidthMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 16 * 65536)]
        [MacroField("InnerWidth")]
        public double InnerWidth { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderInnerWidth,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderInnerWidth = InnerWidth,
            };
        }
    }
}