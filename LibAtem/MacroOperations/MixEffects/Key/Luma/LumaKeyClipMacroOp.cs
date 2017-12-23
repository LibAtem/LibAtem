using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.Luma
{
    [MacroOperation(MacroOperationType.LumaKeyClip, 12)]
    public class LumaKeyClipMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Clip")]
        public double Clip { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyLumaSetCommand()
            {
                Mask = MixEffectKeyLumaSetCommand.MaskFlags.Clip,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Clip = Clip,
            };
        }
    }
}