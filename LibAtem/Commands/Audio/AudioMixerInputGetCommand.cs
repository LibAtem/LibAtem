using LibAtem.Common;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMIP")]
    public class AudioMixerInputGetCommand : ICommand
    {
        public AudioSource Index { get; set; }
        public AudioSourceType SourceType { get; set; }
        public AudioPortType PortType { get; set; }
        public AudioMixOption MixOption { get; set; }
        public double Gain { get; set; }
        public double Balance { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16((int) Index);
            cmd.AddUInt8((int) SourceType);
            cmd.Pad();
            cmd.AddUInt16((int) Index); // Needed to get the names
            cmd.AddBoolArray(false);
            cmd.AddUInt8((int) PortType);
            cmd.AddUInt8((int) MixOption); // On/Off/AFV
            cmd.AddByte(0x73); // ??
            cmd.AddDecibels(Gain);
            cmd.AddInt16(200, Balance);
            cmd.Pad(6); // ??
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (AudioSource) cmd.GetUInt16();
            SourceType = (AudioSourceType) cmd.GetUInt8();
            cmd.Skip(3);
            PortType = (AudioPortType) cmd.GetUInt8();
            MixOption = (AudioMixOption) cmd.GetUInt8();
            cmd.Skip();
            Gain = cmd.GetDecibels();
            Balance = cmd.GetInt16(-10000, 10000) / 200d;
            cmd.Skip(6);
        }
    }
}