using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskLeft, 8)]
    public class DownstreamKeyMaskLeftMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, -16000, 16000)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.Left,
                Index = (DownstreamKeyId)KeyIndex,
                Left = Left,
            };
        }
    }
}