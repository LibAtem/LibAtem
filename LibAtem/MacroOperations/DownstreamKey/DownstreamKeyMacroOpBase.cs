using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    public abstract class DownstreamKeyMacroOpBase : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum8]
        [MacroField("DownstreamKeyIndex", "keyIndex")]
        public DownstreamKeyId KeyIndex { get; set; }
    }
}