namespace LibAtem.Commands.CameraControl
{
    // PeriodicFlushEnabled = 12
    [CommandName("CCdP", CommandDirection.ToClient)]
    public class CameraControlGetCommand : CameraControlCommandBase
    {
        public bool PeriodicFlushEnabled { get; set; }

        protected override void SerializeType(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8((uint)Type);
        }

        protected override void DeserializeType(ParsedByteArray cmd)
        {
            Type = (CameraControlDataType)cmd.GetUInt8();
        }

        protected override void SerializePostLength(ByteArrayBuilder cmd)
        {
            cmd.AddBoolArray(PeriodicFlushEnabled);
        }

        protected override void DeserializePostLength(ParsedByteArray cmd)
        {
            PeriodicFlushEnabled = cmd.GetBoolArray()[0];
        }
    }
}