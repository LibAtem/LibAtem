namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCmd", CommandDirection.ToServer)]
    public class CameraControlSetCommand : CameraControlCommandBase
    {
        public bool Relative { get; set; }

        protected override void SerializeType(ByteArrayBuilder cmd)
        {
            cmd.AddBoolArray(Relative);
            cmd.AddUInt8((uint) Type);
            cmd.Pad(1);
        }

        protected override void DeserializeType(ParsedByteArray cmd)
        {
            Relative = cmd.GetBoolArray()[0];
            Type = (CameraControlDataType) cmd.GetUInt8();
            cmd.Skip(1);
        }

        protected override void SerializePostLength(ByteArrayBuilder cmd)
        {
        }

        protected override void DeserializePostLength(ParsedByteArray cmd)
        {
        }
    }
}