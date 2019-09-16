using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceArtGain, 8)]
    public class SuperSourceArtGainMacroOp : MacroOpBase
    {
        [Serialize(4), UInt16D(65536, 0, 65536)]
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtGain,
                SSrcId = SuperSourceId.One,
                ArtGain = Gain,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtGain, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2ArtGainMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt16D(65536, 0, 65536)]
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtGain,
                SSrcId = SSrcId,
                ArtGain = Gain,
            };
        }
    }
}