using LibAtem.Common;

namespace LibAtem.Commands.Media
{
    [CommandName("MPfe")]
    public class MediaPoolFileCommand : ICommand
    {
        public MediaPoolFileType Type { get; set; }
        public uint Index { get; set; }
        public bool IsUsed { get; set; }
        public string Name { get; set; }
        public string FileHash { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Type);
            cmd.Pad();
            cmd.AddUInt8(Index);
            cmd.AddBoolArray(IsUsed);
            cmd.AddString(16, FileHash);
            cmd.Pad(2);
            cmd.AddUInt8(Name.Length);
            cmd.AddString(Name);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Type = (MediaPoolFileType) cmd.GetUInt8();
            cmd.Skip();
            Index = cmd.GetUInt8();
            IsUsed = cmd.GetBoolArray()[0];
            FileHash = cmd.GetString(16);
            cmd.Skip(2);
            Name = cmd.GetString(cmd.GetUInt8());
        }
    }
}