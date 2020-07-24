using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CInL", CommandDirection.ToServer, 32)]
    public class InputPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            LongName = 1 << 0,
            ShortName = 1 << 1,
            ExternalPortType = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public VideoSource Id { get; set; }
        [Serialize(4), String(20)]
        public string LongName { get; set; }
        [Serialize(24), String(4)]
        public string ShortName { get; set; }
        [Serialize(28), Enum16]
        public VideoPortType ExternalPortType { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.LongName))
                yield return null;
            if (Mask.HasFlag(MaskFlags.ShortName))
                yield return null;
            //if (Mask.HasFlag(MaskFlags.ExternalPortType))
            //yield return new InputVideoPortMacroOp {Source = Id, Port = ExternalPortType.ToMacroPortType()};
        }
    }
}