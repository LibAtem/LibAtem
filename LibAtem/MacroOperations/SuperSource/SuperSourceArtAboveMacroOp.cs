using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{

    [MacroOperation(MacroOperationType.SuperSourceArtAbove, 8)]
    public class SuperSourceArtAboveMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("SuperSourceArtAbove", "artAbove")]
        public bool ArtAbove { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourcePropertiesSetV8Command()
                {
                    Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtOption,
                    SSrcId = SuperSourceId.One,
                    ArtOption = ArtAbove ? SuperSourceArtOption.Foreground : SuperSourceArtOption.Background,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtOption,
                    SSrcId = SuperSourceId.One,
                    ArtOption = ArtAbove ? SuperSourceArtOption.Foreground : SuperSourceArtOption.Background,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtAbove, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2ArtAboveMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("SuperSourceArtAbove", "artAbove")]
        public bool ArtAbove { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourcePropertiesSetV8Command()
            {
                Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtOption,
                SSrcId = SsrcId,
                ArtOption = ArtAbove ? SuperSourceArtOption.Foreground : SuperSourceArtOption.Background,
            };
        }
    }
}