using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyXSize, 12)]
    public class DVEAndFlyKeyXSizeMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0 * 65536, 2 * 65536)] // TODO - check range
        [MacroField("SizeX", "xSize")]
        public double SizeX { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.SizeX,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                SizeX = SizeX,
            };
        }
    }
}