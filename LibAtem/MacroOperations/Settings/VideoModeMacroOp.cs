using LibAtem.Commands;
using LibAtem.Commands.Settings;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Settings
{
    [MacroOperation(MacroOperationType.VideoMode, 8)]
    public class VideoModeMacroOp : MacroOpBase
    {
        [Serialize(4), Enum16]
        [MacroField("VideoMode")]
        public VideoMode VideoMode { get; set; }

        public override ICommand ToCommand()
        {
            return new VideoModeSetCommand
            {
                VideoMode = VideoMode,
            };
        }
    }
}