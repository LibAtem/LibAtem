using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyMaskTop, 12)]
    public class DVEKeyMaskTopMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -9 * 65536, 9 * 65536)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskTop,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskTop = Top,
            };
        }
    }
}