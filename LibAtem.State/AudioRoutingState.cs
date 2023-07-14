using LibAtem.Common;
using System;
using System.Collections.Generic;

namespace LibAtem.State
{
    [Serializable]
    public class AudioRoutingState
    {
        public Dictionary<uint, AudioRoutingSourceState> Sources { get; set; } = new Dictionary<uint, AudioRoutingSourceState>();

        public Dictionary<uint, AudioRoutingOutputState> Outputs { get; set; } = new Dictionary<uint, AudioRoutingOutputState>();

    }

    [Serializable]
    public class AudioRoutingSourceState
    {
        public long AudioInputId { get; set; }

        public AudioChannelPair AudioChannelPair { get; set; }

        public string Name { get; set; }

        public AudioPortType ExternalPortType { get; set; }

        public AudioInternalPortType InternalPortType { get; set; }
    }

    [Serializable]
    public class AudioRoutingOutputState
    {
        public ushort AudioOutputId { get; set; }

        public AudioChannelPair AudioChannelPair { get; set; }

        public uint SourceId { get; set; }

        public string Name{ get; set; }

        public AudioPortType ExternalPortType { get; set; } 

        public AudioInternalPortType InternalPortType { get; set; }
    }
}