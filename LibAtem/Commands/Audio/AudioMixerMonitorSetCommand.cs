using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Audio;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMm", 12), NoCommandId]
    public class AudioMixerMonitorSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Enabled = 1 << 0,
            Gain = 1 << 1,
            Mute = 1 << 2,
            Solo = 1 << 3,
            SoloSource = 1 << 4,
            Dim = 1 << 5,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(1), Bool]
        public bool Enabled { get; set; }
        [Serialize(2), Decibels]
        public double Gain { get; set; }
        [Serialize(4), Bool]
        public bool Mute { get; set; }
        [Serialize(5), Bool]
        public bool Solo { get; set; }
        [Serialize(6), Enum16]
        public AudioSource SoloSource { get; set; }
        [Serialize(8), Bool]
        public bool Dim { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Enabled))
                yield return new AudioMixerMonitorOutMacroOp {Enable = Enabled};
            if (Mask.HasFlag(MaskFlags.Gain))
                yield return new AudioMixerMonitorOutGainMacroOp {Gain = Gain};
            if (Mask.HasFlag(MaskFlags.Mute))
                yield return new AudioMixerMonitorOutMuteMacroOp {Mute = Mute};
            if (Mask.HasFlag(MaskFlags.Solo))
                yield return new AudioMixerMonitorOutSoloMacroOp {Solo = Solo};
            if (Mask.HasFlag(MaskFlags.SoloSource))
                yield return new AudioMixerMonitorOutSoloInputMacroOp {Input = SoloSource};
            if (Mask.HasFlag(MaskFlags.Dim))
                yield return new AudioMixerMonitorOutDimMacroOp {Dim = Dim};
        }
    }
}