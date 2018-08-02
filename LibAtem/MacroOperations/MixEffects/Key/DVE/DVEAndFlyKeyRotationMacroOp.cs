using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyRotation, 12)]
    public class DVEAndFlyKeyRotationMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -32768 * 65536, 32767 * 65536)]
        [MacroField("Rotation")]
        public double Rotation { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.Rotation,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Rotation = Rotation,
            };
        }
    }
}