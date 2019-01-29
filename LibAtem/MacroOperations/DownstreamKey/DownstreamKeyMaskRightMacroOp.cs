using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskRight, 12)]
    public class DownstreamKeyMaskRightMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(8), Int32D(65535, -16 * 65535, 16 * 65535)]
        [MacroField("Right")]
        public double Right { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskRight,
                Index = KeyIndex,
                MaskRight = Right,
            };
        }
    }
}