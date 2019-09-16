using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskTop, 12)]
    public class SuperSourceBoxMaskTopMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 18 * 65536)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropTop,
                SSrcId = SuperSourceId.One,
                BoxIndex = BoxIndex,
                CropTop = Top,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxMaskTop, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxMaskTopMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 18 * 65536)]
        [MacroField("Top")]
        public double Top { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropTop,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                CropTop = Top,
            };
        }
    }
}