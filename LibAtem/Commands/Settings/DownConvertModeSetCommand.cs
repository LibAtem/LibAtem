using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Settings;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CDcO", CommandDirection.ToServer, 4), NoCommandId]
    public class DownConvertModeSetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public DownConvertMode DownConvertMode { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new DownConvertModeMacroOp { DownConvertMode = DownConvertMode };
        }
    }
}