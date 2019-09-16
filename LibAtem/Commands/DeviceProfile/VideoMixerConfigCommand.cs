using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_VMC"), NoCommandId]
    public class VideoMixerConfigCommand : ICommand
    {
        public class Entry : IEquatable<Entry>
        {
            public VideoMode Mode { get; }
            public VideoMode MultiviewMode { get; }
            public VideoMode SomeMode { get; }

            public Entry(VideoMode mode, VideoMode multiviewMode, VideoMode someMode)
            {
                Mode = mode;
                MultiviewMode = multiviewMode;
                SomeMode = someMode;
            }

            #region IEquatable

            public bool Equals(Entry other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Mode == other.Mode && MultiviewMode == other.MultiviewMode && SomeMode == other.SomeMode;
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
                    hashCode = (hashCode * 397) ^ (int)MultiviewMode;
                    hashCode = (hashCode * 397) ^ (int)SomeMode;
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
                cmd.AddUInt32((uint)(1 << (int)mode.MultiviewMode)); // TODO - should be mask
                cmd.AddUInt32((uint)(1 << (int)mode.SomeMode)); // TODO - should be mask
            }
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
                VideoMode mvMode = (VideoMode)Math.Floor(Math.Log(cmd.GetUInt32(), 2)); // TODO - should be mask
                VideoMode someMode = (VideoMode)Math.Floor(Math.Log(cmd.GetUInt32(), 2)); // TODO - should be mask
                cmd.Skip(1); // TODO is this 8.0+ specific?
                Modes.Add(new Entry(mode, mvMode, someMode));
            }
        }
    }
}