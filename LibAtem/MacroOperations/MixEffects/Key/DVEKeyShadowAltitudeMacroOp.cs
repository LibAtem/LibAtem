using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEKeyShadowAltitude, 12)]
    public class DVEKeyShadowAltitudeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32D(65535, 0, 360 * 65535)]
        [MacroField("Altitude")]
        public double Altitude { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.LightSourceAltitude,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                LightSourceAltitude = Altitude,
            };
        }
    }
}
