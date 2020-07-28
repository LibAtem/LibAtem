using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCC", CommandDirection.ToClient, 4)]
    public class HyperDeckClipCountCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Id { get; set; }

        [Serialize(2), UInt8]
        public uint ClipCount { get; set; }
    }
}