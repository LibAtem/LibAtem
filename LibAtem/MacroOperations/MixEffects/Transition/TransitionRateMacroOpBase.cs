using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    public abstract class TransitionRateMacroOpBase : MixEffectMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 250)]
        [MacroField("Rate")]
        public uint Rate { get; set; }
    }
}