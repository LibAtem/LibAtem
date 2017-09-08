using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderEnable, 12)]
    public class SuperSourceBorderEnableMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderEnabled,
                BorderEnabled = Enable,
            };
        }
    }
}