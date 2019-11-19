using System;
using System.Collections.Generic;

namespace LibAtem.Commands
{
    [CommandName("TlIn", CommandDirection.ToClient), NoCommandId]
    public class TallyByInputCommand : ICommand
    {
        public List<Tuple<bool, bool>> Tally { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Tally.Count);

            foreach (Tuple<bool, bool> src in Tally)
                cmd.AddBoolArray(src.Item1, src.Item2);

            cmd.PadToNearestMultipleOf4();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            uint count = cmd.GetUInt16();
            Tally = new List<Tuple<bool, bool>>();

            for (int i = 0; i < count; i++)
            {
                bool[] arr = cmd.GetBoolArray();
                Tally.Add(Tuple.Create(arr[0], arr[1]));
            }

            cmd.SkipToNearestMultipleOf4();
        }
    }
}