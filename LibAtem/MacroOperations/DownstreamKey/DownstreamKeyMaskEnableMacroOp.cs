using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyMaskEnable, 8)]
    public class DownstreamKeyMaskEnableMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyMaskSetCommand()
            {
                Mask = DownstreamKeyMaskSetCommand.MaskFlags.Enabled,
                Index = (DownstreamKeyId)KeyIndex,
                Enabled = Enable,
            };
        }
    }
}