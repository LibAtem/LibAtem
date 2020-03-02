using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderEnable, 8)]
    public class SuperSourceBorderEnableMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.Enabled,
                    SSrcId = SuperSourceId.One,
                    Enabled = Enable,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderEnabled,
                    BorderEnabled = Enable,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderEnable, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2BorderEnableMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.Enabled,
                SSrcId = SSrcId,
                Enabled = Enable,
            };
        }
    }
}