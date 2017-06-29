namespace LibAtem.Commands.Audio
{
    [CommandName("AMMO")]
    public class AudioMixerMasterGetCommand : ICommand
    {
        public double Gain { get; set; }
        public double Balance { get; set; }
        public bool ProgramOutFollowFadeToBlack { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddDecibels(Gain);
            cmd.AddInt16(200, Balance);
            cmd.AddByte(0x00, 0xe8); // ??
            cmd.AddBoolArray(ProgramOutFollowFadeToBlack);
            cmd.AddByte(0xf4); // Pad?
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Gain = cmd.GetDecibels();
            Balance = cmd.GetInt16(-10000, 10000) / 200d;
            cmd.Skip(2);
            ProgramOutFollowFadeToBlack = cmd.GetBoolArray()[0];
            cmd.Skip();
        }
    }
}