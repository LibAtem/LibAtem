using System;
using LibAtem.Common;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMm")]
    public class AudioMixerMonitorSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
           Enabled = 1 << 0,
            Gain = 1 << 1,
            Mute = 1 << 2,
            Solo = 1 << 3,
            SoloSource = 1 << 4,
            Dim = 1 << 5,
        }

        public MaskFlags Mask { get; set; }
        public bool Enabled { get; set; }
        public double Gain { get; set; }
        public bool Mute { get; set; }
        public bool Solo { get; set; }
        public AudioSource SoloSource { get; set; }
        public bool Dim { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddBoolArray(Enabled);
            cmd.AddDecibels(Gain);
            cmd.AddBoolArray(Mute);
            cmd.AddBoolArray(Solo);
            cmd.AddUInt16((int)SoloSource);
            cmd.AddBoolArray(Dim);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            Enabled = cmd.GetBoolArray()[0];
            Gain = cmd.GetDecibels();
            Mute = cmd.GetBoolArray()[0];
            Solo = cmd.GetBoolArray()[0];
            SoloSource = (AudioSource)cmd.GetUInt16();
            Dim = cmd.GetBoolArray()[0];
            cmd.Skip(3);
        }
    }
}