using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyRate, 8)]
    public class DVEAndFlyKeyRateMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt16]
        [MacroField("Rate")]
        public uint Rate { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.Rate,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Rate = Rate,
            };
        }
    }
}