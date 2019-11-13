using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Settings;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("SPtM", 4), NoCommandId]
    public class SerialPortModeCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public SerialMode SerialMode { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new SetSerialPortFunctionMacroOp
            {
                SerialMode = SerialMode,
            };
        }
    }
}