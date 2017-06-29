using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKTp")]
    public class MixEffectKeyTypeSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Type = 1 << 0,
            FlyEnabled = 1 << 1,
        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public MixEffectKeyType KeyType { get; set; }
        public bool FlyEnabled { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddUInt8((int) KeyType);
            cmd.AddBoolArray(FlyEnabled);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            KeyType = (MixEffectKeyType) cmd.GetUInt8();
            FlyEnabled = cmd.GetBoolArray()[0];
            cmd.Skip(3);
        }
    }
}