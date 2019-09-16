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

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourcePropertiesSetV8Command()
                {
                    Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtCutSource,
                    SSrcId = SuperSourceId.One,
                    ArtCutSource = Source
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtCutSource,
                    ArtCutSource = Source,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtCutInput, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2ArtCutInputMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourcePropertiesSetV8Command()
            {
                Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtCutSource,
                SSrcId = SSrcId,
                ArtCutSource = Source,
            };
        }
    }
}