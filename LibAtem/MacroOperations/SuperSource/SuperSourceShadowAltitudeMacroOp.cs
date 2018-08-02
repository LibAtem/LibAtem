using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceShadowAltitude, 8)]
    public class SuperSourceShadowAltitudeMacroOp : MacroOpBase
    {
        [Serialize(4), UInt16Range(10, 100)]
        [MacroField("Altitude")]
        public uint Altitude { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderLightSourceAltitude,
                BorderLightSourceAltitude = Altitude,
            };
        }
    }
}