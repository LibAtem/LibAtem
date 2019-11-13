using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskLeft, 12)]
    public class DownstreamKeyMaskLeftMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(8), Int32D(65535, -16 * 65535, 16 * 65535)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskLeft,
                Index = KeyIndex,
                MaskLeft = Left,
            };
        }
    }
}