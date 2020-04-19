using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Common;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_VMC", CommandDirection.ToClient), NoCommandId]
    public class VideoMixerConfigCommand : ICommand
    {
        private static readonly VideoMode[] AllVideoModes;

        static VideoMixerConfigCommand()
        {
            AllVideoModes = Enum.GetValues(typeof(VideoMode)).OfType<VideoMode>().ToArray();
        }

        public class Entry : IEquatable<Entry>
        {
            public VideoMode Mode { get; }
            public List<VideoMode> MultiviewModes { get; }
            public List<VideoMode> DownConvertModes { get; }
            public bool RequiresReconfig { get; }

            public Entry(VideoMode mode, List<VideoMode> multiviewModes, List<VideoMode> downConvertModes, bool requiresReconfig)
            {
                Mode = mode;
                MultiviewModes = multiviewModes;
                DownConvertModes = downConvertModes;
                RequiresReconfig = requiresReconfig;
            }

            #region IEquatable

            public bool Equals(Entry other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Mode == other.Mode && MultiviewModes.SequenceEqual(other.MultiviewModes) /*&& SomeMode == other.SomeMode*/ && RequiresReconfig == other.RequiresReconfig;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Entry)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (int)Mode;
                    //hashCode = (hashCode * 397) ^ (int)MultiviewMode; // TODO - fix
                    //hashCode = (hashCode * 397) ^ (int)SomeMode;
                    hashCode = (hashCode * 397) ^ (RequiresReconfig ? 1 : 0);
                    return hashCode;
                }
            }

            #endregion IEquatable
        }

        public List<Entry> Modes { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Modes.Count);
            cmd.Pad(2);

            foreach (Entry mode in Modes)
            {
                cmd.AddUInt8((uint)mode.Mode);
                cmd.Pad(3);
                cmd.AddUInt32(ModesToUInt(mode.MultiviewModes));
                cmd.AddUInt32(ModesToUInt(mode.DownConvertModes));
                cmd.AddBoolArray(mode.RequiresReconfig);
            }
        }

        private uint ModesToUInt(IReadOnlyList<VideoMode> modes)
        {
            uint res = 0;
            foreach (VideoMode mode in modes)
            {
                res |= (1u << (int) mode);
            }
            return res;
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            var count = cmd.GetUInt16();
            Modes = new List<Entry>((int)count);
            cmd.Skip(2);

            for (int i = 0; i < count; i++)
            {
                VideoMode mode = (VideoMode)cmd.GetUInt8();
                cmd.Skip(3);
                List<VideoMode> multiviewModes = ReadVideoModeBitmask(cmd.GetUInt32());
                List<VideoMode> downConvertModes = ReadVideoModeBitmask(cmd.GetUInt32());
                bool requiresReconfig = cmd.GetBoolArray()[0]; // TODO this will be 8.0+ specific
                Modes.Add(new Entry(mode, multiviewModes, downConvertModes, requiresReconfig));
            }
        }

        private List<VideoMode> ReadVideoModeBitmask(uint rawVal)
        {
            var modes = new List<VideoMode>();
            foreach (VideoMode possibleMode in AllVideoModes)
            {
                if ((rawVal & (1 << (int)possibleMode)) != 0)
                    modes.Add(possibleMode);
            }

            return modes;
        }
    }
}