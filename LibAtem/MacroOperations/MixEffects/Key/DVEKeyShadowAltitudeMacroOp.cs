using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEKeyShadowAltitude, 8)]
    public class DVEKeyShadowAltitudeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt16D(1, 0, 100)]
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
