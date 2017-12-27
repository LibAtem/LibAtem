using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMasterOutGain, 8)]
    public class AudioMixerMasterOutGainMacroOp : MacroOpBase
    {
        [Serialize(4), UInt16Tol(5)]
        [MacroField("AudioGain", "gain")]
        public uint RawGain
        {
            get => DecibelsAttribute.DecibelToUInt(Gain);
            set => Gain = DecibelsAttribute.UIntToDecibel((uint)value);
        }

        [NoSerialize]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerMasterSetCommand
            {
                Mask = AudioMixerMasterSetCommand.MaskFlags.Gain,
                Gain = Gain,
            };
        }
    }
}