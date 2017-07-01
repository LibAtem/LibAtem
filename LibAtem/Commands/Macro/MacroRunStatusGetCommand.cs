using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MRPr", 4)]
    public class MacroRunStatusGetCommand : SerializableCommandBase
    {
        [Serializable(0), Bool(0)]
        public bool IsRunning { get; set; }
        [Serializable(0), Bool(1)]
        public bool IsWaiting { get; set; }
        [Serializable(1), Bool]
        public bool Loop { get; set; }
        [Serializable(2), UInt16]
        public uint Index { get; set; }
    }
}