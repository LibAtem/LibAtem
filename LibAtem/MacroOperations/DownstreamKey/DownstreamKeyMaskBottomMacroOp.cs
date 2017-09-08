using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskBottom, 8)]
    public class DownstreamKeyMaskBottomMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, -9000, 9000)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.Bottom,
                Index = (DownstreamKeyId)KeyIndex,
                Bottom = Bottom,
            };
        }
    }
}