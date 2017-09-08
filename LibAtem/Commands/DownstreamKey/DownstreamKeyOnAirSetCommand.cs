using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.DownStreamKey;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsL", 4)]
    public class DownstreamKeyOnAirSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(1), Bool]
        public bool OnAir { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            yield return new DownstreamKeyOnAirMacroOp()
            {
                KeyIndex = Index,
                OnAir = OnAir,
            };
        }
    }
}