using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    public abstract class DownstreamKeyMacroOpBase : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("KeyIndex")]
        public DownstreamKeyId KeyIndex { get; set; }
    }
}