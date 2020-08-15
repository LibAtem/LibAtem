using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LibAtem.Serialization
{
    public class StringAttribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        private readonly int _length;

        public StringAttribute(int length)
        {
            _length = length;
        }

        public override uint Size => (uint) _length;

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            string str = (string)val;
            byte[] res = new byte[_length];
            int i = 0;

            if (str != null)
            {
                for (; i < _length && i < str.Length; i++)
                    res[i] = (byte) str[i];
            }

            for (; i < _length; i++)
                res[i] = 0;

            res.CopyTo(data, (int) start);
        }

        public override object Deserialize(bool cmdReverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            string str = Encoding.ASCII.GetString(data, (int) start, _length);
            int len = str.IndexOf((char) 0);
            return len < 0 ? str : str.Substring(0, len);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            int targetLength = random.Next(_length);

            var str = new StringBuilder();
            while (str.Length < targetLength)
                str.Append(Guid.NewGuid());

            return str.ToString().Substring(0, targetLength);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return true;
        }
    }

    public class StringLengthAttribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        private readonly uint _maxlength;

        public StringLengthAttribute(uint maxlength=128)
        {
            _maxlength = maxlength;
        }
        
        public uint MaxLength => _maxlength;
        
        public override uint Size => 2;

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            string str = (string) val;
            byte[] bytes = BitConverter.GetBytes(str?.Length ?? 0);
            data[start] = bytes[reverseBytes ? 1 : 0];
            data[start + 1] = bytes[reverseBytes ? 0 : 1];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            int len = BitConverter.ToUInt16(ReverseBytes(reverseBytes, data.Skip((int) start).Take(2)), 0);
            return new string(' ', len);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            int len = random.Next((int) _maxlength);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, len)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            string str = (string) obj;
            return str.Length <= _maxlength;
        }
        
        public override string GetHashString()
        {
            return $"{_maxlength}";
        }
    }

    public class BytesLengthAttribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        private readonly uint _maxlength;

        public BytesLengthAttribute(uint maxlength=128)
        {
            _maxlength = maxlength;
        }

        public uint MaxLength => _maxlength;
        
        public override uint Size => 2;

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] str = (byte[]) val;
            byte[] bytes = BitConverter.GetBytes(str.Length);
            data[start] = bytes[reverseBytes ? 1 : 0];
            data[start + 1] = bytes[reverseBytes ? 0 : 1];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            int len = BitConverter.ToUInt16(ReverseBytes(reverseBytes, data.Skip((int) start).Take(2)), 0);
            return new byte[len];
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            int len = random.Next((int) _maxlength);
            return Enumerable.Repeat(0, len)
                .Select(s => (byte) random.Next(255)).ToArray();
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            byte[] str = (byte[]) obj;
            return str.Length <= _maxlength;
        }
        
        public override string GetHashString()
        {
            return $"{_maxlength}";
        }
    }
}