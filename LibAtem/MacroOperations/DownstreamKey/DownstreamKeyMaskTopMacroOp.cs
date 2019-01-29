using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskTop, 12)]
    public class DownstreamKeyMaskTopMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(8), Int32D(65535, -9 * 65535, 9 * 65535)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskTop,
                Index = KeyIndex,
                MaskTop = Top,
            };
        }
    }
}