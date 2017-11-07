using LibAtem.Commands;
using LibAtem.Commands.Settings;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.SetSerialPortFunction, 8)]
    public class SetSerialPortFunctionMacroOp : MacroOpBase
    {
        [Serialize(4), UInt8Range(0, 0)]
        [MacroField("ExternalSerialPortIndex")]
        public uint ExternalSerialPortIndex { get; set; }

        [Serialize(5), Enum8]
        [MacroField("Function")]
        public SerialMode SerialMode { get; set; }

        public override ICommand ToCommand()
        {
            return new SerialPortModeCommand()
            {
                SerialMode = SerialMode,
            };
        }
    }
}