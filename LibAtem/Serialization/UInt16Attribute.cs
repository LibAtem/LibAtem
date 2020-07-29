using System;
using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class UInt16Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((uint) val);
            data[start] = bytes[reverseBytes ? 1 : 0];
            data[start+1] = bytes[reverseBytes ? 0 : 1];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return (uint) BitConverter.ToUInt16(ReverseBytes(reverseBytes, data.Skip((int)start).Take(2)), 0);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public virtual object GetRandom(Random random, Type type)
        {
            return (uint) random.Next(65535);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return (uint) obj <= 65535;
        }
    }

    public class UInt16RangeAttribute : UInt16Attribute
    {
        public int Min { get; }
        public int Max { get; }

        public UInt16RangeAttribute(int min, int max)
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
    }

    public class UInt16DAttribute : UInt16Attribute
    {
        public double Scale { get; }
        public uint ScaledMin { get; }
        public uint ScaledMax { get; }

        public UInt16DAttribute(double scale, uint scaledMin, uint scaledMax)
        {
            Scale = scale;
            ScaledMin = scaledMin;
            ScaledMax = scaledMax;

            if (scaledMin >= scaledMax)
                throw new ArgumentException("Min must be less than Max");
        }

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            double value = Math.Round((double) val * Scale);
            base.Serialize(reverseBytes, data, start, (uint) value);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            uint rawVal = (uint) base.Deserialize(reverseBytes, data, start, prop);
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
            return (double) obj >= ScaledMin / Scale && (double) obj <= ScaledMax / Scale;
        }

        public override bool AreEqual(object val1, object val2)
        {
            double tolerance = 1 / (2 * Scale);
            return Math.Abs((double) val1 - (double) val2) <= tolerance;
        }
    }

    public class UInt16TolAttribute : UInt16Attribute
    {
        private readonly uint _tolerance;

        public UInt16TolAttribute(uint tolerance)
        {
            _tolerance = tolerance;
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Math.Abs((int) ((uint) val1 - (uint) val2)) <= _tolerance;
        }
    }
}
