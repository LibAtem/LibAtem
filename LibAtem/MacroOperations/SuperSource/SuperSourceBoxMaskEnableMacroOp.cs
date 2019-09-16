using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskEnable, 8)]
    public class SuperSourceBoxMaskEnableMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.Cropped,
                SSrcId = SuperSourceId.One,
                BoxIndex = BoxIndex,
                Cropped = Enable,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxMaskEnable, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxMaskEnableMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.Cropped,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                Cropped = Enable,
            };
        }
    }
}