using System.Collections.Generic;
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
            Profile.Model = cmd.Model;
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
            
            // TODO
            // public uint DownstreamKeys { get; set; }
            // RoutableKeyMasks
            // AudioMonitor
        }

        private void StoreVideoSource(InputPropertiesGetCommand cmd)
        {
            if (cmd.Id > VideoSource.Input20 || cmd.Id < VideoSource.Input1)
                return;

            Profile.Sources.RemoveAll(d => d.Id == cmd.Id);

            Profile.Sources.Add(new DevicePort
            {
                Id = cmd.Id,
                Port = cmd.ExternalPorts,
            });
            Profile.Sources.Sort((a, b) => a.Id.CompareTo(b.Id));
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
            Profile.MultiView.CanRouteInputs = cmd.CanRouteInputs;
            Profile.MultiView.VuMeters = cmd.SupportsVuMeters;
            Profile.MultiView.CanToggleSafeArea = cmd.CanToggleSafeArea;
            Profile.MultiView.CanSwapPreviewProgram = cmd.CanSwapPreviewProgram;
            // TODO - other props
        }
    }
}