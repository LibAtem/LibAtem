using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskBottom, 12)]
    public class DownstreamKeyMaskBottomMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(8), Int32D(65535, -9 * 65535, 9 * 65535)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskBottom,
                Index = KeyIndex,
                MaskBottom = Bottom,
            };
        }
    }
}