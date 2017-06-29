using LibAtem.Common;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MeC")]
    public class MixEffectBlockConfigCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public uint KeyCount { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddUInt8(KeyCount);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId) cmd.GetUInt8();
            KeyCount = cmd.GetUInt8();
            cmd.Skip(2);
        }
    }
}