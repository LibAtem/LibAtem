using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.DownStreamKey;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsC", 4)]
    public class DownstreamKeyCutSourceSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            yield return new DownstreamKeyCutInputMacroOp
            {
                KeyIndex = Index,
                Input = Source,
            };
        }
    }
}