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

            public Entry(VideoMode mode, VideoMode multiviewMode)
            {
                Mode = mode;
                MultiviewMode = multiviewMode;
            }

            #region IEquatable

            public bool Equals(Entry other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Mode == other.Mode && MultiviewMode == other.MultiviewMode;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Entry) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((int) Mode * 397) ^ (int) MultiviewMode;
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
                cmd.AddUInt8((uint) mode.Mode);
                cmd.Pad(5);
                cmd.AddUInt16(1 << (int) mode.MultiviewMode);
                cmd.Pad(4);
            }

            // cmd.AddByte("00-08".HexToByteArray());
            // cmd.Pad(2);
            // cmd.AddByte("00-00-00-00-00-00-00-80-00-00-00-00".HexToByteArray());
            // cmd.AddByte("01-02-00-00-00-00-00-40-00-00-00-00".HexToByteArray());
            // cmd.AddByte("02-00-00-00-00-00-00-80-00-00-00-00".HexToByteArray());
            // cmd.AddByte("03-EB-E2-C0-00-00-00-40-00-00-00-00".HexToByteArray());
            // cmd.AddByte("04-00-00-00-00-00-00-10-00-00-00-00".HexToByteArray());
            // cmd.AddByte("05-EB-E2-E0-00-00-00-20-00-00-00-00".HexToByteArray());
            // cmd.AddByte("06-0F-e2-80-00-00-01-00-00-00-00-00".HexToByteArray());
            // cmd.AddByte("07-FB-6B-20-00-00-00-80-00-00-00-00".HexToByteArray());
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            var count = cmd.GetUInt16();
            Modes = new List<Entry>((int) count);
            cmd.Skip(2);

            for (int i = 0; i < count; i++)
            {
                VideoMode mode = (VideoMode)cmd.GetUInt8();
                cmd.Skip(5);
                VideoMode mvMode = (VideoMode) Math.Floor(Math.Log(cmd.GetUInt16(), 2)); // TODO - check this is correct
                cmd.Skip(4);
                Modes.Add(new Entry(mode, mvMode));
            }
        }
    }
}