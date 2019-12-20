using System;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class InfoState
    {
        public ProtocolVersion Version { get; set; }

        public bool TimecodeLocked { get; set; }
        public Timecode LastTimecode { get; set; }

        public ModelId Model { get; set; }
        public string ProductName { get; set; }
    }

    [Serializable]
    public class Timecode
    {
        public uint Hour { get; set; }
        public uint Minute { get; set; }
        public uint Second { get; set; }
        public uint Frame { get; set; }

        public bool DropFrame { get; set; }
    }
}