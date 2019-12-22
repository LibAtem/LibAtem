using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CFSP", CommandDirection.ToServer, 48)]
    public class FairlightMixerSourceSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            // ?? = 1 << 0,
            Gain = 1 << 1,
            // ?? = 1 << 2,
            EqualizerEnabled = 1 << 3,
            EqualizerGain = 1 << 4,
            MakeUpGain = 1 << 5,
            Balance = 1 << 6,
            FaderGain = 1 << 7,
            MixOption = 1 << 8,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; } // TODO - ensure the mics are valid
        
        // TODO - mono vs stereo
        
        [Serialize(20), Int32D(100, -12041, 600)]
        public double Gain { get; set; }
        
        [Serialize(26), Bool]
        public bool EqualizerEnabled { get; set; }
        [Serialize(28), Int32D(100, -2000, 2000)]
        public double EqualizerGain { get; set; }
        [Serialize(32), Int32D(100, 0, 2000)]
        public double MakeUpGain { get; set; }
        [Serialize(36), Int16D(100, -10000, 10000)]
        public double Balance { get; set; }
        [Serialize(40), Int32D(100.0, -12041, 1000)] // TODO - thats an odd minimum..
        public double FaderGain { get; set; }
        [Serialize(44), Enum8]
        public FairlightMixOption MixOption { get; set; }

        /*
        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.MixOption))
                yield return new AudioMixerInputMixTypeMacroOp { Index = Index, MixOption = MixOption };

            if (Mask.HasFlag(MaskFlags.Gain))
                yield return new AudioMixerInputGainMacroOp { Index = Index, Gain = Gain };

            if (Mask.HasFlag(MaskFlags.Balance))
                yield return new AudioMixerInputBalanceMacroOp { Index = Index, Balance = Balance };
        }*/
    }
}