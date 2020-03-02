using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("RACK", CommandDirection.ToServer, 4)]
    public class MixEffectKeyAdvancedChromaResetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        
        [Serialize(3), Bool(0)]
        public bool KeyAdjustments { get; set; }
        [Serialize(3), Bool(1)]
        public bool ChromaCorrection { get; set; }
        [Serialize(3), Bool(2)]
        public bool ColorAdjustments { get; set; }
    }
}