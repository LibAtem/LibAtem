using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyShadowDirection, 12)]
    public class DVEKeyShadowDirectionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 65536 * 360)]
        [MacroField("Direction")]
        public double Direction { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.LightSourceDirection,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                LightSourceDirection = Direction,
            };
        }
    }
}
