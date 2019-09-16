using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxSize, 12)]
    public class SuperSourceBoxSizeMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, (int)(0.07 * 65536), 65536)]
        [MacroField("Size")]
        public double Size { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.Size,
                SSrcId = SuperSourceId.One,
                BoxIndex = BoxIndex,
                Size = Size,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxSize, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxSizeMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, (int)(0.07 * 65536), 65536)]
        [MacroField("Size")]
        public double Size { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.Size,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                Size = Size,
            };
        }
    }
}