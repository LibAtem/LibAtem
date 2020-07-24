using System;
using System.Collections.Generic;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Audio;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMP", CommandDirection.ToServer, 4), NoCommandId]
    public class AudioMixerPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            AudioFollowVideo = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(1), Bool]
        public bool AudioFollowVideo { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.AudioFollowVideo))
                yield return new AudioMixerAfvFollowTransitionMacroOp { Enable = AudioFollowVideo };
        }
    }
}