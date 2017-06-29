using System;
using LibAtem.Common;

namespace LibAtem.Commands.Settings
{
    [CommandName("CInL")]
    public class InputPropertiesSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            LongName = 1 << 0,
            ShortName = 1 << 1,
            ExternalPortType = 1 << 2,
        }

        public MaskFlags Mask { get; set; }
        public VideoSource Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public ExternalPortType ExternalPortType { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.Pad();
            cmd.AddUInt16((int) Id);
            cmd.AddString(20, LongName);
            cmd.AddString(4, ShortName);
            cmd.AddUInt16((int) ExternalPortType);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            Id = (VideoSource) cmd.GetUInt16();
            LongName = cmd.GetString(20);
            ShortName = cmd.GetString(4);
            ExternalPortType = (ExternalPortType) cmd.GetUInt16();
            cmd.Skip(2);
        }
    }
}