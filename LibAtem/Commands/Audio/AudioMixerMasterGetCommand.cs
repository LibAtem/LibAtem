using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMMO", 8)]
    public class AudioMixerMasterGetCommand : SerializableCommandBase
    {
        [Serializable(0), Decibels]
        public double Gain { get; set; }
        [Serializable(2), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }
        [Serializable(6), Bool]
        public bool ProgramOutFollowFadeToBlack { get; set; }

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.Set(4, 0x00, 0xe8);
            cmd.Set(7, 0xf4); // Pad?
        }
    }
}