using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyYPosition, 12)]
    public class DVEAndFlyKeyYPositionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -48 * 65536, 48 * 65536)] // TODO - check range
        [MacroField("PositionY", "yPosition")]
        public double PositionY { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.PositionY,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                PositionY = PositionY,
            };
        }
    }
}