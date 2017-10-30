using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.LumaKeyClip, 8)]
    public class LumaKeyClipMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, 0, 1000)] // TODO - check
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

    [MacroOperation(MacroOperationType.ChromaKeyHue, 8)]
    public class ChromaKeyHueMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, 0, 1000)] // TODO - check
        [MacroField("Hue")]
        public double Hue { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyChromaSetCommand()
            {
                Mask = MixEffectKeyChromaSetCommand.MaskFlags.Hue,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Hue = Hue,
            };
        }
    }
}