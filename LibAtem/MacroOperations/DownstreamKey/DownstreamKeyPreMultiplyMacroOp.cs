using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyPreMultiply, 8)]
    public class DownstreamKeyPreMultiplyMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("PreMultiply")]
        public bool PreMultiply { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyGeneralSetCommand()
            {
                Mask = DownstreamKeyGeneralSetCommand.MaskFlags.PreMultiply,
                Index = KeyIndex,
                PreMultiply = PreMultiply,
            };
        }
    }
}