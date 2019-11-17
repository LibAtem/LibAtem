using System;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;

namespace LibAtem.State.Builder
{
    public static class AtemStateBuilder
    {
        public static IUpdateResult Update(AtemState state, ICommand command)
        {
            var result = new UpdateResultImpl();

            UpdateInternal(state, result, command);
            AudioStateUpdater.Update(state, result, command);
            AuxStateUpdater.Update(state, result, command);
            ColorStateUpdater.Update(state, result, command);
            DownstreamKeyerStateUpdater.Update(state, result, command);
            MacroStateUpdater.Update(state, result, command);
            MediaPlayerStateUpdater.Update(state, result, command);
            MediaPoolStateUpdater.Update(state, result, command);
            MixEffectStateUpdater.Update(state, result, command);
            SettingsStateUpdater.Update(state, result, command);
            SuperSourceStateUpdater.Update(state, result, command);

            return result;
        }

        private static void UpdateInternal(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is TopologyCommand topCmd)
            {
                HandleTopologyCommand(state, result, new TopologyV8Command
                {
                    MixEffectBlocks = topCmd.MixEffectBlocks,
                    VideoSources = topCmd.VideoSources,
                    ColorGenerators = topCmd.ColorGenerators,
                    Auxiliaries = topCmd.Auxiliaries,
                    TalkbackOutputs = topCmd.TalkbackOutputs,
                    MediaPlayers = topCmd.MediaPlayers,
                    SerialPort = topCmd.SerialPort,
                    HyperDecks = topCmd.HyperDecks,
                    DVE = topCmd.DVE,
                    Stingers = topCmd.Stingers,
                    SuperSource = topCmd.SuperSource,
                    TalkbackOverSDI = topCmd.TalkbackOverSDI,
                });
            }
            else if (command is TopologyV8Command topCmd8)
            {
                HandleTopologyCommand(state, result, topCmd8);
            }
        }

        private static void HandleTopologyCommand(AtemState state, UpdateResultImpl result, TopologyV8Command cmd)
        {
            state.Auxiliaries = UpdaterUtil.CreateList(cmd.Auxiliaries, (i) => new AuxState());
            state.ColorGenerators = UpdaterUtil.CreateList(cmd.ColorGenerators, (i) => new ColorState());
            state.DownstreamKeyers = UpdaterUtil.CreateList(2, (i) => new DownstreamKeyerState()); // TODO - isnt this known?
            state.MediaPlayers = UpdaterUtil.CreateList(cmd.MediaPlayers, (i) => new MediaPlayerState());
            state.MixEffects = UpdaterUtil.CreateList(cmd.MixEffectBlocks, (i) => new MixEffectState());
            state.SuperSources = UpdaterUtil.CreateList(cmd.SuperSource, (i) => new SuperSourceState());

            // Everything has changed
            result.SetSuccess("");
        }

        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}