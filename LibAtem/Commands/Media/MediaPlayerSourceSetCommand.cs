using System;
using LibAtem.Common;

namespace LibAtem.Commands.Media
{
    [CommandName("MPSS")]
    public class MediaPlayerSourceSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            SourceType = 1 << 0,
            StillIndex = 1 << 1,
            ClipIndex = 1 << 2,
        }

        public MaskFlags Mask { get; set; }
        public MediaPlayerId Index { get; set; }
        public MediaPlayerSource SourceType { get; set; }
        public uint ClipIndex { get; set; }
        public uint StillIndex { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((uint) Mask);
            cmd.AddUInt8((uint) Index);
            cmd.AddUInt8((uint) SourceType);
            cmd.AddUInt8(StillIndex);
            cmd.AddUInt8(ClipIndex);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            Index = (MediaPlayerId)cmd.GetUInt8();
            SourceType = (MediaPlayerSource)cmd.GetUInt8();
            StillIndex = cmd.GetUInt8();
            ClipIndex = cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}