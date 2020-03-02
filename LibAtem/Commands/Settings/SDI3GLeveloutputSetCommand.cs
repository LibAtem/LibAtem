using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("C3sl", CommandDirection.ToServer, 4), NoCommandId]
    public class SDI3GLevelOutputSetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public SDI3GOutputLevel SDI3GOutputLevel { get; set; }
    }
}