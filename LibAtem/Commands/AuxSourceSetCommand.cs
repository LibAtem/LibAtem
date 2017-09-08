using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands
{
    [CommandName("CAuS", 4)]
    public class AuxSourceSetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Mask => 1;

        [CommandId]
        [Serialize(1), UInt8Range(0, 5)]
        public uint Id { get; set; }
        
        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            yield return new AuxiliaryInputMacroOp()
            {
                Index = Id,
                Source = Source,
            };
        }
    }
}