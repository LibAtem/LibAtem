using System;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.ChromaKeyHue, 12)]
    public class ChromaKeyHueMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32D(30948313, 0, UInt32.MaxValue)]
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