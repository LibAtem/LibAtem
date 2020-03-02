using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("Warn", CommandDirection.ToClient, 44), NoCommandId]
    public class WarningCommand : SerializableCommandBase
    {
        [Serialize(0), String(44)]
        public string Text { get; set; }
    }
}