using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyYSize, 12)]
    public class DVEAndFlyKeyYSizeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0 * 65536, 2 * 65536)] // TODO - check range
        [MacroField("SizeY", "ySize")]
        public double SizeY { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.SizeY,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                SizeY = SizeY,
            };
        }
    }
}