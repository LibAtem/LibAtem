using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMTl"), NoCommandId]
    public class AudioMixerTallyCommand : ICommand
    {
        public Dictionary<AudioSource, bool> Inputs { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Inputs.Count);

            foreach (KeyValuePair<AudioSource, bool> src in Inputs)
            {
                cmd.AddUInt16((int) src.Key);
                cmd.AddBoolArray(src.Value);
            }
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Inputs = new Dictionary<AudioSource, bool>();

            uint count = cmd.GetUInt16();
            for (int i = 0; i < count; i++)
            Inputs.Add((AudioSource) cmd.GetUInt16(), cmd.GetBoolArray()[0]);
        }
    }
}