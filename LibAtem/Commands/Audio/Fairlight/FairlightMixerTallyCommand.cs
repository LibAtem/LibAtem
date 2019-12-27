using LibAtem.Common;
using System;
using System.Collections.Generic;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FMTl", CommandDirection.ToClient), NoCommandId]
    public class FairlightMixerTallyCommand : ICommand
    {
        public Dictionary<Tuple<AudioSource, long>, bool> Tally { get; set; }

        public void Deserialize(ParsedByteArray cmd)
        {
            Tally = new Dictionary<Tuple<AudioSource, long>, bool>();

            uint count = cmd.GetUInt16();
            cmd.Skip(6);
            for (uint i = 0; i < count; i++)
            {
                long sourceId = cmd.GetInt64();
                AudioSource inputId = (AudioSource)cmd.GetUInt16();
                bool isMixedIn = cmd.GetBoolArray()[0];
                Tally[Tuple.Create(inputId, sourceId)] = isMixedIn;
            }

            cmd.SkipToNearestMultipleOf4();
        }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Tally.Count);
            cmd.Pad(6);

            foreach(KeyValuePair<Tuple<AudioSource, long>, bool> v in Tally)
            {
                cmd.AddInt64(v.Key.Item2);
                cmd.AddUInt16((uint)v.Key.Item1);
                cmd.AddBoolArray(v.Value);
            }

            cmd.PadToNearestMultipleOf4();
        }
    }
}