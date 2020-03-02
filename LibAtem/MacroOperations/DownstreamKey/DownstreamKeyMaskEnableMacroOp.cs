using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskEnable, 8)]
    public class DownstreamKeyMaskEnableMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskEnabled,
                Index = KeyIndex,
                MaskEnabled = Enable,
            };
        }
    }
}