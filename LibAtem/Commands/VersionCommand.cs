namespace LibAtem.Commands
{
    [CommandName("_ver")]
    public class VersionCommand : ICommand
    {
        public VersionCommand()
        {
            ApiMajor = Version.ApiMajor;
            ApiMinor = Version.ApiMinor;
        }

        public uint ApiMajor { get; private set; }
        public uint ApiMinor { get; private set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Version.ApiMajor);
            cmd.AddUInt16(Version.ApiMinor);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            ApiMajor = cmd.GetUInt16();
            ApiMinor = cmd.GetUInt16();
        }
    }
}