using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class Enum16Attribute : SerializableAttributeBase
    {
        public override void Serialize(byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((int)val);
            data[start] = bytes[1];
            data[start + 1] = bytes[0];
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            return Enum.ToObject(prop.PropertyType, (data[start] << 8) + data[start+1]);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }
    }
}