using LibAtem.Commands;
using LibAtem.Commands.Settings;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.InputVideoPort, 8)]
    public class InputVideoPortMacroOp : MacroOpBase
    {
        [Serialize(4), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        [Serialize(6), Enum16]
        [MacroField("VideoPort")]
        public MacroPortType Port { get; set; }

        public override ICommand ToCommand()
        {
            return new InputPropertiesSetCommand
            {
                Mask = InputPropertiesSetCommand.MaskFlags.ExternalPortType,
                Id = Source,
                ExternalPortType = Port.ToExternalPortType(),
            };
        }
    }
}