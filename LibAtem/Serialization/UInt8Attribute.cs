using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class UInt8Attribute : SerializableAttributeBase
    {
        public override void Serialize(byte[] data, uint start, object val)
        {
            data[start] = BitConverter.GetBytes((uint) val)[0];
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            return data[start];
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }
    }

    public class UInt8RangeAttribute : UInt8Attribute, IRandomGeneratorAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public UInt8RangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public object GetRandom(Random random)
        {
            return (uint)random.Next(_min, _max);
        }

        public bool IsValid(object obj)
        {
            return (uint)obj >= _min && (uint)obj <= _max;
        }
    }
}