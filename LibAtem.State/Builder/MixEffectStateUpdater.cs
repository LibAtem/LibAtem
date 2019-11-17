using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
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
                    result.SetSuccess($"MixEffects.{progCmd.Index}.Sources");
                });
            }
            else if (command is PreviewInputGetCommand prevCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) prevCmd.Index, me => { 
                    me.Sources.Preview = prevCmd.Source;
                    result.SetSuccess($"MixEffects.{prevCmd.Index}.Sources");
                });
            }

            UpdateTransition(state, result, command);
        }

        private static void UpdateTransition(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is TransitionPropertiesGetCommand transCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) transCmd.Index, me =>
                {
                    UpdaterUtil.CopyAllProperties(transCmd, me.Transition.Properties, new []{"Index"});
                    result.SetSuccess($"MixEffects.{transCmd.Index}.Transition.Properties");
                });
            }
            else if (command is TransitionMixGetCommand mixCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) mixCmd.Index, me =>
                {
                    if (me.Transition.Mix == null) me.Transition.Mix = new MixEffectState.TransitionMixState();

                    me.Transition.Mix.Rate = mixCmd.Rate;
                    result.SetSuccess($"MixEffects.{mixCmd.Index}.Transition.Mix");
                });
            }
            else if (command is TransitionDipGetCommand dipCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) dipCmd.Index, me =>
                {
                    if (me.Transition.Dip == null) me.Transition.Dip = new MixEffectState.TransitionDipState();

                    UpdaterUtil.CopyAllProperties(dipCmd, me.Transition.Dip, new []{"Index"});
                    result.SetSuccess($"MixEffects.{dipCmd.Index}.Transition.Dip");
                });
            }
            else if (command is TransitionWipeGetCommand wipeCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) wipeCmd.Index, me =>
                {
                    if (me.Transition.Wipe == null) me.Transition.Wipe = new MixEffectState.TransitionWipeState();

                    UpdaterUtil.CopyAllProperties(wipeCmd, me.Transition.Wipe, new []{"Index"});
                    result.SetSuccess($"MixEffects.{wipeCmd.Index}.Transition.Wipe");
                });
            }
            else if (command is TransitionStingerGetCommand stingerCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) stingerCmd.Index, me =>
                {
                    if (me.Transition.Stinger == null) me.Transition.Stinger = new MixEffectState.TransitionStingerState();

                    UpdaterUtil.CopyAllProperties(stingerCmd, me.Transition.Stinger, new []{"Index"});
                    result.SetSuccess($"MixEffects.{stingerCmd.Index}.Transition.Stinger");
                });
            }
            else if (command is TransitionDVEGetCommand dveCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) dveCmd.Index, me =>
                {
                    if (me.Transition.DVE == null) me.Transition.DVE = new MixEffectState.TransitionDVEState();

                    UpdaterUtil.CopyAllProperties(dveCmd, me.Transition.DVE, new []{"Index"});
                    result.SetSuccess($"MixEffects.{dveCmd.Index}.Transition.DVE");
                });
            }
        }
    }
}