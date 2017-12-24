using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key.DVE
{
    public abstract class FlyKeyFrameMacroOpBase : MixEffectKeyMacroOpBase
    {
        [CommandId]
        [Serialize(6), Enum8]
        [MacroField("KeyFrameIndex")]
        public FlyKeyKeyFrameId KeyFrameIndex { get; set; }
    }
}