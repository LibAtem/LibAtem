using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem
{
    public class CommandBuilder
    {
        private readonly string _name;
        private readonly List<byte> _data;

        private readonly byte b1;
        private readonly byte b2;

        public CommandBuilder(string name, byte b1=0x00, byte b2=0x00)
        {
            if (name.Length != 4)
                throw new ArgumentException("Invalid name length");

            _name = name;
            _data = new List<byte>();
            this.b1 = b1;
            this.b2 = b2;
        }

        public void AddUInt8(int val)
        {
            AddByte(BitConverter.GetBytes(val)[0]);
        }

        public void AddUInt8(uint val)
        {
            AddByte(BitConverter.GetBytes(val)[0]);
        }

        public void AddUInt16(int val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            AddByte(bytes[1], bytes[0]);
        }

        public void AddUInt16(uint val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            AddByte(bytes[1], bytes[0]);
        }

        public void AddDecibels(double db)
        {
            AddUInt16(1, Math.Pow(10, db / 20d) * 32768);
        }

        public void AddByte(params byte[] val)
        {
            _data.AddRange(val);
        }

        public void AddBoolArray(bool v1, bool v2 = false, bool v3 = false, bool v4 = false, bool v5 = false,
            bool v6 = false, bool v7 = false, bool v8 = false)
        {
            byte val = 0x00;
            if (v1) val |= 0x01;
            if (v2) val |= 0x02;
            if (v3) val |= 0x04;
            if (v4) val |= 0x08;
            if (v5) val |= 0x10;
            if (v6) val |= 0x20;
            if (v7) val |= 0x40;
            if (v8) val |= 0x80;

            _data.Add(val);
        }

        public void Pad(int count=1)
        {
            for (var i = 0; i < count; i++)
                _data.Add(0x00);
        }

        public void PadToNearestPowerOfTwo()
        {
            int targetLen = MathExt.NextPowerOf2(_data.Count);
            Pad(targetLen - _data.Count);
        }

        public byte[] ToByteArray()
        {
            int length = 8 + _data.Count;
            byte l1 = (byte)(length / 256);
            byte l2 = (byte)(length % 256);

            byte[] prefix = {
                l1, l2, // Length
                b1, b2, // Unknown
            };

            return prefix.Concat(Encoding.ASCII.GetBytes(_name)).Concat(_data).ToArray();
        }

        public void AddString(string str)
        {
           AddString(str.Length, str);
        }

        public void AddString(int length, string str)
        {
            byte[] res = new byte[length];
            for (var i = 0; i < length && i < str.Length; i++)
            {
                res[i] = (byte)str[i];
            }

            _data.AddRange(res);
        }

        public void AddUInt16(int scale, double val)
        {
            AddUInt16((int)(val * scale));
        }
        public void AddUInt8(int scale, double val)
        {
            AddUInt8((int)(val * scale));
        }

        public void AddInt32(int val)
        {
            byte[] res = BitConverter.GetBytes(val);
            AddByte(res[3], res[2], res[1], res[0]);
        }

        public void AddInt16(int scale, double val)
        {
            byte[] res = BitConverter.GetBytes((short) (val * scale));
            AddByte(res[1], res[0]);
        }

        public void AddVideoSource(VideoSource src)
        {
           AddUInt16((int)src);
        }
    }
}