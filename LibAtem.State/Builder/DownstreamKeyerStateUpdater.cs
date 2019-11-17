using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;

namespace LibAtem.State.Builder
{
    internal static class DownstreamKeyerStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is DownstreamKeyPropertiesGetCommand propsCmd)
            {
                UpdaterUtil.TryForIndex(result, state.DownstreamKeyers, (int) propsCmd.Index, dsk =>
                {
                    UpdaterUtil.CopyAllProperties(propsCmd, dsk.Properties, new []{"Index"});
                    result.SetSuccess($"DownstreamKeyers.{propsCmd.Index}.Properties");
                });
            }
            else if (command is DownstreamKeySourceGetCommand sourceCmd)
            {
                UpdaterUtil.TryForIndex(result, state.DownstreamKeyers, (int) sourceCmd.Index, dsk =>
                {
                    UpdaterUtil.CopyAllProperties(sourceCmd, dsk.Sources, new []{"Index"});
                    result.SetSuccess($"DownstreamKeyers.{sourceCmd.Index}.Sources");
                });
            }
            else if (command is DownstreamKeyStateGetV8Command state8Cmd)
            {
                UpdaterUtil.TryForIndex(result, state.DownstreamKeyers, (int)state8Cmd.Index, dsk =>
                {
                    UpdaterUtil.CopyAllProperties(state8Cmd, dsk.State, new[] { "Index" });
                    result.SetSuccess($"DownstreamKeyers.{state8Cmd.Index}.State");
                });
            }
            else if (command is DownstreamKeyStateGetCommand stateCmd)
            {
                UpdaterUtil.TryForIndex(result, state.DownstreamKeyers, (int) stateCmd.Index, dsk =>
                {
                    UpdaterUtil.CopyAllProperties(stateCmd, dsk.State, new[] { "Index" }, new[] { "IsTowardsOnAir" });
                    result.SetSuccess($"DownstreamKeyers.{stateCmd.Index}.State");
                });
            }
        }
    }
}