using System.Collections.Generic;

namespace LibAtem.Commands.Media
{
    [CommandName("MPSp"), NoCommandId]
    public class MediaPoolSettingsGetCommand : ICommand
    {
        public List<uint> MaxFrames { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            foreach (uint fr in MaxFrames)
                cmd.AddUInt16(fr);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MaxFrames = new List<uint>();

            for (int i = 0; i < cmd.BodyLength; i += 2)
                MaxFrames.Add(cmd.GetUInt16());
        }
    }
}