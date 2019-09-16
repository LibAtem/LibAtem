using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskBottom, 12)]
    public class SuperSourceBoxMaskBottomMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 18 * 65536)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBoxSetV8Command()
                {
                    Mask = SuperSourceBoxSetV8Command.MaskFlags.CropBottom,
                    SSrcId = SuperSourceId.One,
                    BoxIndex = BoxIndex,
                    CropBottom = Bottom,
                };
            }
            else
            {
                return new SuperSourceBoxSetCommand()
                {
                    Mask = SuperSourceBoxSetCommand.MaskFlags.CropBottom,
                    BoxIndex = BoxIndex,
                    CropBottom = Bottom,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxMaskBottom, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxMaskBottomMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 18 * 65536)]
        [MacroField("Bottom")]
        public double Bottom { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetV8Command()
            {
                Mask = SuperSourceBoxSetV8Command.MaskFlags.CropBottom,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                CropBottom = Bottom,
            };
        }
    }
}