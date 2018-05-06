using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Media
{
    [CommandName("MPfe")]
    public class MediaPoolFileCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MediaPoolFileType Type { get; set; }
        [CommandId]
        [Serialize(2), UInt16]
        public uint Index { get; set; }

        [Serialize(4), Bool]
        public bool IsUsed { get; set; }

        [Serialize(5), ByteArray(16)]
        public byte[] Hash { get; set; }
        
        [Serialize(22), StringLength(20)]
        public string Filename { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.SetString(24, Filename);
        }

        public override void Deserialize(ParsedByteArray cmd)
        {
            base.Deserialize(cmd);

            Filename = cmd.GetString(24, Filename.Length);
        }

        protected override int GetLength()
        {
            return MathExt.NextMultipleOf4(24 + (Filename?.Length ?? 0));
        }
    }
}