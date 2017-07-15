using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("V3sl", 4), NoCommandId]
    public class SDI3GLevelOutputGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public SDI3GOutputLevel SDI3GOutputLevel { get; set; }
    }
}