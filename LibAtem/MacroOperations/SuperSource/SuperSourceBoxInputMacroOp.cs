using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxInput, 8)]
    public class SuperSourceBoxInputMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBoxSetV8Command()
                {
                    Mask = SuperSourceBoxSetV8Command.MaskFlags.Source,
                    SSrcId = SuperSourceId.One,
                    BoxIndex = BoxIndex,
                    Source = Source,
                };
            }
            else
            {
                return new SuperSourceBoxSetCommand()
                {
                    Mask = SuperSourceBoxSetCommand.MaskFlags.Source,
                    BoxIndex = BoxIndex,
                    Source = Source,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxInput, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxInputMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetV8Command()
            {
                Mask = SuperSourceBoxSetV8Command.MaskFlags.Source,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                Source = Source,
            };
        }
    }
}