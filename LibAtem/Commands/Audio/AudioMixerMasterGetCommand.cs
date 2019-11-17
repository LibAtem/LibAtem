using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMMO", 8), NoCommandId]
    public class AudioMixerMasterGetCommand : SerializableCommandBase
    {
        [Serialize(0), Decibels]
        public double Gain { get; set; }
        [Serialize(2), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }
        [Serialize(4), Bool]
        public bool FollowFadeToBlack { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);
            
            cmd.Set(6, 0x00, 0xf4); // Pad?
        }
    }
}