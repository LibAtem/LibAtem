using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBoxMaskRight, 12)]
    public class SuperSourceBoxMaskRightMacroOp : SuperSourceBoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 32 * 65536)]
        [MacroField("Right")]
        public double Right { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBoxSetV8Command()
                {
                    Mask = SuperSourceBoxSetV8Command.MaskFlags.CropRight,
                    SSrcId = SuperSourceId.One,
                    BoxIndex = BoxIndex,
                    CropRight = Right,
                };
            }
            else
            {
                return new SuperSourceBoxSetCommand()
                {
                    Mask = SuperSourceBoxSetCommand.MaskFlags.CropRight,
                    BoxIndex = BoxIndex,
                    CropRight = Right,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxMaskRight, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxMaskRightMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, 0, 32 * 65536)]
        [MacroField("Right")]
        public double Right { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetV8Command()
            {
                Mask = SuperSourceBoxSetV8Command.MaskFlags.CropRight,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                CropRight = Right,
            };
        }
    }
}