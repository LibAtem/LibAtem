using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibAtem.State
{
    [Serializable]
    public class AtemState
    {
        public IReadOnlyList<AuxState> Auxiliaries { get; set; } = new List<AuxState>();
        public IReadOnlyList<ColorState> ColorGenerators { get; set; } = new List<ColorState>();
        public IReadOnlyList<DownstreamKeyerState> DownstreamKeyers { get; set; } = new List<DownstreamKeyerState>();
        public IReadOnlyList<MediaPlayerState> MediaPlayers { get; set; } = new List<MediaPlayerState>();
        public IReadOnlyList<MixEffectState> MixEffects { get; set; } = new List<MixEffectState>();
        public IReadOnlyList<SuperSourceState> SuperSources { get; set; } = new List<SuperSourceState>();

        public AudioState Audio { get; } = new AudioState();
        public MacroState Macros { get; } = new MacroState();
        public MediaPoolState MediaPool { get; } = new MediaPoolState();
        public SettingsState Settings { get; } = new SettingsState();

        #region Clone
        public AtemState Clone()
        {
            return CloneObj(this);
        }
        
        private static AtemState CloneObj(AtemState obj)
        {
            using (var ms = new MemoryStream())
            {
                // Serialize
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(ms, obj);
                
                // Deserialize
                ms.Position = 0;
                return (AtemState) serializer.Deserialize(ms);
            }
        }
        #endregion Clone
    }
}