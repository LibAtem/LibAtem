using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class UInt8Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
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

        public virtual object GetRandom(Random random)
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

        public override object GetRandom(Random random)
        {
            return (uint)random.Next(Min, Max);
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return (uint)obj >= Min && (uint)obj <= Max;
        }
    }

    public class UInt8DAttribute : UInt8Attribute
    {
        private readonly double _scale;
        private readonly uint _scaledMin;
        private readonly uint _scaledMax;

        public UInt8DAttribute(double scale, uint scaledMin, uint scaledMax)
        {
            _scale = scale;
            _scaledMin = scaledMin;
            _scaledMax = scaledMax;

            if (scaledMin >= scaledMax)
                throw new ArgumentException("Min must be less than Max");
        }

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            double value = Math.Round((double)val * _scale);
            base.Serialize(reverseBytes, data, start, (uint)value);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            uint rawVal = (uint)base.Deserialize(reverseBytes, data, start, prop);
            double val = rawVal / _scale;

            if (val < _scaledMin / _scale)
                return _scaledMin / _scale;
            if (val > _scaledMax / _scale)
                return _scaledMax / _scale;

            return val;
        }

        public override object GetRandom(Random random)
        {
            uint range = _scaledMax - _scaledMin;
            return (random.NextDouble() * range + _scaledMin) / _scale;
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return (double)obj >= _scaledMin && (double)obj <= _scaledMax;
        }

        public override bool AreEqual(object val1, object val2)
        {
            double tolerance = 1 / (2 * _scale);
            return Math.Abs((double)val1 - (double)val2) <= tolerance;
        }
    }
}