using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.Settings;
using LibAtem.Commands.Settings.Multiview;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.State.Builder
{
    internal static class SettingsStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is SerialPortModeCommand serialCmd)
            {
                state.Settings.SerialMode = serialCmd.SerialMode;
                result.SetSuccess($"Settings.SerialMode");
            }
            else if (command is VideoModeGetCommand videoCmd)
            {
                state.Settings.VideoMode = videoCmd.VideoMode;
                result.SetSuccess($"Settings.VideoMode");
            }
            else if (command is MultiviewVideoModeGetCommand mvCmd)
            {
                state.Settings.MultiviewVideoModes[mvCmd.CoreVideoMode] = mvCmd.MultiviewMode;
                result.SetSuccess($"Settings.MultiviewVideoModes.{mvCmd.CoreVideoMode:D}");
            }
            else if (command is DownConvertVideoModeGetCommand dcCmd)
            {
                state.Settings.DownConvertVideoModes[dcCmd.CoreVideoMode] = dcCmd.DownConvertedMode;
                result.SetSuccess($"Settings.DownConvertVideoModes.{dcCmd.CoreVideoMode:D}");
            }
            else if (command is AutoVideoModeCommand avmCmd)
            {
                var paths = new List<string> { "Settings.AutoVideoMode" };
                state.Settings.AutoVideoMode = avmCmd.Enabled;
                state.Settings.DetectedVideoMode = avmCmd.Detected;

                if (!state.Info.SupportsAutoVideoMode)
                {
                    state.Info.SupportsAutoVideoMode = true;
                    paths.Add("Info.SupportsAutoVideoMode");
                }

                result.SetSuccess(paths);
            }
            else if (command is DownConvertModeGetCommand dcModeCmd)
            {
                state.Settings.DownConvertMode = dcModeCmd.DownConvertMode;
                result.SetSuccess($"Settings.DownConvertVideoMode");
            }
            else if (command is SDI3GLevelOutputGetCommand sdiLevelCmd)
            {
                state.Settings.SDI3GLevel = sdiLevelCmd.SDI3GOutputLevel;
                result.SetSuccess("Settings.SDI3GLevel");
            }
            else if (command is SuperSourceCascadeCommand cascadeCmd)
            {
                state.Settings.SuperSourceCascade = cascadeCmd.Cascade;
                result.SetSuccess("Settings.SuperSourceCascade");
            }
            else if (command is MixMinusOutputGetCommand mmoCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.MixMinusOutputs, (int)mmoCmd.Id, output =>
                {
                    UpdaterUtil.CopyAllProperties(mmoCmd, output, new[] { "Id" });
                    result.SetSuccess($"Settings.MixMinusOutputs.{mmoCmd.Id:D}");
                });
            }

            UpdateInputs(state, result, command);
            UpdateMultiViewers(state, result, command);
        }

        private static void UpdateInputs(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is InputPropertiesGetCommand propsCmd)
            {
                if (!state.Settings.Inputs.ContainsKey(propsCmd.Id))
                    state.Settings.Inputs[propsCmd.Id] = new InputState();
                InputState props = state.Settings.Inputs[propsCmd.Id];

                props.Properties.AreNamesDefault = propsCmd.AreNamesDefault;
                props.Properties.LongName = propsCmd.LongName;
                props.Properties.ShortName = propsCmd.ShortName;

                //props.IsExternal = cmd.IsExternal;
                props.Properties.AvailableExternalPortTypes = propsCmd.AvailableExternalPorts.FindFlagComponents();
                props.Properties.CurrentExternalPortType = propsCmd.ExternalPortType;
                props.Properties.InternalPortType = propsCmd.InternalPortType;
                props.Properties.SourceAvailability = propsCmd.SourceAvailability;
                props.Properties.MeAvailability = propsCmd.MeAvailability;
                result.SetSuccess($"Settings.Inputs.{propsCmd.Id:D}.Properties");
            }
            else if (command is TallyBySourceCommand tallyCmd)
            {
                foreach (KeyValuePair<VideoSource, Tuple<bool, bool>> inp in tallyCmd.Tally)
                {
                    if (state.Settings.Inputs.TryGetValue(inp.Key, out InputState input))
                    {
                        InputState.TallyState inputTally = input.Tally;
                        if (inputTally.ProgramTally != inp.Value.Item1 || inputTally.PreviewTally != inp.Value.Item2)
                        {
                            inputTally.ProgramTally = inp.Value.Item1;
                            inputTally.PreviewTally = inp.Value.Item2;
                            result.SetSuccess($"Settings.Inputs.{inp.Key:D}.Tally");
                        }
                    }
                }
            }
        }

        private static void UpdateMultiViewers(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is MultiviewerConfigV8Command multiview8Cmd)
            {
                state.Info.MultiViewers = new InfoState.MultiViewInfoState
                {
                    CanRouteInputs = multiview8Cmd.CanRouteInputs,
                    SupportsVuMeters = multiview8Cmd.SupportsVuMeters,
                    SupportsProgramPreviewSwapped = multiview8Cmd.CanSwapPreviewProgram,
                    SupportsQuadrantLayout = multiview8Cmd.SupportsQuadrants,
                    SupportsToggleSafeArea = multiview8Cmd.CanToggleSafeArea,
                };

                state.Settings.MultiViewers = UpdaterUtil.UpdateList(state.Settings.MultiViewers, multiview8Cmd.Count, i => new MultiViewerState
                {
                    Windows = new List<MultiViewerState.WindowState>(), // Size gets done in a second
                });
                state.Settings.MultiViewers.ForEach(mv => mv.Windows = UpdaterUtil.UpdateList(mv.Windows,
                    multiview8Cmd.WindowCount,
                    w => new MultiViewerState.WindowState()));
                result.SetSuccess(new[] {$"Info.MultiViewers", $"Settings.MultiViewers"});
            }
            else if (command is MultiviewerConfigCommand multiviewCmd)
            {
                state.Info.MultiViewers = new InfoState.MultiViewInfoState
                {
                    CanRouteInputs = multiviewCmd.CanRouteInputs,
                    SupportsProgramPreviewSwapped = multiviewCmd.CanSwapPreviewProgram
                };

                state.Settings.MultiViewers = UpdaterUtil.UpdateList(state.Settings.MultiViewers, multiviewCmd.Count, i => new MultiViewerState
                {
                    Windows = new List<MultiViewerState.WindowState>(), // Size gets done in a second
                });
                state.Settings.MultiViewers.ForEach(mv => mv.Windows = UpdaterUtil.UpdateList(mv.Windows,
                    multiviewCmd.WindowCount,
                    w => new MultiViewerState.WindowState()));
                result.SetSuccess(new[] { $"Info.MultiViewers", $"Settings.MultiViewers" });
            }
            else if (command is MultiviewVuOpacityCommand vuOpacityCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.MultiViewers, (int)vuOpacityCmd.MultiviewIndex, mv =>
                {
                    mv.VuMeterOpacity = vuOpacityCmd.Opacity;
                    result.SetSuccess($"Settings.MultiViewers.{vuOpacityCmd.MultiviewIndex:D}.VuMeterOpacity");
                });
            }
            else if (command is MultiviewPropertiesGetV8Command props8Cmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.MultiViewers, (int)props8Cmd.MultiviewIndex, mv =>
                {
                    mv.Properties.Layout = props8Cmd.Layout;
                    mv.Properties.ProgramPreviewSwapped = props8Cmd.ProgramPreviewSwapped;

                    result.SetSuccess($"Settings.MultiViewers.{props8Cmd.MultiviewIndex:D}.Properties");
                });
            }
            else if (command is MultiviewPropertiesGetCommand propsCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.MultiViewers, (int)propsCmd.MultiviewIndex, mv =>
                {
                    if (!Enum.TryParse(propsCmd.Layout.ToString(), true, out MultiViewLayoutV8 layout))
                        layout = 0;
                    mv.Properties.Layout = layout;
                    mv.Properties.ProgramPreviewSwapped = propsCmd.ProgramPreviewSwapped;
                    
                    result.SetSuccess($"Settings.MultiViewers.{propsCmd.MultiviewIndex:D}.Properties");
                });
            }
            else if (command is MultiviewWindowInputGetCommand winCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.MultiViewers, (int)winCmd.MultiviewIndex, mv =>
                {
                    UpdaterUtil.TryForIndex(result, mv.Windows, (int) winCmd.WindowIndex, win =>
                    {
                        win.Source = winCmd.Source;
                        win.SupportsVuMeter = winCmd.SupportVuMeter;
                        win.SupportsSafeArea = winCmd.SupportsSafeArea;

                        result.SetSuccess($"Settings.MultiViewers.{winCmd.MultiviewIndex:D}.Windows.{winCmd.WindowIndex:D}");
                    });
                });
            }
            else if (command is MultiviewWindowVuMeterGetCommand vuMeterCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.MultiViewers, (int)vuMeterCmd.MultiviewIndex, mv =>
                {
                    UpdaterUtil.TryForIndex(result, mv.Windows, (int) vuMeterCmd.WindowIndex, win =>
                    {
                        win.VuMeterEnabled = vuMeterCmd.VuEnabled;
                        result.SetSuccess($"Settings.MultiViewers.{vuMeterCmd.MultiviewIndex:D}.Windows.{vuMeterCmd.WindowIndex:D}");
                    });
                });
            }
            else if (command is MultiviewWindowSafeAreaCommand safeAreaCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.MultiViewers, (int)safeAreaCmd.MultiviewIndex, mv =>
                {
                    UpdaterUtil.TryForIndex(result, mv.Windows, (int)safeAreaCmd.WindowIndex, win =>
                    {
                        win.SafeAreaEnabled = safeAreaCmd.SafeAreaEnabled;
                        result.SetSuccess($"Settings.MultiViewers.{safeAreaCmd.MultiviewIndex:D}.SafeAreaEnabled");
                    });
                });
            }
        }
    }
}