using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class Enum32Attribute : SerializableAttributeBase
    {
        public override void Serialize(byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((int)val);
            data[start] = bytes[3];
            data[start + 1] = bytes[2];
            data[start + 2] = bytes[1];
            data[start + 3] = bytes[0];
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            int val = (data[start] << 24) + (data[start + 1] << 16) + (data[start + 2] << 8) + data[start + 3];
            return Enum.ToObject(prop.PropertyType, val);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }
    }

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

    public class Enum8Attribute : SerializableAttributeBase
    {
        public override void Serialize(byte[] data, uint start, object val)
        {
            data[start] = BitConverter.GetBytes((int)val)[0];
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            return Enum.ToObject(prop.PropertyType, data[start]);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }
    }
}