using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class NoSerializeAttribute : Attribute
    {
    }

    public class SerializeAttribute : Attribute
    {
        public uint StartByte { get; }

        public SerializeAttribute(uint startByte)
        {
            StartByte = startByte;
        }
    }

    public abstract class SerializableAttributeBase : Attribute
    {
        public abstract void Serialize(bool reverseBytes, byte[] data, uint start, object val);
        public abstract object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop);
        public abstract bool AreEqual(object val1, object val2);
        public abstract bool IsValid(PropertyInfo prop, object val);

        protected byte[] ReverseBytes(bool reverse, IEnumerable<byte> data)
        {
            return reverse ? data.Reverse().ToArray() : data.ToArray();
        }
    }

    public interface IRandomGeneratorAttribute
    {
        object GetRandom(Random random);
        bool IsValid(PropertyInfo prop, object obj);
    }
}
