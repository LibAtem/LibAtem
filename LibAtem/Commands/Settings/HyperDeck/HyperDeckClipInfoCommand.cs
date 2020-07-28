using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCS", CommandDirection.ToClient, 84)]
    public class HyperDeckClipInfoCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint HyperdeckId { get; set; }
        [CommandId]
        [Serialize(2), UInt16]
        public uint ClipId { get; set; }

        [Serialize(4), String(64)]
        public string Name { get; set; }

        [Serialize(69), HyperDeckTime]
        public HyperDeckTime TimelineStart { get; set; }
        [Serialize(74), HyperDeckTime]
        public HyperDeckTime TimelineEnd { get; set; }
        [Serialize(79), HyperDeckTime]
        public HyperDeckTime Duration{ get; set; }
    }
}