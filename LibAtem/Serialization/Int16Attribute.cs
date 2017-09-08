using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class Int16Attribute : SerializableAttributeBase
    {
        public override void Serialize(byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((int)val);
            data[start] = bytes[1];
            data[start + 1] = bytes[0];
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            return (int)BitConverter.ToInt16(new[] { data[start + 1], data[start] }, 0);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
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

        public override void Serialize(byte[] data, uint start, object val)
        {
            double value = Math.Round((double)val * Scale);
            base.Serialize(data, start, (int)value);
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            int rawVal = (int)base.Deserialize(data, start, prop);
            double val = rawVal / Scale;

            if (val < ScaledMin)
                return ScaledMin;
            if (val > ScaledMax)
                return ScaledMax;

            return val;
        }

        public object GetRandom(Random random)
        {
            int range = ScaledMax - ScaledMin;
            return (random.NextDouble() * range + ScaledMin) / Scale;
        }

        public bool IsValid(object obj)
        {
            return (double)obj >= ScaledMin && (double)obj <= ScaledMax;
        }

        public override bool AreEqual(object val1, object val2)
        {
            double tolerance = 1 / (2 * Scale);
            return Math.Abs((double)val1 - (double)val2) <= tolerance;
        }
    }
}