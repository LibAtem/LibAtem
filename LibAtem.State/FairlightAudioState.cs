using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class FairlightAudioState
    {
        public ProgramOutState ProgramOut { get; } = new ProgramOutState();

        public Dictionary<long, InputState> Inputs { get; } = new Dictionary<long, InputState>();
        public IReadOnlyList<MonitorOutputState> Monitors { get; set; } = new List<MonitorOutputState>();

        [Serializable]
        public class ProgramOutState
        {
            public double Gain { get; set; }
            public bool FollowFadeToBlack { get; set; }

            public DynamicsState Dynamics { get; } = new DynamicsState();
            public EqualizerState Equalizer { get; } = new EqualizerState();
        }

        [Serializable]
        public class MonitorOutputState
        {
            public double Gain { get; set; }
            public double InputMasterGain { get; set; }
            public double InputTalkbackGain { get; set; }
            public double InputSidetoneGain { get; set; }
        }

        [Serializable]
        public class InputState
        {
            public FairlightInputType InputType { get; set; }
            public FairlightInputConfiguration SupportedConfigurations { get; set; }

            public ExternalPortType ExternalPortType { get; set; }
            public FairlightInputConfiguration ActiveConfiguration { get; set; }

            public bool SupportsRcaToXlr { get; set; }
            public bool RcaToXlrEnabled { get; set; }

            public AnalogState Analog { get; set; }

            public List<InputSourceState> Sources { get; } = new List<InputSourceState>();
        }

        [Serializable]
        public class AnalogState
        {
            public FairlightAnalogInputLevel SupportedInputLevel { get; set; }
            public FairlightAnalogInputLevel InputLevel { get; set; }
        }

        [Serializable]
        public class InputSourceState
        {
            public long SourceId { get; set; }
            public FairlightAudioSourceType SourceType { get; set; }

            public double Gain { get; set; }
            public double Balance { get; set; }
            public double FaderGain { get; set; }

            public FairlightAudioMixOption SupportedMixOptions { get; set; }
            public FairlightAudioMixOption MixOption { get; set; }
            
            public uint MaxFramesDelay { get; set; }

            public DynamicsState Dynamics { get; } = new DynamicsState();
            public EqualizerState Equalizer { get; } = new EqualizerState();
        }

        [Serializable]
        public class DynamicsState
        {
            public double MakeUpGain { get; set; }

            public LimiterState Limiter { get; set; }
            public CompressorState Compressor { get; set; }
            public ExpanderState Expander { get; set; }
        }

        [Serializable]
        public class LimiterState
        {
            public bool LimiterEnabled { get; set; }
            public double Threshold { get; set; }
            public double Attack { get; set; }
            public double Hold{ get; set; }
            public double Release { get; set; }
        }

        [Serializable]
        public class CompressorState
        {
            public bool CompressorEnabled { get; set; }
            public double Threshold { get; set; }
            public double Ratio { get; set; }
            public double Attack { get; set; }
            public double Hold { get; set; }
            public double Release { get; set; }
        }

        [Serializable]
        public class ExpanderState
        {
            public bool ExpanderEnabled { get; set; }
            public bool GateEnabled { get; set; }
            public double Threshold { get; set; }
            public double Range { get; set; }
            public double Ratio { get; set; }
            public double Attack { get; set; }
            public double Hold { get; set; }
            public double Release { get; set; }
        }

        [Serializable]
        public class EqualizerState
        {
            public bool Enabled { get; set; }
            public double Gain { get; set; }

            public IReadOnlyList<EqualizerBandState> Bands { get; set; } = new List<EqualizerBandState>();
        }

        [Serializable]
        public class EqualizerBandState
        {
            public bool BandEnabled { get; set; }

            public FairlightEqualizerBandShape Shape { get; set; }
            public FairlightEqualizerFrequencyRange FrequencyRange { get; set; }

            public uint Frequency { get; set; }

            public double Gain { get; set; }
            public double QFactor { get; set; }
        }

    }
}