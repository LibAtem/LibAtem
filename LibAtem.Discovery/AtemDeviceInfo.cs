using System;
using System.Collections.Generic;

namespace LibAtem.Discovery
{
    public class AtemDeviceInfo
    {
        public static readonly string ServiceName = "_blackmagic._tcp.local";

        public string Name { get; }
        public string DeviceId { get; }
        public DateTime LastSeen { get; }

        public string Address { get; }
        public int Port { get; }

        public IReadOnlyList<string> Strings { get; }

        public AtemDeviceInfo(string name, string deviceId, DateTime lastSeen, string address, int port, IReadOnlyList<string> strings)
        {
            Name = name;
            DeviceId = deviceId;
            LastSeen = lastSeen;
            Address = address;
            Port = port;
            Strings = strings;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}:{2} {3} {4}", Name, Address, Port, DeviceId, string.Join(", ", Strings));
        }
    }
}
