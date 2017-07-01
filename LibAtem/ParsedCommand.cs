using System;
using System.Text;
using LibAtem.Util;

namespace LibAtem
{
    public class ParsedCommand
    {
        public byte[] Body { get; }
        public byte B1 { get; }
        public byte B2 { get; }
        public string Name { get; }

        private uint pos;

        public ParsedCommand(byte b1, byte b2, string name, byte[] body)
        {
            Body = body;
            B1 = b1;
            B2 = b2;
            Name = name;

            pos = 0;
        }

        public bool HasFinished => pos >= BodyLength;

        public int BodyLength => Body.Length;

        public uint GetUInt16()
        {
            return (uint) ((Body[pos++] << 8) + Body[pos++]);
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
            uint index = pos;
            pos += 2;
            return BitConverter.ToInt16(new[] {Body[index + 1], Body[index]}, 0);
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
            uint index = pos;
            pos += 4;
            return BitConverter.ToInt16(new[] {Body[index + 3], Body[index + 2], Body[index + 1], Body[index]}, 0);
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
                (b & (1 << 7)) > 0,
            };
        }

        public void Skip(uint i = 1)
        {
            pos += i;
        }

        public void SkipToNearestPowerOfTwo()
        {
            int targetLen = MathExt.NextPowerOf2((int) pos);
            Skip((uint) (targetLen - pos));
        }

        public string GetString(uint length)
        {
            string str = Encoding.ASCII.GetString(Body, (int) pos, (int) length);
            pos += length;
            return str;
        }
    }
}