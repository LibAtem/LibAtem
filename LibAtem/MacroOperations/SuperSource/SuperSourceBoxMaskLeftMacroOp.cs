using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskLeft, 12)]
    public class SuperSourceBoxMaskLeftMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 32 * 65536)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropLeft,
                SSrcId = SuperSourceId.One,
                BoxIndex = BoxIndex,
                CropLeft = Left,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxMaskLeft, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxMaskLeftMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 32 * 65536)]
        [MacroField("Left")]
        public double Left { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.CropLeft,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                CropLeft = Left,
            };
        }
    }
}