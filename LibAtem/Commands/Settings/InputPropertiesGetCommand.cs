using System.Collections.Generic;
using System.Linq;
using LibAtem.Common;

namespace LibAtem.Commands.Settings
{
    [CommandName("InPr")]
    public class InputPropertiesGetCommand : ICommand
    {
        public VideoSource Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public bool IsExternal { get; set; }
        public List<ExternalPortType> ExternalPorts { get; set; }
        public ExternalPortType ExternalPortType { get; set; }
        public InternalPortType InternalPortType { get; set; }
        public SourceAvailability SourceAvailability { get; set; }
        public MeAvailability MeAvailability { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16((int)Id);
            cmd.AddString(20, LongName);
            cmd.AddString(4, ShortName);
            cmd.AddByte(0x00); // Xa
            cmd.Pad(); // ??
            cmd.AddByte((byte)(IsExternal ? 0x00 : 0x01)); // Xb

            if (ExternalPorts == null)
                cmd.AddBoolArray(false); // Is an external type, so no port options
            else
                cmd.AddBoolArray(ExternalPorts.Contains(ExternalPortType.SDI),
                    ExternalPorts.Contains(ExternalPortType.HDMI),
                    ExternalPorts.Contains(ExternalPortType.Component),
                    ExternalPorts.Contains(ExternalPortType.Composite),
                    ExternalPorts.Contains(ExternalPortType.SVideo));

            cmd.AddByte((byte)(IsExternal ? 0x00 : 0x01)); // Xd
            cmd.AddUInt8((int)ExternalPortType); // Xe
            cmd.AddUInt8((int)InternalPortType);
            cmd.Pad(); //Xg ??
            cmd.AddUInt8((uint)SourceAvailability); // Xh
            cmd.AddUInt8((uint)MeAvailability); // Xi
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Id = (VideoSource) cmd.GetUInt16();
            LongName = cmd.GetString(20);
            ShortName = cmd.GetString(4);
            cmd.Skip(2);
            IsExternal = cmd.GetUInt8() == 0;

            // TODO - one of the unknowns will be the currently selected ExternalPortType

            bool[] portBools = cmd.GetBoolArray();
            var ports = new List<ExternalPortType>();
            if (portBools[0])
                ports.Add(ExternalPortType.SDI);
            if (portBools[1])
                ports.Add(ExternalPortType.HDMI);
            if (portBools[2])
                ports.Add(ExternalPortType.Component);
            if (portBools[3])
                ports.Add(ExternalPortType.Composite);
            if (portBools[4])
                ports.Add(ExternalPortType.SVideo);
            ExternalPorts = ports.Any() ? ports : null;

            cmd.Skip(); // Xd
            ExternalPortType = (ExternalPortType) cmd.GetUInt8();
            InternalPortType = (InternalPortType) cmd.GetUInt8();
            cmd.Skip();
            SourceAvailability = (SourceAvailability) cmd.GetUInt8();
            MeAvailability = (MeAvailability) cmd.GetUInt8();
        }
    }
}