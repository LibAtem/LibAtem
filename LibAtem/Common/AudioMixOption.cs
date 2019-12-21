namespace LibAtem.Common
{
    public enum AudioMixOption
    {
        Off = 0,
        On = 1,
        AudioFollowVideo = 2
    }
    
    public enum FairlightMixOption
    {
        Off = 1,
        On = 2,
        AudioFollowVideo = 4
    }

    public enum FairlightAnalogSourceType
    {
        Microphone = 1,
        ConsumerLine = 2
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
}