using System;
using LibAtem.Common;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMI")]
    public class AudioMixerInputSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
           MixOption = 1 << 0, 
           Gain = 1 << 1,
           Balance = 1 << 2,
        }

        public MaskFlags Mask { get; set; }
        public AudioSource Index { get; set; }
        public AudioSourceType SourceType { get; set; }
        public AudioPortType PortType { get; set; }
        public AudioMixOption MixOption { get; set; }
        public double Gain { get; set; }
        public double Balance { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.Pad();
            cmd.AddUInt16((int) Index);
            cmd.AddUInt8((int) MixOption); // On/Off/AFV
            cmd.Pad();
            cmd.AddDecibels(Gain);
            cmd.AddInt16(200, Balance);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            cmd.Skip();
            Index = (AudioSource)cmd.GetUInt16();
            MixOption = (AudioMixOption)cmd.GetUInt8();
            cmd.Skip();
            Gain = cmd.GetDecibels();
            Balance = cmd.GetInt16(-10000, 10000) / 200d;
            cmd.Skip(2);
        }
    }
}