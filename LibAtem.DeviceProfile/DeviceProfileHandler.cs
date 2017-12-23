using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.Settings;
using LibAtem.Common;

namespace LibAtem.DeviceProfile
{
    public class DeviceProfileHandler
    {
        public DeviceProfileHandler()
        {
            Profile = DeviceProfileRepository.GetSystemProfile(DeviceProfileType.Auto);
        }

        public DeviceProfile Profile { get; }

        public void HandleCommands(object sender, IReadOnlyList<ICommand> commands)
        {
            foreach (ICommand cmd in commands)
            {
                if (cmd is ProductIdentifierCommand)
                    StoreIdentifier(cmd as ProductIdentifierCommand);
                if (cmd is TopologyCommand)
                    StoreTopology(cmd as TopologyCommand);
                if (cmd is InputPropertiesGetCommand)
                    StoreVideoSource(cmd as InputPropertiesGetCommand);
                if (cmd is MixEffectBlockConfigCommand)
                    StoreMixEffectBlock(cmd as MixEffectBlockConfigCommand);
                if (cmd is MediaPoolConfigCommand)
                    StoreMediaPool(cmd as MediaPoolConfigCommand);
                if (cmd is MacroPoolConfigCommand)
                    StoreMacroPool(cmd as MacroPoolConfigCommand);
                if (cmd is MultiviewerConfigCommand)
                    StoreMultiViewer(cmd as MultiviewerConfigCommand);
            }
        }

        private void StoreIdentifier(ProductIdentifierCommand cmd)
        {
            Profile.Product = cmd.Name;
        }

        private void StoreTopology(TopologyCommand cmd)
        {
            Profile.MixEffectBlocks = cmd.MixEffectBlocks;
            Profile.ColorGenerators = cmd.ColorGenerators;
            Profile.Auxiliaries = cmd.Auxiliaries;
            Profile.MediaPlayers = cmd.MediaPlayers;
            Profile.SerialPort = cmd.SerialPort;
            Profile.HyperDecks = cmd.HyperDecks;
            Profile.DVE = cmd.DVE;
            Profile.Stingers = cmd.Stingers;
            Profile.SuperSource = cmd.SuperSource;

            // Ensure VideoSources is the correct length, even if the values are wrong
            while (Profile.Sources.Count < cmd.VideoSources)
                Profile.Sources.Add(new DevicePort {Id = (VideoSource) (Profile.Sources.Count + 1), Port = new List<ExternalPortType> {ExternalPortType.SDI}});
            if (Profile.Sources.Count > cmd.VideoSources)
                Profile.Sources = Profile.Sources.OrderBy(c => c.Id).Take((int) cmd.VideoSources).ToList();

            // TODO
            // public uint DownstreamKeys { get; set; }
        }

        private void StoreVideoSource(InputPropertiesGetCommand cmd)
        {
            if (Profile.Sources.Count <= (int) cmd.Id)
                return;

            Profile.Sources[(int) cmd.Id] = new DevicePort
            {
                Id = cmd.Id,
                Port = cmd.ExternalPorts,
            };
        }

        private void StoreMixEffectBlock(MixEffectBlockConfigCommand cmd)
        {
            if (cmd.Index == MixEffectBlockId.One)
                Profile.UpstreamKeys = cmd.KeyCount;
        }

        private void StoreMediaPool(MediaPoolConfigCommand cmd)
        {
            Profile.MediaPoolClips = cmd.ClipCount;
            Profile.MediaPoolStills = cmd.StillCount;
        }

        private void StoreMacroPool(MacroPoolConfigCommand cmd)
        {
            Profile.MacroCount = cmd.MacroCount;
        }

        private void StoreMultiViewer(MultiviewerConfigCommand cmd)
        {
            Profile.MultiView.Count = cmd.Count;
            // TODO - other props
        }
    }
}