using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class BoolAttribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        private readonly int _index;

        public BoolAttribute(int index = 0)
        {
            _index = index;
        }

        public override uint Size => 1;

        public int Index => _index;

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            if ((bool) val)
                data[start] |= (byte) (1 << Index);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return (data[start] & (1 << Index)) > 0;
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            return random.Next(2) > 0;
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return true;
        }

        public override string GetHashString()
        {
            return $"{_index}";
        }
    }
}