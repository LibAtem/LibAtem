using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSCs", CommandDirection.Both, 4)]
    public class SuperSourceCascadeCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool Cascade { get; set; }
    }
}