using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEKeyBorderBevelPosition, 8)]
    public class DVEKeyBorderBevelPositionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("BevelPosition")]
        public uint BevelPosition { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderBevelPosition,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                BevelPosition = BevelPosition,
            };
        }
    }
}