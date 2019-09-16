using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceArtFillInput, 8)]
    public class SuperSourceArtFillInputMacroOp : MacroOpBase
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
                    Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtFillSource,
                    SSrcId = SuperSourceId.One,
                    ArtFillSource = Source
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtFillSource,
                    ArtFillSource = Source,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtFillInput, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2ArtFillInputMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourcePropertiesSetV8Command()
            {
                Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtFillSource,
                SSrcId = SSrcId,
                ArtFillSource = Source,
            };
        }
    }
}