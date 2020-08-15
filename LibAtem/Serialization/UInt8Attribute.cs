using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class UInt8Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => 1;
        
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            data[start] = BitConverter.GetBytes((uint) val)[0];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return (uint) data[start];
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public virtual object GetRandom(Random random, Type type)
        {
            return (uint) random.Next(255);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return (uint) obj <= 255;
        }
    }

    public class UInt8RangeAttribute : UInt8Attribute
    {
        public int Min { get; }
        public int Max { get; }

        public UInt8RangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            uint val = (uint)base.Deserialize(reverseBytes, data, start, prop);

            if (val < Min)
                return (uint)Min;
            if (val > Max)
                return (uint)Max;

            return val;
        }

        public override object GetRandom(Random random, Type type)
        {
            return (uint)random.Next(Min, Max);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return (uint)obj >= Min && (uint)obj <= Max;
        }
        
        public override string GetHashString()
        {
            return $"{Min},{Max}";
        }
    }

    public class UInt8DAttribute : UInt8Attribute
    {
        public double Scale { get; }
        public uint ScaledMin { get; }
        public uint ScaledMax { get; }

        public UInt8DAttribute(double scale, uint scaledMin, uint scaledMax)
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
            base.Serialize(reverseBytes, data, start, (uint)value);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            uint rawVal = (uint)base.Deserialize(reverseBytes, data, start, prop);
            double val = rawVal / Scale;

            if (val < ScaledMin / Scale)
                return ScaledMin / Scale;
            if (val > ScaledMax / Scale)
                return ScaledMax / Scale;

            return val;
        }

        public override object GetRandom(Random random, Type type)
        {
            uint range = ScaledMax - ScaledMin;
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
        
        public override string GetHashString()
        {
            return $"{Scale},{ScaledMin},{ScaledMax}";
        }
    }
}