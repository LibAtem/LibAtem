using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderBevel, 8)]
    public class SuperSourceBorderBevelMacroOp : MacroOpBase
    {
        [Serialize(4), Enum8]
        [MacroField("Bevel")]
        public BorderBevel Bevel { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.Bevel,
                    SSrcId = SuperSourceId.One,
                    Bevel = Bevel,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderBevel,
                    BorderBevel = Bevel,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderBevel, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2BorderBevelMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("Bevel")]
        public BorderBevel Bevel { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.Bevel,
                SSrcId = SSrcId,
                Bevel = Bevel,
            };
        }
    }
}