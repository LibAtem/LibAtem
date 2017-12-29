using System.Linq;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_DVE"), NoCommandId]
    public class DVEConfigCommand : ICommand
    {
        // Perhaps this is the available styles?
        private static readonly byte[] BytePattern = new byte[]
        {
            0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
            0x22,
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
            0x20, 0x21,
        };

        public bool Unknown { get; set; }
        public bool Unknown2 { get; set; }

        public uint Length { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddBoolArray(Unknown);
            cmd.AddBoolArray(Unknown2);

            cmd.AddByte(BytePattern.Take((int) Length));
            cmd.PadToNearestMultipleOf4();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Unknown = cmd.GetBoolArray()[0];
            Unknown2 = cmd.GetBoolArray()[0];

            Length = cmd.GetUInt16();
            cmd.GetString(Length); // Get and discard values. Not sure what they mean (if anything)
            cmd.SkipToNearestMultipleOf4();
        }
    }
}