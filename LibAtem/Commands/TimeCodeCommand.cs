using System;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("Time", CommandDirection.ToClient, 8), NoCommandId]
    public class TimeCodeCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8Range(0, 23)]
        public uint Hour { get; set; }

        [Serialize(1), UInt8Range(0, 59)]
        public uint Minute { get; set; }

        [Serialize(2), UInt8Range(0, 59)]
        public uint Second { get; set; }

        [Serialize(3), UInt8Range(0, 59)]
        public uint Frame { get; set; }

        [Serialize(5), Bool]
        public bool IsDropFrame { get; set; }
    }
}