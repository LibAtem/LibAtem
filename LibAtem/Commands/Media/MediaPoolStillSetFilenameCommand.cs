using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("SMPS", CommandDirection.ToServer, 68)]
    public class MediaPoolStillSetFilenameCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; }

        [Serialize(1), String(64)]
        public string Filename { get; set; } // TODO - guard length
    }
}