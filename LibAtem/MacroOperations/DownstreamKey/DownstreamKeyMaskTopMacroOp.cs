using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskTop, 8)]
    public class DownstreamKeyMaskTopMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, -9000, 9000)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.Top,
                Index = (DownstreamKeyId)KeyIndex,
                Top = Top,
            };
        }
    }
}