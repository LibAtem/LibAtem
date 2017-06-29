namespace LibAtem.Common
{
    public enum ExternalPortType
    {
        Internal = 0,
        SDI = 1,
        HDMI = 2,
        Composite = 3,
        Component = 4,
        SVideo = 5,
    }

    public enum InternalPortType
    {
        External = 0,
        Black = 1,
        ColorBars = 2,
        ColorGenerator = 3,
        MediaPlayerFill = 4,
        MediaPlayerKey = 5,
        SuperSource = 6,

        MEOutput = 128,
        Auxilary = 129,
        Mask = 130,
    }

    public enum AudioPortType
    {
        Internal = 0,
        SDI = 1,
        HDMI = 2,
        Component = 3,
        Composite = 4,
        SVideo = 5,
        XLR = 32,
        AESEBU = 64,
        RCA = 128,
    }
}