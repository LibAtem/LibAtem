using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyInvert, 8)]
    public class DownstreamKeyInvertMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Invert")]
        public bool Invert { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyGeneralSetCommand()
            {
                Mask = DownstreamKeyGeneralSetCommand.MaskFlags.Invert,
                Index = KeyIndex,
                Invert = Invert,
            };
        }
    }
}