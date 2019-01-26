using System.Collections.Generic;
using System.Linq;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("InPr")]
    public class InputPropertiesGetCommand : ICommand
    {
        [CommandId]
        [Serialize(0), Enum16]
        public VideoSource Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public bool IsExternal { get; set; }
        public ExternalPortTypeFlags AvailableExternalPorts { get; set; }
        public ExternalPortType ExternalPortType { get; set; }
        public InternalPortType InternalPortType { get; set; }
        public SourceAvailability SourceAvailability { get; set; }
        public MeAvailability MeAvailability { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16((int)Id);
            cmd.AddString(20, LongName);
            cmd.AddString(4, ShortName);
            cmd.AddByte(0x00); // Xa
            cmd.Pad(); // ??
            cmd.AddByte((byte)(IsExternal ? 0x00 : 0x01)); // Xb

            cmd.AddUInt8((uint)AvailableExternalPorts);

            cmd.AddByte((byte)(IsExternal ? 0x00 : 0x01)); // Xd
            cmd.AddUInt8((int)ExternalPortType); // Xe
            cmd.AddUInt8((int)InternalPortType);
            cmd.Pad(); //Xg ??
            cmd.AddUInt8((uint)SourceAvailability); // Xh
            cmd.AddUInt8((uint)MeAvailability); // Xi
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Id = (VideoSource) cmd.GetUInt16();
            LongName = cmd.GetString(20);
            ShortName = cmd.GetString(4);
            cmd.Skip(2);
            IsExternal = cmd.GetUInt8() == 0;

            AvailableExternalPorts = (ExternalPortTypeFlags)cmd.GetUInt8();
            if (!IsExternal) AvailableExternalPorts = ExternalPortTypeFlags.Internal;

            cmd.Skip(); // Xd
            ExternalPortType = (ExternalPortType) cmd.GetUInt8();
            InternalPortType = (InternalPortType) cmd.GetUInt8();
            cmd.Skip();
            SourceAvailability = (SourceAvailability) cmd.GetUInt8();
            MeAvailability = (MeAvailability) cmd.GetUInt8();
        }
    }
}