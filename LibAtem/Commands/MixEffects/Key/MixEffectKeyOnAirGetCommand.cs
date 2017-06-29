using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeOn")]
    public class MixEffectKeyOnAirGetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public bool OnAir { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddBoolArray(OnAir);
            cmd.AddByte(0x69); // ?
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            OnAir = cmd.GetBoolArray()[0];
            cmd.Skip();
        }
    }
}