using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeFS")]
    public class MixEffectKeyFlyPropertiesGetCommand : ICommand
    {
        [CommandId]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        public uint KeyerIndex { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddBoolArray(false);
            cmd.AddBoolArray(false);
            cmd.Pad();
            cmd.AddBoolArray(false, false, false, false);
            cmd.AddUInt8(0);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            cmd.Skip(6);
        }
    }
}