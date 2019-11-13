using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyXPosition, 12)]
    public class DVEAndFlyKeyXPositionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, -1000 * 65536, 1000 * 65536)]
        [MacroField("PositionX", "xPosition")]
        public double PositionX { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
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