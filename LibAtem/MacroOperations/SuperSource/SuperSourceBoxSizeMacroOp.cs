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

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBoxSetV8Command()
                {
                    Mask = SuperSourceBoxSetV8Command.MaskFlags.Size,
                    SSrcId = SuperSourceId.One,
                    BoxIndex = BoxIndex,
                    Size = Size,
                };
            }
            else
            {
                return new SuperSourceBoxSetCommand()
                {
                    Mask = SuperSourceBoxSetCommand.MaskFlags.Size,
                    BoxIndex = BoxIndex,
                    Size = Size,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BoxSize, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BoxSizeMacroOp : SuperSourceV2BoxMacroOpBase
    {
        [Serialize(8), Int32D(65536, (int)(0.07 * 65536), 65536)]
        [MacroField("Size")]
        public double Size { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBoxSetV8Command()
            {
                Mask = SuperSourceBoxSetV8Command.MaskFlags.Size,
                SSrcId = SSrcId,
                BoxIndex = BoxIndex,
                Size = Size,
            };
        }
    }
}