using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("AiVM", CommandDirection.ToServer, 4), NoCommandId]
    public class AutoVideoModeCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool Enabled { get; set; }
    }
}