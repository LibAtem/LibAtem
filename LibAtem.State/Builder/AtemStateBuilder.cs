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
            AuxStateUpdater.Update(state, result, command);
            ColorStateUpdater.Update(state, result, command);
            MixEffectStateUpdater.Update(state, result, command);

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
            var auxList = new List<AuxState>();
            for (int i = 0; i < cmd.Auxiliaries; i++)
                auxList.Add(new AuxState());
            state.Auxiliaries = auxList;

            var colList = new List<ColorState>();
            for (int i = 0; i < cmd.ColorGenerators; i++)
                colList.Add(new ColorState());
            state.ColorGenerators = colList;
                
            var meList = new List<MixEffectState>();
            for (int i = 0; i < cmd.MixEffectBlocks; i++)
                meList.Add(new MixEffectState());
            state.MixEffects = meList;

            // Everything has changed
            result.SetSuccess("");
        }
    }
}