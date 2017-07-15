using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MRPr", 4), NoCommandId]
    public class MacroRunStatusGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool(0)]
        public bool IsRunning { get; set; }
        [Serialize(0), Bool(1)]
        public bool IsWaiting { get; set; }
        [Serialize(1), Bool]
        public bool Loop { get; set; }
        [Serialize(2), UInt16]
        public uint Index { get; set; }
    }
}