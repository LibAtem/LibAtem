using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.DownStreamKey;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DDsA", CommandDirection.ToServer, ProtocolVersion.V8_0, 4)]
    public class DownstreamKeyAutoV8Command : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            IsTowardsOnAir = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(2), Bool]
        public bool IsTowardsOnAir { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            // TODO - if has IsTowardsOnAir

            yield return new DownstreamKeyAutoMacroOp { KeyIndex = Index };
        }
    }
}