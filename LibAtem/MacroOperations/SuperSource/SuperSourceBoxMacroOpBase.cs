using LibAtem.Commands;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    public abstract class SuperSourceBoxMacroOpBase : MacroOpBase
    {
        [CommandId]
        [Serialize(4), UInt8]
        [MacroField("SuperSourceBoxIndex", "boxIndex")]
        public uint BoxIndex { get; set; }
    }
}