using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("DcOt", CommandDirection.ToClient, 4), NoCommandId]
    public class DownConvertModeGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public DownConvertMode DownConvertMode { get; set; }
    }
}