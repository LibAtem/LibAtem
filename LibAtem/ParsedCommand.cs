using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibAtem.Util;

namespace LibAtem
{
    public class ParsedByteArray
    {
        public byte[] Body { get; }
        public bool ReverseBytes { get; }

        private uint pos;

        public ParsedByteArray(byte[] body, bool reverseBytes)
        {
            ReverseBytes = reverseBytes;
            Body = body;

            pos = 0;
        }

        public bool HasFinished => pos >= BodyLength;

        public int BodyLength => Body.Length;
        
        private byte[] ReverseBytesIfNeeded(IEnumerable<byte> data)
        {
            return ReverseBytes ? data.Reverse().ToArray() : data.ToArray();
        }

        private IEnumerable<byte> TakeBytes(int count)
        {
            int i = (int) pos;
            pos += (uint) count;

            return Body.Skip(i).Take(count);
        }

        public uint GetUInt32()
        {
            return BitConverter.ToUInt32(ReverseBytesIfNeeded(TakeBytes(4)), 0);
        }

        public uint GetUInt16()
        {
            return BitConverter.ToUInt16(ReverseBytesIfNeeded(TakeBytes(2)), 0);
        }

        public uint GetUInt16(uint min, uint max)
        {
            uint val = GetUInt16();

            if (val < min)
                return min;

            if (val > max)
                return max;

            return val;
        }

        public double GetDecibels()
        {
            uint val = GetUInt16();

            return Math.Log10(val / 32768d) * 20;
        }

        public int GetInt16()
        {
            return BitConverter.ToInt16(ReverseBytesIfNeeded(TakeBytes(2)), 0);
        }

        public int GetInt16(int min, int max)
        {
            int val = GetInt16();

            if (val < min)
                return min;

            if (val > max)
                return max;

            return val;
        }

        public int GetInt32()
        {
            return BitConverter.ToInt32(ReverseBytesIfNeeded(TakeBytes(4)), 0);
        }

        public long GetInt64()
        {
            return BitConverter.ToInt64(ReverseBytesIfNeeded(TakeBytes(8)), 0);
        }

        public int GetInt32(int min, int max)
        {
            int val = GetInt32();

            if (val < min)
                return min;

            if (val > max)
                return max;

            return val;
        }

        public byte GetByte()
        {
            return Body[pos++];
        }

        public uint GetUInt8()
        {
            return Body[pos++];
        }

        public uint GetUInt8(uint min, uint max)
        {
            uint val = GetUInt8();

            if (val < min)
                return min;

            if (val > max)
                return max;

            return val;
        }

        public bool[] GetBoolArray()
        {
            byte b = Body[pos++];
            return new[]
            {
                (b & (1 << 0)) > 0,
                (b & (1 << 1)) > 0,
                (b & (1 << 2)) > 0,
                (b & (1 << 3)) > 0,
                (b & (1 << 4)) > 0,
                (b & (1 << 5)) > 0,
                (b & (1 << 6)) > 0,
                (b & (1 << 7)) > 0
            };
        }

        public void Skip(uint i = 1)
        {
            pos += i;
        }

        public void SkipToNearestMultipleOf4()
        {
            int targetLen = MathExt.NextMultipleOf4((int)pos);
            Skip((uint)(targetLen - pos));
        }

        public string GetString(uint length)
        {
            string str = Encoding.ASCII.GetString(Body, (int)pos, (int)length);
            pos += length;
            int len = str.IndexOf((char)0);
            return len < 0 ? str : str.Substring(0, len);
        }

        public string GetString(int start, int length)
        {
            string str = Encoding.ASCII.GetString(Body, start, length);
            int len = str.IndexOf((char)0);
            return len < 0 ? str : str.Substring(0, len);
        }
    }

    public class ParsedCommand : ParsedByteArray
    {
        public string Name { get; }

        public ParsedCommand(string name, byte[] body)
            : base(body, true)
        {
            Name = name;
        }
        
        public static bool ReadNextCommand(byte[] payload, int offset, out ParsedCommand cmd)
        {
            cmd = null;

            if (payload.Length < offset + 8)
                return false;

            int cmdLength = (payload[offset] << 8) | payload[offset + 1];
            if (payload.Length < offset + cmdLength || cmdLength == 0)
                return false;

            byte[] cmdBody = new byte[cmdLength - 8];
            Array.Copy(payload, offset + 8, cmdBody, 0, cmdLength - 8);

            string name = Encoding.ASCII.GetString(payload, offset + 4, 4);
            cmd = new ParsedCommand(name, cmdBody);

            return true;
        }
    }
}