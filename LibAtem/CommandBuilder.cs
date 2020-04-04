using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibAtem.Util;

namespace LibAtem
{
    public class ByteArrayBuilder
    {
        private readonly List<byte> _data;

        public bool ReverseBytes { get; }

        public ByteArrayBuilder(bool reverseBytes)
        {
            ReverseBytes = reverseBytes;
            _data = new List<byte>();
        }

        private IEnumerable<byte> ReverseBytesIfNeeded(IEnumerable<byte> data)
        {
            return ReverseBytes ? data.Reverse() : data;
        }

        public void Set(int pos, params byte[] b)
        {
            for (int i = 0; i < b.Length; i++)
                _data[pos + i] = b[i];
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
            AddByte(ReverseBytesIfNeeded(BitConverter.GetBytes(val).Take(2)));
        }

        public void AddUInt16(uint val)
        {
            AddByte(ReverseBytesIfNeeded(BitConverter.GetBytes(val).Take(2)));
        }

        public void AddDecibels(double db)
        {
            AddUInt16(1, Math.Pow(10, db / 20d) * 32768);
        }

        public void AddByte(IEnumerable<byte> val)
        {
            _data.AddRange(val);
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

        public void Pad(int count = 1)
        {
            for (var i = 0; i < count; i++)
                _data.Add(0x00);
        }

        public void PadToNearestMultipleOf4()
        {
            int targetLen = MathExt.NextMultipleOf4(_data.Count);
            Pad(targetLen - _data.Count);
        }

        public virtual byte[] ToByteArray()
        {
            return _data.ToArray();
        }

        public void AddString(string str)
        {
            AddString(str.Length, str);
        }

        public void AddString(int length, string str)
        {
            byte[] res = new byte[length];
            int i;
            for (i = 0; i < length && i < str.Length; i++)
            {
                res[i] = (byte)str[i];
            }
            for (; i < length; i++)
            {
                res[i] = 0;
            }

            _data.AddRange(res);
        }

        public void SetString(int pos, string str)
        {
            SetString(pos, str?.Length ?? 0, str);
        }

        public void SetString(int pos, int length, string str)
        {
            int i;
            for (i = 0; i < length && i < str.Length; i++)
            {
                _data[pos + i] = (byte)str[i];
            }
            for (; i < length; i++)
            {
                _data[pos + i] = 0;
            }
        }

        public void SetByte(int pos, byte[] bytes) {
            int i;
            for (i = 0; i < bytes.Length; i++)
            {
                _data[pos + i] = (byte)bytes[i];
            }
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
            AddByte(ReverseBytesIfNeeded(BitConverter.GetBytes(val).Take(4)));
        }

        public void AddInt64(long val)
        {
            AddByte(ReverseBytesIfNeeded(BitConverter.GetBytes(val).Take(8)));
        }

        public void AddInt16(int scale, double val)
        {
            AddByte(ReverseBytesIfNeeded(BitConverter.GetBytes((short)(val * scale)).Take(2)));
        }

        public void AddUInt32(uint val)
        {
            AddByte(ReverseBytesIfNeeded(BitConverter.GetBytes(val).Take(4)));
        }
    }

    public class CommandBuilder : ByteArrayBuilder
    {
        private readonly string _name;

        public CommandBuilder(string name)
            : base(true)
        {
            if (name.Length != 4)
                throw new ArgumentException("Invalid name length");

            _name = name;
        }

        public override byte[] ToByteArray()
        {
            byte[] data = base.ToByteArray();

            int length = 8 + data.Length;
            byte l1 = (byte)(length / 256);
            byte l2 = (byte)(length % 256);

            byte[] prefix = {
                l1, l2, // Length
                0x00, 0x00, // Unknown
            };

            return prefix.Concat(Encoding.ASCII.GetBytes(_name)).Concat(data).ToArray();
        }
    }
}