using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderHue, 8)]
    public class SuperSourceBorderHueMacroOp : MacroOpBase
    {
        [Serialize(4), UInt32D(65536, 0, 65536 * 360)]
        [MacroField("Hue")]
        public double Hue { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.Hue,
                    SSrcId = SuperSourceId.One,
                    Hue = Hue,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderHue,
                    BorderHue = Hue,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderHue, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BorderHueMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 65536 * 360)]
        [MacroField("Hue")]
        public double Hue { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.Hue,
                SSrcId = SSrcId,
                Hue = Hue,
            };
        }
    }
}