using System;
using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class Int16Attribute : SerializableAttributeBase
    {
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((int)val);
            data[start] = bytes[reverseBytes ? 1 : 0];
            data[start + 1] = bytes[reverseBytes ? 0 : 1];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return (int)BitConverter.ToInt16(ReverseBytes(reverseBytes, data.Skip((int)start).Take(2)), 0);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return true; // TODO 
        }
    }

    public class Int16DAttribute : Int16Attribute, IRandomGeneratorAttribute
    {
        public double Scale { get; }
        public int ScaledMin { get; }
        public int ScaledMax { get; }

        public Int16DAttribute(double scale, int scaledMin, int scaledMax)
        {
            Scale = scale;
            ScaledMin = scaledMin;
            ScaledMax = scaledMax;

            if (scaledMin >= scaledMax)
                throw new ArgumentException("Min must be less than Max");
        }

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            double value = Math.Round((double)val * Scale);
            base.Serialize(reverseBytes, data, start, (int)value);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            double val = (int)base.Deserialize(reverseBytes, data, start, prop);

            if (val < ScaledMin)
                return ScaledMin / Scale;
            if (val > ScaledMax)
                return ScaledMax / Scale;

            return val / Scale;
        }

        public object GetRandom(Random random)
        {
            int range = ScaledMax - ScaledMin;
            return (random.NextDouble() * range + ScaledMin) / Scale;
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return (double)obj >= ScaledMin / Scale && (double)obj <= ScaledMax / Scale;
        }

        public override bool AreEqual(object val1, object val2)
        {
            double tolerance = 1 / (2 * Scale);
            return Math.Abs((double)val1 - (double)val2) <= tolerance;
        }
    }
}