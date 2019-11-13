using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyMaskLeft, 12)]
    public class DVEKeyMaskLeftMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -16 * 65536, 16 * 65536)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskLeft,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskLeft = Left,
            };
        }
    }
}