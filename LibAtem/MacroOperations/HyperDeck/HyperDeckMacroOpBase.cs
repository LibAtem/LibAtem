using LibAtem.Commands;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.HyperDeck
{
    public abstract class HyperDeckMacroOpBase : MacroOpBase
    {
        [CommandId]
        [Serialize(4), UInt8Range(0, 3)]
        [MacroField("HyperDeckIndex")]
        public uint Index { get; set; }
    }
}