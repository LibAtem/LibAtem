using System;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Macro
{
    [CommandName("CMPr")]
    public class MacroPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Name        = 1 << 0,
            Description = 1 << 1,
        }
        
        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), UInt16]
        public uint Index { get; set; }
        [Serialize(4), StringLength]
        public string Name { get; set; }
        [Serialize(6), StringLength]
        public string Description { get; set; }

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.SetString(8, Name);
            cmd.SetString(8 + Name.Length, Description);
        }

        public override void Deserialize(ParsedCommand cmd)
        {
            base.Deserialize(cmd);

            Name = cmd.GetString(8, Name.Length);
            Description = cmd.GetString(8 + Name.Length, Description.Length);
        }

        protected override int GetLength()
        {
            return MathExt.NextMultipleOf4(8 + (Name?.Length ?? 0) + (Description?.Length ?? 0));
        }
    }
}