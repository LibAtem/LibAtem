using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.DownStreamKey;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsF", CommandDirection.ToServer, 4)]
    public class DownstreamKeyFillSourceSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(2), Enum16]
        public VideoSource FillSource { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new DownstreamKeyFillInputMacroOp
            {
                KeyIndex = Index,
                Input = FillSource,
            };
        }
    }
}