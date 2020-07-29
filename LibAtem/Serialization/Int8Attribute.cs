using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class Int8Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            data[start] = BitConverter.GetBytes((int)val)[0];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return (int)data[start];
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public virtual object GetRandom(Random random, Type type)
        {
            return random.Next(sbyte.MinValue, sbyte.MaxValue);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            int v = (int) obj;
            return v <= sbyte.MaxValue && v >= sbyte.MinValue;
        }
    }
}