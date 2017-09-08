namespace LibAtem.Common
{
    // TODO - some of these don't look like possible macro operations
    public enum MacroOperationType
    {
        LoopMacro,

        ProgramInput = 0x0002,
        PreviewInput,// -

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
        ColorGeneratorHue,
        ColorGeneratorSaturation,
        ColorGeneratorLuminescence,

        AuxiliaryInput,

        MultiViewWindowInput,
        MultiViewLayout,

        DeleteMacro,

        MacroLabel,
        MacroNote,

        KeyCutInput,
        KeyFillInput,
        KeyOnAir,
        KeyType,

        LumaKeyClip,
        LumaKeyGain,
        
        KeyFlyEnable,

        LumaKeyInvert,
        LumaKeyPreMultiply,

        PatternKeyInvert,

        KeyMaskEnable,
        KeyMaskTop,
        KeyMaskBottom,
        KeyMaskLeft,
        KeyMaskRight,
          
        TransitionDVEPattern,
        DVEKeyMaskEnable,
        DVEKeyMaskTop,
        DVEKeyMaskBottom,
        DVEKeyMaskLeft,
        DVEKeyMaskRight,
        TransitionDVERate,

        ChromaKeyClip,
        ChromaKeyGain,
        ChromaKeyHue,
        ChromaKeyLift,
        ChromaKeyNarrow,

        PatternKeyPattern,
        PatternKeySize,
        PatternKeySoftness,
        PatternKeyXPosition,
        PatternKeyYPosition,
        PatternKeySymmetry,

        DVEAndFlyKeyXSize,
        DVEAndFlyKeyYSize,

        DVEAndFlyKeyXPosition,
        DVEAndFlyKeyYPosition,

        DVEKeyShadowEnable,
        DVEKeyBorderEnable,
        DVEAndFlyKeyRotation,

        FlyKeySetKeyFrame,
        FlyKeyResetKeyFrame,
        FlyKeyRunToFull,
        FlyKeyRunToFullWithRate,
        FlyKeyRunToKeyFrame,
        FlyKeyRunToKeyFrameWithRate,
        FlyKeyRunToInfinity,

        DVEKeyShadowDirection,
        DVEKeyShadowAltitude,

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

        DownstreamKeyFillInput,
        DownstreamKeyCutInput,
        DownstreamKeyRate,
        DownstreamKeyAuto,
        DownstreamKeyOnAir,
        DownstreamKeyTie,
        DownstreamKeyClip,
        DownstreamKeyGain,
        DownstreamKeyMaskEnable,
        DownstreamKeyMaskTop,
        DownstreamKeyMaskBottom,
        DownstreamKeyMaskLeft,
        DownstreamKeyMaskRight,
        DownstreamKeyInvert,
        DownstreamKeyPreMultiply,

        FadeToBlackRate,
        FadeToBlackCut,
        FadeToBlackAuto, // -

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



        TransitionStyle,
    }
}