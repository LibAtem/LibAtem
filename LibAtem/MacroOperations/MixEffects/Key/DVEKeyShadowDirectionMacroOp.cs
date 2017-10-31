using System;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.DVEKeyShadowDirection, 12)]
    public class DVEKeyShadowDirectionMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), UInt32D(15979513, 0, UInt32.MaxValue)]
        [MacroField("Direction")]
        public double Direction { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.LightSourceDirection,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                LightSourceDirection = Direction,
            };
        }
    }
}
