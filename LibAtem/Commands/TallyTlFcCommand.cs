using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.Commands
{
    [CommandName("TlFc", CommandDirection.ToClient), NoCommandId] // TODO not sure what this command is for. Is new since 7.0
    public class TallyTlFcCommand : ICommand
    {
        public Dictionary<VideoSource, uint> Tally { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Tally.Count);
            foreach (KeyValuePair<VideoSource, uint> t in Tally)
            {
                cmd.AddUInt16((uint) t.Key);
                cmd.AddUInt8(t.Value);
            }
            cmd.PadToNearestMultipleOf4();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Tally = new Dictionary<VideoSource, uint>();

            uint count = cmd.GetUInt16();
            for (int i = 0; i < count; i++)
            {
                VideoSource k = (VideoSource) cmd.GetUInt16();
                uint v = cmd.GetUInt8();
                Tally[k] = v;
            }
            cmd.SkipToNearestMultipleOf4();
        }
    }
}