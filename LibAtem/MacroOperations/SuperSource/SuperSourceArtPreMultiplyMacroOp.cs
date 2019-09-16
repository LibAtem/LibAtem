using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceArtPreMultiply, 8)]
    public class SuperSourceArtPreMultiplyMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("PreMultiply")]
        public bool PreMultiply { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourcePropertiesSetV8Command()
                {
                    Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtPreMultiplied,
                    SSrcId = SuperSourceId.One,
                    ArtPreMultiplied = PreMultiply,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtPreMultiplied,
                    ArtPreMultiplied = PreMultiply,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtPreMultiply, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2ArtPreMultiplyMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("PreMultiply")]
        public bool PreMultiply { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourcePropertiesSetV8Command()
            {
                Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtPreMultiplied,
                SSrcId = SSrcId,
                ArtPreMultiplied = PreMultiply,
            };
        }
    }
}