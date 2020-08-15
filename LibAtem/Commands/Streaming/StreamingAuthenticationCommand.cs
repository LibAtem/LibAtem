using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("SAth", CommandDirection.Both, ProtocolVersion.V8_1_1, 128), NoCommandId]
    public class StreamingAuthenticationCommand : SerializableCommandBase
    {
        [Serialize(0), String(64)]
        public string Username { get; set; }
        [Serialize(64), String(64)]
        public string Password { get; set; }
    }
}