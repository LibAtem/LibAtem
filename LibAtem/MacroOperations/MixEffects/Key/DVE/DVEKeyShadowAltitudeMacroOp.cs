using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyShadowAltitude, 8)]
    public class DVEKeyShadowAltitudeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt8Range(10, 100)]
        [MacroField("Altitude")]
        public uint Altitude { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
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
