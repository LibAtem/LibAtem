namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCmd", CommandDirection.ToServer)]
    public class CameraControlSetCommand : CameraControlGetCommand
    {
        public bool Relative { get; set; }

        protected override void SerializeType(ByteArrayBuilder cmd)
        {
            cmd.AddBoolArray(Relative);
            base.SerializeType(cmd);
            cmd.Pad(1);
        }

        protected override void DeserializeType(ParsedByteArray cmd)
        {
            Relative = cmd.GetBoolArray()[0];
            base.DeserializeType(cmd);
            cmd.Skip(1);
        }
    }
}