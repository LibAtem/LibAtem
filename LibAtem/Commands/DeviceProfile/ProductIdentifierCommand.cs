namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_pin")]
    public class ProductIdentifierCommand : ICommand
    {
        public string Name { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddString(25, Name);
            // TODO figure out what this is. It might mean something, or nothing. By blanking out after the name seems to cause the client to lose input names on the buttons
            cmd.AddByte(0x00, 0x11, 0x60, 0x00, 0x00, 0x00, 0x00, 0x28, 0x36, 0x9B, 0x60, 0x4C, 0x08, 0x11, 0x60, 0x04, 0x3D, 0xA4, 0x60);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Name = cmd.GetString(25);
            cmd.Skip(19);
        }
    }
}