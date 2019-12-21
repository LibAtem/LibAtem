using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Commands.MixEffects.Transition;

namespace LibAtem.State.Builder
{
    internal static class MixEffectStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is ProgramInputGetCommand progCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) progCmd.Index, me => { 
                    me.Sources.Program = progCmd.Source;
                    result.SetSuccess($"MixEffects.{progCmd.Index:D}.Sources");
                });
            }
            else if (command is PreviewInputGetCommand prevCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) prevCmd.Index, me => { 
                    me.Sources.Preview = prevCmd.Source;
                    result.SetSuccess($"MixEffects.{prevCmd.Index:D}.Sources");
                });
            }
            else if (command is FadeToBlackPropertiesGetCommand ftbPropCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int)ftbPropCmd.Index, me =>
                {
                    UpdaterUtil.CopyAllProperties(ftbPropCmd, me.FadeToBlack.Properties, new[] {"Index"});
                    result.SetSuccess($"MixEffects.{ftbPropCmd.Index:D}.FadeToBlack.Properties");
                });
            }
            else if (command is FadeToBlackStateCommand ftbCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int)ftbCmd.Index, me =>
                {
                    UpdaterUtil.CopyAllProperties(ftbCmd, me.FadeToBlack.Status, new[] { "Index" });
                    result.SetSuccess($"MixEffects.{ftbCmd.Index:D}.FadeToBlack.Status");
                });
            }

            UpdateTransition(state, result, command);
            UpdateKeyers(state, result, command);
        }


        private static void UpdateKeyers(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is MixEffectBlockConfigCommand confCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) confCmd.Index, me =>
                {
                    me.Keyers = UpdaterUtil.CreateList(confCmd.KeyCount, i => new MixEffectState.KeyerState());
                    result.SetSuccess($"MixEffects.{confCmd.Index:D}.Keyers");
                });
            }
            else if (command is MixEffectKeyOnAirGetCommand onAirCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) onAirCmd.MixEffectIndex, me =>
                {
                    UpdaterUtil.TryForIndex(result, me.Keyers, (int) onAirCmd.KeyerIndex, keyer =>
                    {
                        keyer.OnAir = onAirCmd.OnAir;
                        result.SetSuccess($"MixEffects.{onAirCmd.MixEffectIndex:D}.Keyers.{onAirCmd.KeyerIndex:D}.OnAir");
                    });
                });
            }
            else if (command is MixEffectKeyPropertiesGetCommand propsCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) propsCmd.MixEffectIndex, me =>
                {
                    UpdaterUtil.TryForIndex(result, me.Keyers, (int) propsCmd.KeyerIndex, keyer =>
                    {
                        UpdaterUtil.CopyAllProperties(propsCmd, keyer.Properties, new []{"MixEffectIndex", "KeyerIndex"});
                        result.SetSuccess($"MixEffects.{propsCmd.MixEffectIndex:D}.Keyers.{propsCmd.KeyerIndex:D}.Properties");
                    });
                });
            }
            else if (command is MixEffectKeyLumaGetCommand lumaCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) lumaCmd.MixEffectIndex, me =>
                {
                    UpdaterUtil.TryForIndex(result, me.Keyers, (int) lumaCmd.KeyerIndex, keyer =>
                    {
                        if (keyer.Luma == null) keyer.Luma = new MixEffectState.KeyerLumaState();
                        
                        UpdaterUtil.CopyAllProperties(lumaCmd, keyer.Luma, new []{"MixEffectIndex", "KeyerIndex"});
                        result.SetSuccess($"MixEffects.{lumaCmd.MixEffectIndex:D}.Keyers.{lumaCmd.KeyerIndex:D}.Luma");
                    });
                });
            }
            else if (command is MixEffectKeyChromaGetCommand chromaCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) chromaCmd.MixEffectIndex, me =>
                {
                    UpdaterUtil.TryForIndex(result, me.Keyers, (int) chromaCmd.KeyerIndex, keyer =>
                    {
                        if (keyer.Chroma == null) keyer.Chroma = new MixEffectState.KeyerChromaState();
                        
                        UpdaterUtil.CopyAllProperties(chromaCmd, keyer.Chroma, new []{"MixEffectIndex", "KeyerIndex"});
                        result.SetSuccess($"MixEffects.{chromaCmd.MixEffectIndex:D}.Keyers.{chromaCmd.KeyerIndex:D}.Chroma");
                    });
                });
            }
            else if (command is MixEffectKeyPatternGetCommand patternCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) patternCmd.MixEffectIndex, me =>
                {
                    UpdaterUtil.TryForIndex(result, me.Keyers, (int) patternCmd.KeyerIndex, keyer =>
                    {
                        if (keyer.Pattern == null) keyer.Pattern = new MixEffectState.KeyerPatternState();
                        
                        UpdaterUtil.CopyAllProperties(patternCmd, keyer.Pattern, new []{"MixEffectIndex", "KeyerIndex"});
                        result.SetSuccess($"MixEffects.{patternCmd.MixEffectIndex:D}.Keyers.{patternCmd.KeyerIndex:D}.Pattern");
                    });
                });
            }
            else if (command is MixEffectKeyDVEGetCommand dveCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) dveCmd.MixEffectIndex, me =>
                {
                    UpdaterUtil.TryForIndex(result, me.Keyers, (int) dveCmd.KeyerIndex, keyer =>
                    {
                        if (keyer.DVE == null) keyer.DVE = new MixEffectState.KeyerDVEState();
                        
                        UpdaterUtil.CopyAllProperties(dveCmd, keyer.DVE, new []{"MixEffectIndex", "KeyerIndex"});
                        result.SetSuccess($"MixEffects.{dveCmd.MixEffectIndex:D}.Keyers.{dveCmd.KeyerIndex:D}.DVE");
                    });
                });
            }
            else if (command is MixEffectKeyFlyKeyframeGetCommand flyFrameCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) flyFrameCmd.MixEffectIndex, me =>
                {
                    UpdaterUtil.TryForIndex(result, me.Keyers, (int) flyFrameCmd.KeyerIndex, keyer =>
                    {
                        if (keyer.FlyFrames == null)
                        {
                            keyer.FlyFrames = new[]
                            {
                                new MixEffectState.KeyerFlyFrameState(),
                                new MixEffectState.KeyerFlyFrameState()
                            };
                        }

                        UpdaterUtil.TryForIndex(result, keyer.FlyFrames, (int) flyFrameCmd.KeyFrame - 1, frame =>
                        {
                            UpdaterUtil.CopyAllProperties(flyFrameCmd, frame, new[] {"MixEffectIndex", "KeyerIndex", "KeyFrame"});
                            result.SetSuccess($"MixEffects.{flyFrameCmd.MixEffectIndex:D}.Keyers.{flyFrameCmd.KeyerIndex:D}.FlyFrames.{(flyFrameCmd.KeyFrame - 1):D}");
                        });
                    });
                });
            }
        }

        private static void UpdateTransition(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is TransitionPropertiesGetCommand transCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) transCmd.Index, me =>
                {
                    UpdaterUtil.CopyAllProperties(transCmd, me.Transition.Properties, new []{"Index"});
                    result.SetSuccess($"MixEffects.{transCmd.Index:D}.Transition.Properties");
                });
            }
            else if (command is TransitionMixGetCommand mixCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) mixCmd.Index, me =>
                {
                    if (me.Transition.Mix == null) me.Transition.Mix = new MixEffectState.TransitionMixState();

                    me.Transition.Mix.Rate = mixCmd.Rate;
                    result.SetSuccess($"MixEffects.{mixCmd.Index:D}.Transition.Mix");
                });
            }
            else if (command is TransitionDipGetCommand dipCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) dipCmd.Index, me =>
                {
                    if (me.Transition.Dip == null) me.Transition.Dip = new MixEffectState.TransitionDipState();

                    UpdaterUtil.CopyAllProperties(dipCmd, me.Transition.Dip, new []{"Index"});
                    result.SetSuccess($"MixEffects.{dipCmd.Index:D}.Transition.Dip");
                });
            }
            else if (command is TransitionWipeGetCommand wipeCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) wipeCmd.Index, me =>
                {
                    if (me.Transition.Wipe == null) me.Transition.Wipe = new MixEffectState.TransitionWipeState();

                    UpdaterUtil.CopyAllProperties(wipeCmd, me.Transition.Wipe, new []{"Index"});
                    result.SetSuccess($"MixEffects.{wipeCmd.Index:D}.Transition.Wipe");
                });
            }
            else if (command is TransitionStingerGetCommand stingerCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) stingerCmd.Index, me =>
                {
                    if (me.Transition.Stinger != null)
                    {
                        UpdaterUtil.CopyAllProperties(stingerCmd, me.Transition.Stinger, new[] {"Index"});
                        result.SetSuccess($"MixEffects.{stingerCmd.Index:D}.Transition.Stinger");
                    }
                });
            }
            else if (command is TransitionDVEGetCommand dveCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) dveCmd.Index, me =>
                {
                    if (me.Transition.DVE == null) me.Transition.DVE = new MixEffectState.TransitionDVEState();

                    UpdaterUtil.CopyAllProperties(dveCmd, me.Transition.DVE, new []{"Index"});
                    result.SetSuccess($"MixEffects.{dveCmd.Index:D}.Transition.DVE");
                });
            }
        }
    }
}