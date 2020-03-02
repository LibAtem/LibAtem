using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderLuminescence, 12)]
    public class DVEKeyBorderLuminescenceMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Luminescence")]
        public double Luma { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderLuma,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BorderLuma = Luma,
            };
        }
    }
}