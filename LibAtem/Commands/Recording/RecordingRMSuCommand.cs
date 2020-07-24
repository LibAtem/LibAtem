using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("RMSu", CommandDirection.ToClient, 140), NoCommandId]
    public class RecordingRMSuCommand : SerializableCommandBase
    {
        [Serialize(0), String(64)] // TODO length
        public string Filename { get; set; }


    }
}