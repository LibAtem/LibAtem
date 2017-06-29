using LibAtem.Common;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMmO")]
    public class AudioMixerMonitorGetCommand : ICommand
    {
        public bool Enabled { get; set; }
        public double Gain { get; set; }
        public bool Mute { get; set; }
        public bool Solo { get; set; }
        public AudioSource SoloSource { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddBoolArray(Enabled);
            cmd.AddByte(0x6d); // ??
            cmd.AddDecibels(Gain);
            cmd.AddBoolArray(Mute);
            cmd.AddBoolArray(Solo);
            cmd.AddUInt16((int) SoloSource);
            cmd.AddBoolArray(false); // Dim?
            cmd.AddByte(0x50, 0x07, 0xd0);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Enabled = cmd.GetBoolArray()[0];
            cmd.Skip();
            Gain = cmd.GetDecibels();
            Mute = cmd.GetBoolArray()[0];
            Solo = cmd.GetBoolArray()[0];
            SoloSource = (AudioSource) cmd.GetUInt16();
            cmd.Skip(4);
        }
    }
}