using System;
using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPSp", CommandDirection.ToClient, 12), NoCommandId]
    public class MediaPoolSettingsGetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt16List(4)]
        public List<uint> MaxFrames { get; set; } = new List<uint>();
        
        [Serialize(8), UInt16]
        public uint UnassignedFrames { get; set; }
    }
}