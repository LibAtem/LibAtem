using System;

namespace LibAtem.Common
{
    public enum InternalPortType
    {
        External = 0,
        Black = 1,
        ColorBars = 2,
        ColorGenerator = 3,
        MediaPlayerFill = 4,
        MediaPlayerKey = 5,
        SuperSource = 6,
        [Since(ProtocolVersion.V8_1_1)]
        ExternalDirect = 7,

        MEOutput = 128,
        Auxiliary = 129,
        Mask = 130,
        [Since(ProtocolVersion.V8_1_1)]
        MultiViewer = 131,
    }

    [Flags]
    public enum VideoPortType
    {
        None = 0,
        SDI = 1,
        HDMI = 2,
        Component = 4,
        Composite = 8,
        SVideo = 16,

        Internal = 256,
    }

    public enum AudioPortType
    {
        Unknown = 0,
        SDI = 1,
        HDMI = 2,
        XLR = 32,
        AESEBU = 64,
        RCA = 128,
        Internal = 256,
        TSJack = 512,
        MADI = 1024,
        TRSJack = 2048,
        RJ45 = 4096,
    }

    public enum AudioInternalPortType
    {
        NotInternal = 0, // TODO - verify
        NoAudio = 1, // TODO - verify
        TalkbackMix = 2, // TODO - verify
        EngineeringTalkbackMix = 3, // TODO - verify
        ProductionTalkbackMix = 4, // TODO - verify
        MediaPlayer = 5, // TODO - verify
        Program = 6,
        Return = 7,
        Monitor = 8, // TODO - verify
        Madi = 9,
        AuxOut = 10,
        AudioAuxOut = 11, // TODO - verify
        ReturnStreaming = 12, // TODO - verify
        MixMinus = 13, // TODO - verify
    }

    public enum MacroPortType
    {
        SDI = 0, // TODO Check this
        HDMI = 1,
        Component = 2,
        // TODO - other types
    }

    /*
    public static class MacroPortTypeExtensions
    {
        public static MacroPortType ToMacroPortType(this ExternalPortType type)
        {
            switch (type)
            {
                case ExternalPortType.HDMI:
                    return MacroPortType.HDMI;
                case ExternalPortType.Component:
                    return MacroPortType.Component;
                case ExternalPortType.Composite:
                case ExternalPortType.SVideo:
                case ExternalPortType.Internal:
                case ExternalPortType.SDI:
                default:
                    return MacroPortType.SDI;
            }
        }

        public static ExternalPortType ToExternalPortType(this MacroPortType type)
        {
            switch (type)
            {
                case MacroPortType.HDMI:
                    return ExternalPortType.HDMI;
                case MacroPortType.Component:
                    return ExternalPortType.Component;
                case MacroPortType.SDI:
                default:
                    return ExternalPortType.SDI;
            }
        }
    }
    */

}