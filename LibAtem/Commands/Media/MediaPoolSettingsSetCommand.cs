using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("CMPS", CommandDirection.ToServer, 8), NoCommandId]
    public class MediaPoolSettingsSetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt16List(4)]
        public List<uint> MaxFrames { get; set; } = new List<uint> { 0, 0, 0, 0 };
    }
}