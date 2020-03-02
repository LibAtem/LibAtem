using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.DownStreamKey;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsR", CommandDirection.ToServer, 4)]
    public class DownstreamKeyRateSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(1), UInt8Range(0, 250)]
        public uint Rate { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new DownstreamKeyRateMacroOp
            {
                KeyIndex = Index,
                Rate = Rate,
            };
        }
    }
}