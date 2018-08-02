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

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderBevel,
                BorderBevel = Bevel,
            };
        }
    }
}