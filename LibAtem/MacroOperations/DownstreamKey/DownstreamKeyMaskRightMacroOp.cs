using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskRight, 8)]
    public class DownstreamKeyMaskRightMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), Int16D(1000, -16000, 16000)]
        [MacroField("Right")]
        public double Right { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.Right,
                Index = (DownstreamKeyId)KeyIndex,
                Right = Right,
            };
        }
    }
}