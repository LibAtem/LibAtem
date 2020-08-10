using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("AiVM", CommandDirection.Both, 4), NoCommandId]
    public class AutoVideoModeCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool Enabled { get; set; }

        [Serialize(1), Bool]
        public bool Detected { get; set; }

    }
}