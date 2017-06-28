using LibAtem.Common;

namespace LibAtem.Commands.Settings
{
    [CommandName("V3sl")]
    public class SDI3GLeveloutputGetCommand : ICommand
    {
        public SDI3GOutputLevel SDI3GOutputLevel { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)SDI3GOutputLevel);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            SDI3GOutputLevel = (SDI3GOutputLevel)cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}