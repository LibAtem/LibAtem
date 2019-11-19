using System;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class InfoState
    {
        public ProtocolVersion Version { get; set; }

        public bool TimecodeLocked { get; set; }

        public ModelId Model { get; set; }
        public string ProductName { get; set; }
    }
}