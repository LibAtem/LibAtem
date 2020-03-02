using System;
using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class Int64Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((long)val);
            data[start] = bytes[reverseBytes ? 7 : 0];
            data[start + 1] = bytes[reverseBytes ? 6 : 1];
            data[start + 2] = bytes[reverseBytes ? 5 : 2];
            data[start + 3] = bytes[reverseBytes ? 4 : 3];
            data[start + 4] = bytes[reverseBytes ? 3 : 4];
            data[start + 5] = bytes[reverseBytes ? 2 : 5];
            data[start + 6] = bytes[reverseBytes ? 1 : 6];
            data[start + 7] = bytes[reverseBytes ? 0 : 7];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return BitConverter.ToInt64(ReverseBytes(reverseBytes, data.Skip((int)start).Take(8)), 0);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public virtual object GetRandom(Random random)
        {
            var bytes = new byte[8];
            random.NextBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return true; // TODO 
        }
    }
}