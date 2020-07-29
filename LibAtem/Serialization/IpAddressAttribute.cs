using System;
using System.Reflection;
using LibAtem.Util;

namespace LibAtem.Serialization
{
    public class IpAddressAttribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        private readonly ByteArrayAttribute _helper;

        public IpAddressAttribute()
        {
            _helper = new ByteArrayAttribute(4);
        }

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = IPUtil.ParseAddress((string) val);
            _helper.Serialize(reverseBytes, data, start, bytes);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            byte[] bytes = (byte[]) _helper.Deserialize(reverseBytes, data, start, prop);
            return IPUtil.IPToString(bytes);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return (string) val1 == (string) val2;
        }

        public object GetRandom(Random random, Type type)
        {
            return IPUtil.IPToString((byte[]) _helper.GetRandom(random, type));
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            try
            {
                IPUtil.ParseAddress((string) obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}