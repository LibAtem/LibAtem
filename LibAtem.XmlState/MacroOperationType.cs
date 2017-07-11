namespace LibAtem.XmlState
{
    // TODO - some of these don't look like possible macro operations
    public enum MacroOperationType
    {
        LoopMacro,

        ProgramInput,//
        PreviewInput,//

        CutTransition,//
        AutoTransition,//

        MacroUserWait,//
        MacroSleep,//

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

        MediaPlayerSourceClip,//

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

        TransitionSource,
        TransitionPosition,
        TransitionPreview,
        TransitionMixRate,
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
        FadeToBlackAuto,//

        SuperSourceArtCutInput, //
        SuperSourceArtFillInput, //
        SuperSourceArtAbove,
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
        SuperSourceBoxEnable, //
        SuperSourceBoxInput,
        SuperSourceBoxXPosition,
        SuperSourceBoxYPosition,
        SuperSourceBoxSize,
        SuperSourceBoxMaskEnable,
        SuperSourceBoxMaskTop,
        SuperSourceBoxMaskBottom,
        SuperSourceBoxMaskLeft,
        SuperSourceBoxMaskRight,
        
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

        MediaPlayerSourceStillIndex, //
        MediaPlayerSourceClipIndex, //
        MediaPlayerGoToBeginning, //
        MediaPlayerGoToFrame,
        MediaPlayerPlay, //
        MediaPlayerPause,
        MediaPlayerLoop,
        MediaPlayerSourceStill, //

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