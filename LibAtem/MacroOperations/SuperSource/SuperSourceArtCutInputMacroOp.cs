using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceArtCutInput, 8)]
    public class SuperSourceArtCutInputMacroOp : MacroOpBase
    {
        [Serialize(4), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtCutSource,
                SSrcId = SuperSourceId.One,
                ArtCutSource = Source,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtCutInput, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2ArtCutInputMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtCutSource,
                SSrcId = SSrcId,
                ArtCutSource = Source,
            };
        }
    }
}