using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Media
{
    public abstract class MediaPlayerMacroOpBase : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("MediaPlayerIndex", "mediaPlayer")]
        public MediaPlayerId Index { get; set; }
    }
}