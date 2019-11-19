using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeFS", CommandDirection.ToClient)]
    public class MixEffectKeyFlyPropertiesGetCommand : ICommand
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8((int)KeyerIndex);
            cmd.AddBoolArray(false);
            cmd.AddBoolArray(false);
            cmd.Pad();
            cmd.AddBoolArray(false, false, false, false);
            cmd.AddUInt8(0);
            cmd.Pad();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = (UpstreamKeyId)cmd.GetUInt8();
            cmd.Skip(6);
        }
    }
}