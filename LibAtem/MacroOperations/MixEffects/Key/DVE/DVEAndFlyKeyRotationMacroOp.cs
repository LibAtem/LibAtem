using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;
using System;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    [MacroOperation(MacroOperationType.DVEAndFlyKeyRotation, 12)]
    public class DVEAndFlyKeyRotationMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Int32D(65536, Int32.MinValue, Int32.MaxValue)]
        [MacroField("Rotation")]
        public double Rotation { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyDVESetCommand()
            {
                Mask = MixEffectKeyDVESetCommand.MaskFlags.Rotation,
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                Rotation = Rotation,
            };
        }
    }
}