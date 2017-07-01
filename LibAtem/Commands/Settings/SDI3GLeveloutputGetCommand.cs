using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("V3sl", 4)]
    public class SDI3GLeveloutputGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public SDI3GOutputLevel SDI3GOutputLevel { get; set; }
    }
}