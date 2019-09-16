using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxYPosition, 12)]
    public class SuperSourceBoxYPositionMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, -48 * 65536, 48 * 65536)]
        [MacroField("PositionY", "yPosition")]
        public double PositionY { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.PositionY,
                SSrcId = SuperSourceId.One,
                BoxIndex = BoxIndex,
                PositionY = PositionY,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxYPosition, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxYPositionMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, -48 * 65536, 48 * 65536)]
        [MacroField("PositionY", "yPosition")]
        public double PositionY { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.PositionY,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                PositionY = PositionY,
            };
        }
    }
}