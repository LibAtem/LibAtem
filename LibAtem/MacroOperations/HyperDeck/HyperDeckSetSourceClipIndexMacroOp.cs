using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.HyperDeck
{
    [MacroOperation(MacroOperationType.HyperDeckSetSourceClipIndex, 8)]
    public class HyperDeckSetSourceClipIndexMacroOp : HyperDeckMacroOpBase
    {
        [Serialize(6), UInt16]
        [MacroField("HyperDeckClipIndex", "clipIndex")]
        public uint ClipIndex { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return null;// TODO
        }
    }
}