using System;

namespace LibAtem.Common
{
    public enum AudioMixOption
    {
        Off = 0,
        On = 1,
        AudioFollowVideo = 2
    }
    
    public enum FairlightAudioMixOption
    {
        Off = 1,
        On = 2,
        AudioFollowVideo = 4
    }
    
    public enum FairlightEqualizerBandShape
    {
        LowShelf = 1 << 0,
        LowPass = 1 << 1,
        BandPass = 1 << 2,
        Notch = 1 << 3,
        HighPass = 1 << 4,
        HighShelf = 1 << 5,
    }

    public enum FairlightEqualizerFrequencyRange
    {
        Low = 1 << 0,
        MidLow = 1 << 1,
        MidHigh = 1 << 2,
        High = 1 << 3,
    }

    public enum FairlightInputType
    {
        EmbeddedWithVideo = 0,
        MediaPlayer = 1,
        AudioIn = 2,
        MADI = 4,
    }

    public enum FairlightInputConfiguration
    {
        Mono = 1 << 0,
        Stereo = 1 << 1,
        DualMono = 1 << 2,
    }

    public enum FairlightAudioSourceType
    {
        Mono = 0,
        Stereo = 1,
    }

    [Flags]
    public enum FairlightAnalogInputLevel
    {
        None = 0,
        Microphone = 1,
        ConsumerLine = 2,
        [Since(ProtocolVersion.V8_1_1)]
        ProLine = 4
    }

    public enum AudioChannelPair
    {
        // TODO verify values
        Channel1_2 = 0,
        Channel3_4 = 1,
        Channel5_6 = 2,
        Channel7_8 = 3,
        Channel9_10 = 4,
        Channel11_12 = 5,
        Channel13_14 = 6,
        Channel15_16 = 7,
    }
}