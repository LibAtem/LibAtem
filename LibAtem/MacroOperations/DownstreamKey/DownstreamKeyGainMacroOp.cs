using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyGain, 12)]
    public class DownstreamKeyGainMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyGeneralSetCommand()
            {
                Mask = DownstreamKeyGeneralSetCommand.MaskFlags.Gain,
                Index = KeyIndex,
                Gain = Gain,
            };
        }
    }
}