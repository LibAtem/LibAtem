using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_pin", 44), NoCommandId]
    public class ProductIdentifierCommand : SerializableCommandBase
    {
        [Serialize(0), String(40)]
        public string Name { get; set; }
        [Serialize(40), Enum8]
        public ModelId Model { get; set; }
    }
}