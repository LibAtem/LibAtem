using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderBevelSoftness, 8)]
    public class SuperSourceBorderBevelSoftnessMacroOp : MacroOpBase
    {
        [Serialize(4), UInt8Range(0, 100)]
        [MacroField("BevelSoftness")]
        public uint BevelSoftness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.BevelSoftness,
                    SSrcId = SuperSourceId.One,
                    BevelSoftness = BevelSoftness,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderBevelSoftness,
                    BorderBevelSoftness = BevelSoftness,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderBevelSoftness, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2BorderBevelSoftnessMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("BevelSoftness")]
        public uint BevelSoftness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BevelSoftness,
                SSrcId = SSrcId,
                BevelSoftness = BevelSoftness,
            };
        }
    }
}