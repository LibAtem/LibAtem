using LibAtem.Commands;
using LibAtem.Commands.AudioRouting;

namespace LibAtem.State.Builder
{
    internal static class AudioRoutingStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is AudioRoutingOutputGetCommand outputCmd)
            {
                if (state.AudioRouting == null) state.AudioRouting = new AudioRoutingState();

                if (!state.AudioRouting.Outputs.ContainsKey(outputCmd.Id)) state.AudioRouting.Outputs[outputCmd.Id] = new AudioRoutingOutputState();

                var output = state.AudioRouting.Outputs[outputCmd.Id];

                UpdaterUtil.CopyAllProperties(outputCmd, output, new[] { "Id" });
                result.SetSuccess($"state.AudioRouting.Outputs.{outputCmd.Id}");
            }
            else if (command is AudioRoutingSourceGetCommand sourceCmd)
            {
                if (state.AudioRouting == null) state.AudioRouting = new AudioRoutingState();

                if (!state.AudioRouting.Sources.ContainsKey(sourceCmd.Id)) state.AudioRouting.Sources[sourceCmd.Id] = new AudioRoutingSourceState();

                var source = state.AudioRouting.Sources[sourceCmd.Id];

                UpdaterUtil.CopyAllProperties(sourceCmd, source, new[] { "Id" });
                result.SetSuccess($"state.AudioRouting.Sources.{sourceCmd.Id}");
            }
        }
    }
}