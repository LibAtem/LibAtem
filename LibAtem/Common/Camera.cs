namespace LibAtem.Common
{
    public enum AdjustmentDomain
    {
        Lens = 0,
        Camera = 1,
        ColourBars = 4,
        Chip = 8
    }

    public enum CameraFeature
    {
        PositiveGain = 1,
        WhiteBalance = 2,
        Shutter = 5,
        Detail = 8,
        Gain = 13

    }

    public enum LensFeature
    {
        Focus = 0,
        AutoFocus = 1,
        Iris = 2,
        Zoom = 9
    }

    public enum ChipFeature
    {
        Lift = 0,
        Gamma = 1,
        Aperture = 3,
        Gain = 2,
        Contrast = 4,
        Lum = 5,
        HueSaturation = 6,
    }

    public enum CameraDetail
    {
        Off = 0,
        Default = 1,
        Medium = 2,
        High = 3
    }

}
