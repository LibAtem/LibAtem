using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyXPosition, 12)]
    public class DVEAndFlyKeyXPositionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -48 * 65536, 48 * 65536)] // TODO - check range
        [MacroField("PositionX", "xPosition")]
        public double PositionX { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.PositionX,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                PositionX = PositionX,
            };
        }
    }
}