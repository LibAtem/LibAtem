using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("CMPS", 4), NoCommandId]
    public class MediaPoolSettingsSetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt16]
        public uint Clip1MaxFrames { get; set; }
    }
}