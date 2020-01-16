using System;
using System.Linq;
using System.Reflection;
using LibAtem.Util;

namespace LibAtem.Serialization
{
    public class Enum32Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => 4;
        
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((int)val);
            data[start] = bytes[reverseBytes ? 3 : 0];
            data[start + 1] = bytes[reverseBytes ? 2 : 1];
            data[start + 2] = bytes[reverseBytes ? 1 : 2];
            data[start + 3] = bytes[reverseBytes ? 0 : 3];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            int val = BitConverter.ToInt32(ReverseBytes(reverseBytes, data.Skip((int)start).Take(4)), 0);
            return Enum.ToObject(prop.PropertyType, val);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            object[] values = Enum.GetValues(type).OfType<object>().ToArray();
            return values.GetValue(random.Next(values.Length));
        }

        public override bool IsValid(PropertyInfo prop, object val)
        {
            return val.IsValid(prop.PropertyType);
        }
    }

    public class Enum16Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => 2;
        
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((int)val);
            data[start] = bytes[reverseBytes ? 1 : 0];
            data[start + 1] = bytes[reverseBytes ? 0 : 1];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            int val = BitConverter.ToInt16(ReverseBytes(reverseBytes, data.Skip((int)start).Take(2)), 0);
            return Enum.ToObject(prop.PropertyType, val);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            object[] values = Enum.GetValues(type).OfType<object>().Where(v => Convert.ToInt32(v) <= ushort.MaxValue)
                .ToArray();
            return values.GetValue(random.Next(values.Length));
        }

        public override bool IsValid(PropertyInfo prop, object val)
        {
            return val.IsValid(prop.PropertyType) && Convert.ToInt32(val) <= ushort.MaxValue;
        }
    }

    public class Enum8Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => 1;
        
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            data[start] = BitConverter.GetBytes((int)val)[0];
        }

        public override object Deserialize(bool cmdReverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return Enum.ToObject(prop.PropertyType, data[start]);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            object[] values = Enum.GetValues(type).OfType<object>().Where(v => Convert.ToInt32(v) <= byte.MaxValue)
                .ToArray();
            return values.GetValue(random.Next(values.Length));
        }

        public override bool IsValid(PropertyInfo prop, object val)
        {
            return val.IsValid(prop.PropertyType) && Convert.ToInt32(val) <= byte.MaxValue;
        }
    }
}