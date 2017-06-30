using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("C3sl", 4)]
    public class SDI3GLeveloutputSetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public SDI3GOutputLevel SDI3GOutputLevel { get; set; }
    }
}