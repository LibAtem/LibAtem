using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPCE", CommandDirection.ToClient, 4)]
    public class MediaPlayerSourceGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MediaPlayerId Index { get; set; }
        [Serialize(1), Enum8]
        public MediaPlayerSource SourceType { get; set; }
        [Serialize(2), UInt8]
        public uint SourceIndex { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);

            if (SourceType == MediaPlayerSource.Clip)
            {
                cmd.SetByte(2, new byte[]{ 0x00, (byte)SourceIndex });
            }
        }

        public override void Deserialize(ParsedByteArray cmd)
        {
            base.Deserialize(cmd);

            if (SourceType == MediaPlayerSource.Clip)
            {
                SourceIndex = cmd.Body[3];
            }
        }
    }
}