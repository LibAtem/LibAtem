using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.Settings;
using LibAtem.Common;
using LibAtem.Util;

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
                if (cmd is TopologyV8Command topCmd8)
                    StoreTopologyV8(topCmd8);
                if (cmd is InputPropertiesGetCommand)
                    StoreVideoSource(cmd as InputPropertiesGetCommand);
                if (cmd is AudioMixerInputGetCommand)
                    StoreAudioSource(cmd as AudioMixerInputGetCommand);
                if (cmd is MixEffectBlockConfigCommand)
                    StoreMixEffectBlock(cmd as MixEffectBlockConfigCommand);
                if (cmd is MediaPoolConfigCommand)
                    StoreMediaPool(cmd as MediaPoolConfigCommand);
                if (cmd is MacroPoolConfigCommand)
                    StoreMacroPool(cmd as MacroPoolConfigCommand);
                if (cmd is MultiviewerConfigCommand)
                    StoreMultiViewer(cmd as MultiviewerConfigCommand);
                if (cmd is VideoMixerConfigCommand)
                    StoreVideoMixerConfig(cmd as VideoMixerConfigCommand);
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
            Profile.TalkbackOverSDI = cmd.TalkbackOverSDI > 0;

            // TODO
            // public uint DownstreamKeys { get; set; }
            // RoutableKeyMasks
            // AudioMonitor
        }
        
        private void StoreTopologyV8(TopologyV8Command cmd)
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
            Profile.TalkbackOverSDI = cmd.TalkbackOverSDI > 0;

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
                Port = cmd.AvailableExternalPorts.ToExternalPortTypes().ToList(),
            });
            Profile.Sources.Sort((a, b) => a.Id.CompareTo(b.Id));
        }

        private void StoreAudioSource(AudioMixerInputGetCommand cmd)
        {
            Profile.AudioSources.RemoveAll(d => d == cmd.Index);

            Profile.AudioSources.Add(cmd.Index);
            Profile.AudioSources.Sort((a, b) => a.CompareTo(b));
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

        private void StoreVideoMixerConfig(VideoMixerConfigCommand cmd)
        {
            foreach (VideoMixerConfigCommand.Entry m in cmd.Modes) {
                Profile.VideoModes.SupportedModes.Add(m.Mode);
            }
        }
    }
}