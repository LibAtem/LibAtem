using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceShadowDirection, 8)]
    public class SuperSourceShadowDirectionMacroOp : MacroOpBase
    {
        [Serialize(4), UInt32D(65536, 0, 65536 * 360)]
        [MacroField("Direction")]
        public double Direction { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.LightSourceDirection,
                    SSrcId = SuperSourceId.One,
                    LightSourceDirection = Direction,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderLightSourceDirection,
                    BorderLightSourceDirection = Direction,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ShadowDirection, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2ShadowDirectionMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 65536 * 360)]
        [MacroField("Direction")]
        public double Direction { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.LightSourceDirection,
                SSrcId = SSrcId,
                LightSourceDirection = Direction,
            };
        }
    }
}