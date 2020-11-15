using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Macro
{
    [CommandName("MPrp", CommandDirection.ToClient)]
    public class MacroPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Index { get; set; }
        [Serialize(2), Bool]
        public bool IsUsed { get; set; }
        [Serialize(3), Bool]
        public bool HasUnsupportedOps { get; set; }
        [Serialize(4), StringLength]
        public string Name { get; set; }
        [Serialize(6), StringLength]
        public string Description { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.SetString(8, Name);
            cmd.SetString(8 + Name?.Length ?? 0, Description);
        }

        public override void Deserialize(ParsedByteArray cmd)
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