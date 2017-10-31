namespace LibAtem.Common
{
    // TODO - some of these don't look like possible macro operations
    public enum MacroOperationType
    {
        LoopMacro,

        ProgramInput = 0x0002,
        PreviewInput = 0x0003,

        CutTransition = 0x0004,
        AutoTransition = 0x0005,

        MacroUserWait,//
        MacroSleep = 0x0007,

        RunMacro,
        UserResumeMacro,
        StartRecordMacro,
        StopRecordMacro,

        VideoMode,

        CameraControlVoidBool,
        CameraControlByte,
        CameraControl16Bit,
        CameraControl32Bit,
        CameraControl64Bit,
        CameraControlFixedPoint16Bit,

        StopMacro,

        TransitionWipeSymmetry,
        TransitionWipeXPosition,
        TransitionWipeYPosition,
        TransitionWipeSymmetryOffset,
        TransitionWipeXPositionOffset,
        TransitionWipeYPositionOffset,

        DownConvertMode,
        InputVideoPort,
        ColorGeneratorHue = 0x001c,
        ColorGeneratorSaturation = 0x001d,
        ColorGeneratorLuminescence = 0x001e,

        AuxiliaryInput = 0x001f,

        MultiViewWindowInput,
        MultiViewLayout,

        DeleteMacro,

        MacroLabel,
        MacroNote,

        KeyCutInput = 0x0025,
        KeyFillInput = 0x0026,
        KeyOnAir = 0x0027,
        KeyType = 0x0028,

        LumaKeyClip, //
        LumaKeyGain, //
        
        KeyFlyEnable,

        LumaKeyInvert,
        LumaKeyPreMultiply = 0x002d,

        PatternKeyInvert,

        KeyMaskEnable = 0x002f,
        KeyMaskTop = 0x0030,
        KeyMaskBottom = 0x0031,
        KeyMaskLeft = 0x0032,
        KeyMaskRight = 0x0033,
          
        TransitionDVEPattern, //
        DVEKeyMaskEnable = 0x0035,
        DVEKeyMaskTop = 0x0036,
        DVEKeyMaskBottom = 0x0037,
        DVEKeyMaskLeft = 0x0038,
        DVEKeyMaskRight = 0x0039,
        TransitionDVERate, //

        ChromaKeyClip = 0x003b,
        ChromaKeyGain = 0x003c,
        ChromaKeyHue = 0x003d,
        ChromaKeyLift = 0x003e,
        ChromaKeyNarrow = 0x003f,

        PatternKeyPattern = 0x0040,
        PatternKeySize = 0x0041,
        PatternKeySoftness = 0x0042,
        PatternKeyXPosition = 0x0043,
        PatternKeyYPosition = 0x0044,
        PatternKeySymmetry = 0x0045,

        DVEAndFlyKeyXSize = 0x0047,
        DVEAndFlyKeyYSize = 0x0048,

        DVEAndFlyKeyXPosition = 0x004a,
        DVEAndFlyKeyYPosition = 0x004b,

        DVEKeyShadowEnable = 0x004d,
        DVEKeyBorderEnable = 0x004e,
        DVEAndFlyKeyRotation = 0x004f,

        FlyKeySetKeyFrame,
        FlyKeyResetKeyFrame,
        FlyKeyRunToFull,
        FlyKeyRunToFullWithRate,
        FlyKeyRunToKeyFrame,
        FlyKeyRunToKeyFrameWithRate,
        FlyKeyRunToInfinity,

        DVEKeyShadowDirection = 0x0058,
        DVEKeyShadowAltitude = 0x0059,

        DVEKeyBorderHue,
        DVEKeyBorderSaturation,
        DVEKeyBorderLuminescence,
        DVEKeyBorderBevel,
        DVEKeyBorderOuterWidth,
        DVEKeyBorderInnerWidth,
        DVEKeyBorderOuterSoftness,
        DVEKeyBorderInnerSoftness,
        DVEKeyBorderOpacity,
        DVEKeyBorderBevelPosition,
        DVEKeyBorderBevelSoftness,

        FlyKeyFrameXSize,
        FlyKeyFrameYSize,
        FlyKeyFrameXPosition,
        FlyKeyFrameYPosition,
        FlyKeyFrameRotation,
        FlyKeyFrameShadowDirection,
        FlyKeyFrameShadowAltitude,
        FlyKeyFrameBorderHue,
        FlyKeyFrameBorderSaturation,
        FlyKeyFrameBorderLuminescence,
        FlyKeyFrameBorderOuterWidth,
        FlyKeyFrameBorderInnerWidth,
        FlyKeyFrameBorderOuterSoftness,
        FlyKeyFrameBorderInnerSoftness,
        FlyKeyFrameBorderOpacity,
        FlyKeyFrameBorderBevelPosition,
        FlyKeyFrameBorderBevelSoftness,
        FlyKeyFrameMaskTop,
        FlyKeyFrameMaskBottom,
        FlyKeyFrameMaskLeft,
        FlyKeyFrameMaskRight,

        TransitionWipeRate,
        TransitionWipePattern,
        TransitionWipeBorderWidth,
        TransitionWipeBorderSoftness,
        TransitionWipeBorderFillInput,
        TransitionWipeAndDVEReverse,
        TransitionWipeAndDVEFlipFlop,

        TransitionStyle = 0x0083,
        TransitionSource = 0x0084,
        TransitionPosition,
        TransitionPreview,
        TransitionMixRate = 0x0087,
        TransitionDipRate,
        TransitionDipInput,
        TransitionStingerRate,
        TransitionStingerSourceNone,
        TransitionStingerSourceMediaPlayer,
        TransitionStingerClipDuration,
        TransitionStingerTriggerPoint,
        TransitionStingerMixRate,
        TransitionStingerPreRoll,
        TransitionStingerResetDurations,
        TransitionStingerDVEClip,
        TransitionStingerDVEGain,
        TransitionStingerDVEInvert,
        TransitionStingerDVEPreMultiply,

        DownstreamKeyFillInput = 0x0096,
        DownstreamKeyCutInput = 0x0097,
        DownstreamKeyRate = 0x0098,
        DownstreamKeyAuto = 0x0099,
        DownstreamKeyOnAir = 0x009a,
        DownstreamKeyTie = 0x009b,
        DownstreamKeyClip = 0x009c,
        DownstreamKeyGain = 0x009d,
        DownstreamKeyMaskEnable = 0x009e,
        DownstreamKeyMaskTop = 0x009f,
        DownstreamKeyMaskBottom = 0x00a0,
        DownstreamKeyMaskLeft = 0x00a1,
        DownstreamKeyMaskRight = 0x00a2,
        DownstreamKeyInvert = 0x00a3,
        DownstreamKeyPreMultiply = 0x00a4,

        FadeToBlackRate = 0x00a5,
        FadeToBlackCut, // Not used
        FadeToBlackAuto = 0x00a7, // -

        SuperSourceArtCutInput, // -
        SuperSourceArtFillInput = 0x00a9,
        SuperSourceArtAbove = 0x00aa,
        SuperSourceArtPreMultiply,
        SuperSourceArtClip,
        SuperSourceArtGain,
        SuperSourceArtInvert,
        SuperSourceBorderEnable,
        SuperSourceBorderHue,
        SuperSourceBorderSaturation,
        SuperSourceBorderLuminescence,
        SuperSourceBorderBevel,
        SuperSourceBorderOuterWidth,
        SuperSourceBorderInnerWidth,
        SuperSourceBorderOuterSoftness,
        SuperSourceBorderInnerSoftness,
        SuperSourceBorderBevelPosition,
        SuperSourceBorderBevelSoftness,
        SuperSourceShadowDirection,
        SuperSourceShadowAltitude,
        SuperSourceBoxEnable = 0x00bc,
        SuperSourceBoxInput = 0x00bd,
        SuperSourceBoxXPosition = 0x00be,
        SuperSourceBoxYPosition = 0x00bf,
        SuperSourceBoxSize = 0x00c0,
        SuperSourceBoxMaskEnable = 0x00c1,
        SuperSourceBoxMaskTop = 0x00c2,
        SuperSourceBoxMaskBottom = 0x00c3,
        SuperSourceBoxMaskLeft = 0x00c4,
        SuperSourceBoxMaskRight = 0x00c5,
        
        AudioMixerInputMixType,
        AudioMixerInputGain, //
        AudioMixerInputBalance,
        AudioMixerMasterOutGain,
        AudioMixerMasterOutBalance,
        AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1,
        AudioMixerMonitorOut,
        AudioMixerMonitorOutGain,
        AudioMixerMonitorOutMute,
        AudioMixerMonitorOutSolo,
        AudioMixerMonitorOutSoloInput,
        AudioMixerMonitorOutDim,
        AudioMixerMonitorOutDimLevel,
        AudioMixerInputResetPeaks,
        AudioMixerInputResetAllPeaks,
        AudioMixerMasterOutResetPeaks,
        AudioMixerMonitorOutResetPeaks,

        TransitionDVEFillInput,
        TransitionDVECutInput,
        TransitionDVECutInputEnable,

        MediaPlayerSourceStillIndex = 0x00da,
        MediaPlayerSourceClipIndex, //
        MediaPlayerGoToBeginning, //
        MediaPlayerGoToFrame,
        MediaPlayerPlay = 0x00de,
        MediaPlayerPause,
        MediaPlayerLoop = 0x00e0,
        MediaPlayerSourceStill = 0x00e1,
        MediaPlayerSourceClip, // --

        PatternKeySizeOffset,
        PatternKeyXPositionOffset,
        PatternKeyYPositionOffset,

        DVEAndFlyKeyXSizeOffset,
        DVEAndFlyKeyYSizeOffset,
        DVEAndFlyKeyXPositionOffset,
        DVEAndFlyKeyYPositionOffset,

        SuperSourceBoxXPositionOffset,
        SuperSourceBoxYPositionOffset,
        SuperSourceBoxSizeOffset,

        MediaPlayerPlayFromBeginning,

        PtzRs422ViscaSetPanVelocity,
        PtzRs422ViscaSetTiltVelocity,
        PtzRs422ViscaSetZoomVelocity,
        PtzRs422ViscaUpdatePanTiltPosition,
        PtzRs422ViscaUpdateZoomPosition,
        PtzRs422ViscaGotoPanTiltPosition,
        PtzRs422ViscaGotoZoomPosition,
        PtzRs422ViscaAllocateAddresses,
        PtzRs422ViscaBaudRate,

        GvgReadCrosspointPrgmBkgd,
        GvgReadCrosspointPresetBkgd,
        GvgReadCrosspointKey,
        GvgReadWipePattern,
        GvgReadTransitionMode,
        GvgReadTransitionRateAutoTrans,
        GvgReadTransitionRateDskMix,
        GvgReadTransitionRateFadeToBlack,
        GvgReadLampStatusMap,
        GvgReadAnalogControl,
        GvgReadPushButtonLampControl,
        GvgReadFieldMode,
        GvgReadSoftwareVersion,

        SetSerialPortFunction,
        
        ToggleTransitionWipeAndDVEReverse,

        ToggleKeyMaskEnable,
        ToggleKeyOnAir,
        ToggleLumaKeyInvert,
        ToggleDVEKeyBorderEnable,
        ToggleDVEKeyShadowEnable,
        ToggleDownstreamKeyOnAir,
        ToggleDownstreamKeyTie,
        ToggleDownstreamKeyInvert,
        ToggleDownstreamKeyMaskEnable,
        ToggleTransitionSource,

        AudioMixerTalkbackMuteSDI,

        HyperDeckSetIPv4Address,
        HyperDeckSetSourceClipIndex, //
        HyperDeckGoToPositionDelta,
        HyperDeckUpdatePosition,
        HyperDeckGoToPosition,
        HyperDeckSetLoop, //
        HyperDeckSetSpeed, //
        HyperDeckPlay, //
        HyperDeckStop, //
        HyperDeckRecord,
        HyperDeckSetInput,
        HyperDeckSetSingleClip, //
        HyperDeckSetSourceSlotIndex,
        HyperDeckSetRollOnTake,
        HyperDeckSetRollOnTakeFrameDelay,

        MultiViewVuMeterEnable,
        MultiViewVuMeterOpacity,
        MultiViewSafeAreaEnable,
        MultiViewPgmPvwSwap,

        AudioMixerHeadphoneOutGain,
        AudioMixerHeadphoneOutMasterGain,
        AudioMixerHeadphoneOutTalkbackGain,
        AudioMixerHeadphoneOutSidetoneGain,
        AudioMixerInputTalkbackMuteSDI,

        MixMinusSetAudioMode,
    }
}