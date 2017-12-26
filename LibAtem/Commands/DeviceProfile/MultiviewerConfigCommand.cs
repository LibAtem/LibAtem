using LibAtem.Util;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MvC"), NoCommandId]
    public class MultiviewerConfigCommand : ICommand
    {
        public uint Count { get; set; }
        public bool Unknown { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8(Count);
            cmd.AddByte(0x0a);
            cmd.AddByte(0x01);
            cmd.AddByte(0x01);
            cmd.AddByte(0x00);

            // Note: not sure what these are, but they are 0 in older (non 4k/3g) models
            cmd.AddBoolArray(Unknown);
            cmd.AddBoolArray(Unknown);
            cmd.AddBoolArray(Unknown);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Count = cmd.GetUInt8();
            cmd.Skip(7);
        }
    }
}