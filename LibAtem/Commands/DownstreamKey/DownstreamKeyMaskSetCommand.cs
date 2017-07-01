using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsM", 12)]
    public class DownstreamKeyMaskSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Enabled = 1 << 0,
            Top = 1 << 1,
            Bottom = 1 << 2,
            Left = 1 << 3,
            Right = 1 << 4,
        }

        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serializable(1), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serializable(2), Bool]
        public bool Enabled { get; set; }
        [Serializable(4), Int16D(1000, -9000, 9000)]
        public double Top { get; set; }
        [Serializable(6), Int16D(1000, -9000, 9000)]
        public double Bottom { get; set; }
        [Serializable(8), Int16D(1000, -16000, 16000)]
        public double Left { get; set; }
        [Serializable(10), Int16D(1000, -16000, 16000)]
        public double Right { get; set; }
    }
}