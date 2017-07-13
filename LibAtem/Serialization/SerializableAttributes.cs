using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class NoSerializeAttribute : Attribute
    {
    }

    public class SerializeAttribute : Attribute
    {
        public uint StartByte { get; }
        //public uint? SecondaryStartByte { get; }

        public SerializeAttribute(uint startByte)//, uint? secondaryStartByte)
        {
            StartByte = startByte;
            //SecondaryStartByte = secondaryStartByte;
        }
    }

    public abstract class SerializableAttributeBase : Attribute
    {
        public abstract void Serialize(byte[] data, uint start, object val);
        public abstract object Deserialize(byte[] data, uint start, PropertyInfo prop);
        public abstract bool AreEqual(object val1, object val2);
    }

    public interface IRandomGeneratorAttribute
    {
        object GetRandom(Random random);
        bool IsValid(object obj);
    }
}
