using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Media;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPSS", 8)]
    public class MediaPlayerSourceSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            SourceType = 1 << 0,
            StillIndex = 1 << 1,
            ClipIndex = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MediaPlayerId Index { get; set; }
        [Serialize(2), Enum8]
        public MediaPlayerSource SourceType { get; set; }
        [Serialize(3), UInt8]
        public uint ClipIndex { get; set; }
        [Serialize(4), UInt8]
        public uint StillIndex { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.SourceType))
            {
                if (SourceType == MediaPlayerSource.Clip)
                    yield return new MediaPlayerSourceClipMacroOp() { Index = Index };
                else
                    yield return new MediaPlayerSourceStillMacroOp() { Index = Index };
            }

            if (Mask.HasFlag(MaskFlags.StillIndex))
                yield return new MediaPlayerSourceStillIndexMacroOp() { Index = Index, MediaIndex = StillIndex };

            if (Mask.HasFlag(MaskFlags.ClipIndex))
                yield return new MediaPlayerSourceClipIndexMacroOp() { Index = Index, MediaIndex = ClipIndex };
        }
    }
}