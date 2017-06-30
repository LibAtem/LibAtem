using System;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMM")]
    public class AudioMixerMasterSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Gain = 1 << 0,
            Balance = 1 << 1, //??
            ProgramOutFollowFadeToBlack = 1 << 2,
        }

        public MaskFlags Mask { get; set; }
        public double Gain { get; set; }
        public double Balance { get; set; }
        public bool ProgramOutFollowFadeToBlack { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.Pad();
            cmd.AddDecibels(Gain);
            cmd.AddInt16(200, Balance);
            cmd.AddBoolArray(ProgramOutFollowFadeToBlack);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            cmd.Skip();
            Balance = cmd.GetInt16(-10000, 10000) / 200d;
            Gain = cmd.GetDecibels();
            ProgramOutFollowFadeToBlack = cmd.GetBoolArray()[0];
            cmd.Skip();
        }
    }
}