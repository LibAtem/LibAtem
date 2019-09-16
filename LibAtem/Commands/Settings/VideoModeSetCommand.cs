using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Settings;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CVdM", 4), NoCommandId]
    public class VideoModeSetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public VideoMode VideoMode { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new VideoModeMacroOp { VideoMode = VideoMode };
        }
    }
}