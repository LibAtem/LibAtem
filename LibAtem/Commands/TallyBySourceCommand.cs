using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.Commands
{
    [CommandName("TlSr"), NoCommandId]
    public class TallyBySourceCommand : ICommand
    {
        public Dictionary<VideoSource, Tuple<bool, bool>> Tally { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Tally.Count);

            foreach (var src in Tally)
            {
                cmd.AddUInt16((int) src.Key);
                cmd.AddBoolArray(src.Value.Item1, src.Value.Item2);
            }

            cmd.PadToNearestMultipleOf4();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            uint count = cmd.GetUInt16();
            Tally = new Dictionary<VideoSource, Tuple<bool, bool>>();

            for (int i = 0; i < count; i++)
            {
                VideoSource src = (VideoSource) cmd.GetUInt16();
                bool[] arr = cmd.GetBoolArray();
                Tally.Add(src, Tuple.Create(arr[0], arr[1]));
            }

            cmd.SkipToNearestMultipleOf4();
        }
    }
}