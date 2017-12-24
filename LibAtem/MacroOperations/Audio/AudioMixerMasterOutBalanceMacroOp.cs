using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMasterOutBalance, 8)]
    public class AudioMixerMasterOutBalanceMacroOp : MacroOpBase
    {
        [Serialize(4), Int32D(65535, -50 * 65535, 50 * 65535)]
        [MacroField("Balance")]
        public double Balance { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerMasterSetCommand
            {
                Mask = AudioMixerMasterSetCommand.MaskFlags.Balance,
                Balance = Balance,
            };
        }
    }
}