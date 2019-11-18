using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.Macro;

namespace LibAtem.State.Builder
{
    internal static class MacroStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is MacroPoolConfigCommand macroCmd)
            {
                state.Macros.Pool = UpdaterUtil.CreateList(macroCmd.MacroCount, i => new MacroState.ItemState());
                result.SetSuccess("Macros.Pool");
            }
            else if (command is MacroPropertiesGetCommand propsCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Macros.Pool, (int)propsCmd.Index, item =>
                {
                    UpdaterUtil.CopyAllProperties(propsCmd, item, new []{"Index"});
                    result.SetSuccess($"Macros.Pool.{propsCmd.Index:D}");
                });
            }
            else if (command is MacroRunStatusGetCommand runCmd)
            {
                state.Macros.RunStatus.RunIndex = runCmd.Index;
                state.Macros.RunStatus.Loop = runCmd.Loop;
                
                if (runCmd.IsWaiting)
                    state.Macros.RunStatus.RunStatus = MacroState.MacroRunStatus.UserWait;
                else if (runCmd.IsRunning)
                    state.Macros.RunStatus.RunStatus = MacroState.MacroRunStatus.Running;
                else
                    state.Macros.RunStatus.RunStatus = MacroState.MacroRunStatus.Idle;
                
                result.SetSuccess("Macros.RunStatus");
            }
            else if (command is MacroRecordingStatusGetCommand recordCmd)
            {
                state.Macros.RecordStatus.RecordIndex = recordCmd.Index;
                state.Macros.RecordStatus.IsRecording = recordCmd.IsRecording;
                
                result.SetSuccess("Macros.RecordStatus");
            }
        }
    }
}