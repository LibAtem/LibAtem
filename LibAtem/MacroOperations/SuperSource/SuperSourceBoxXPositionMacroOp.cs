using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxXPosition, 12)]
    public class SuperSourceBoxXPositionMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, -48 * 65536, 48 * 65536)]
        [MacroField("PositionX", "xPosition")]
        public double PositionX { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBoxSetV8Command()
                {
                    Mask = SuperSourceBoxSetV8Command.MaskFlags.PositionX,
                    SSrcId = SuperSourceId.One,
                    BoxIndex = BoxIndex,
                    PositionX = PositionX,
                };
            }
            else
            {
                return new SuperSourceBoxSetCommand()
                {
                    Mask = SuperSourceBoxSetCommand.MaskFlags.PositionX,
                    BoxIndex = BoxIndex,
                    PositionX = PositionX,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxXPosition, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxXPositionMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, -48 * 65536, 48 * 65536)]
        [MacroField("PositionX", "xPosition")]
        public double PositionX { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetV8Command()
            {
                Mask = SuperSourceBoxSetV8Command.MaskFlags.PositionX,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                PositionX = PositionX,
            };
        }
    }
}