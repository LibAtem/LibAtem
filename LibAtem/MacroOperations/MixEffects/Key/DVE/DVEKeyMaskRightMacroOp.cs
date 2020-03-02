using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyMaskRight, 12)]
    public class DVEKeyMaskRightMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -16 * 65536, 16 * 65536)]
        [MacroField("Right")]
        public double Right { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskRight,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                MaskRight = Right,
            };
        }
    }
}