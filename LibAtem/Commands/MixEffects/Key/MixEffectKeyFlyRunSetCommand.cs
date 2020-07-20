using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("RFlK", CommandDirection.ToServer, 8)]
    public class MixEffectKeyFlyRunSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            OnOff = 1 << 0,
            RunToInfinite = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [Serialize(3), Enum8]
        public FlyKeyKeyFrameType KeyFrame { get; set; }
        [Serialize(3), Enum8]
        public FlyKeyLocation RunToInfinite { get; set; }
        public override void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8((int)Mask);
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8((int)KeyerIndex);
            cmd.Pad();
            cmd.AddUInt8((int)KeyFrame);
            cmd.AddUInt8((int)RunToInfinite);
            cmd.Pad(2);
          
        }

    }
}