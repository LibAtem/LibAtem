using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerInputBalance, 12)]
    public class AudioMixerInputBalanceMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("Input")]
        public AudioSource Index { get; set; }

        [Serialize(8), Int32D(65535, -50 * 65535, 50 * 65535)]
        [MacroField("Balance")]
        public double Balance { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new AudioMixerInputSetCommand()
            {
                Mask = AudioMixerInputSetCommand.MaskFlags.Balance,
                Index = Index,
                Balance = Balance,
            };
        }
    }
}