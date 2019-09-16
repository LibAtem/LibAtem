using LibAtem.Commands;
using LibAtem.Commands.Settings;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Settings
{
    [MacroOperation(MacroOperationType.DownConvertMode, 8)]
    public class DownConvertModeMacroOp : MacroOpBase
    {
        [Serialize(4), Enum16]
        [MacroField("DownConvertMode")]
        public DownConvertMode DownConvertMode { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new DownConvertModeSetCommand()
            {
                DownConvertMode = DownConvertMode,
            };
        }
    }
}