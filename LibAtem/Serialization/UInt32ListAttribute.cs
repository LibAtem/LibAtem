using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class UInt32ListAttribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => _innerAttr.Size * (uint)Count;

        public int Count { get; }

        private readonly UInt32Attribute _innerAttr;

        public UInt32ListAttribute(int count)
        {
            Count = count;
            _innerAttr = new UInt32Attribute();
        }

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            var vals = (List<uint>)val;

            for (int i = 0; i < Count && i < vals.Count; i++)
            {
                _innerAttr.Serialize(reverseBytes, data, (uint)(start + 4 * i), vals[i]);
            }
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            List<uint> vals = new List<uint>(Count);
            for (int i = 0; i < Count; i++)
            {
                object v = _innerAttr.Deserialize(reverseBytes, data, (uint)(start + 4 * i), prop);
                vals.Add((uint)v);
            }

            return vals;
        }

        public override bool AreEqual(object val1, object val2)
        {
            return ((List<uint>)val1).SequenceEqual((List<uint>)val2);
        }

        public object GetRandom(Random random, Type type)
        {
            return Enumerable.Range(0, Count).Select(i => (uint)_innerAttr.GetRandom(random, type)).ToList();
        }

        public override bool IsValid(PropertyInfo prop, object val)
        {
            var vals = (List<uint>)val;
            return vals.All(v => _innerAttr.IsValid(prop, val));
        }
    }
}