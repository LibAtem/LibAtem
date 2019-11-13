using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyClip, 12)]
    public class DownstreamKeyClipMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Clip")]
        public double Clip { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownstreamKeyGeneralSetCommand()
            {
                Mask = DownstreamKeyGeneralSetCommand.MaskFlags.Clip,
                Index = KeyIndex,
                Clip = Clip,
            };
        }
    }
}