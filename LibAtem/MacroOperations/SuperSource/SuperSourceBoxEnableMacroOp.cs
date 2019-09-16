using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxEnable, 8)]
    public class SuperSourceBoxEnableMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.Enabled,
                SSrcId = SuperSourceId.One,
                BoxIndex = BoxIndex,
                Enabled = Enable,
            };
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxEnable, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxEnableMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetCommand()
            {
                Mask = SuperSourceBoxSetCommand.MaskFlags.Enabled,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                Enabled = Enable,
            };
        }
    }
}