using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Luma
{
    [MacroOperation(MacroOperationType.LumaKeyGain, 12)]
    public class LumaKeyGainMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyLumaSetCommand()
            {
                Mask = MixEffectKeyLumaSetCommand.MaskFlags.Gain,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Gain = Gain,
            };
        }
    }
}