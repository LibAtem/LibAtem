using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceArtClip, 8)]
    public class SuperSourceArtClipMacroOp : MacroOpBase
    {
        [Serialize(4), UInt16D(65536, 0, 65536)]
        [MacroField("Clip")]
        public double Clip { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtClip,
                SSrcId = SuperSourceId.One,
                ArtClip = Clip,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtClip, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2ArtClipMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt16D(65536, 0, 65536)]
        [MacroField("Clip")]
        public double Clip { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourcePropertiesSetV8Command()
            {
                Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtClip,
                SSrcId = SSrcId,
                ArtClip = Clip,
            };
        }
    }
}