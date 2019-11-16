using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class AtemState
    {
        public IReadOnlyList<AuxState> Auxiliaries { get; set; } = new List<AuxState>();
        public IReadOnlyList<ColorState> ColorGenerators { get; set; } = new List<ColorState>();
        public IReadOnlyList<MixEffectState> MixEffects { get; set; } = new List<MixEffectState>();
        
        #region Clone
        public AtemState Clone()
        {
            return CloneObj(this);
        }
        
        private static AtemState CloneObj(AtemState obj)
        {
            MemoryStream ms = null;
            AtemState clonedObj = null;
            try
            {
                // Serialize
                BinaryFormatter serializer = new BinaryFormatter();
                ms = new MemoryStream();
                serializer.Serialize(ms, obj);
                
                // Deserialize
                ms.Position = 0;
                var obj2 = serializer.Deserialize(ms);
                if (obj2 is AtemState obj3)
                    clonedObj = obj3;
            }
            catch (Exception unexpected)
            {
                Trace.Fail(unexpected.Message);
                throw;
            }
            {
                ms?.Close();
            }
            return clonedObj;
        }
#endregion Clone
    }
}