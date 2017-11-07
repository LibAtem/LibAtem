using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Settings;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMvI", 4)]
    public class MultiviewWindowInputSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8Range(0, 9)]
        public uint WindowIndex { get; set; }
        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            yield return new MultiViewWindowInputMacroOp
            {
                MultiViewIndex = MultiviewIndex,
                WindowIndex = WindowIndex,
                Source = Source,
            };
        }
    }
}