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
        private readonly double _scale;
        private readonly int _scaledMin;
        private readonly int _scaledMax;

        public Int16DAttribute(double scale, int scaledMin, int scaledMax)
        {
            _scale = scale;
            _scaledMin = scaledMin;
            _scaledMax = scaledMax;

            if (scaledMin >= scaledMax)
                throw new ArgumentException("Min must be less than Max");
        }

        public override void Serialize(byte[] data, uint start, object val)
        {
            double value = Math.Round((double)val * _scale);
            base.Serialize(data, start, (int)value);
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            int rawVal = (int)base.Deserialize(data, start, prop);
            double val = rawVal / _scale;

            if (val < _scaledMin)
                return _scaledMin;
            if (val > _scaledMax)
                return _scaledMax;

            return val;
        }

        public object GetRandom(Random random)
        {
            int range = _scaledMax - _scaledMin;
            return (random.NextDouble() * range + _scaledMin) / _scale;
        }

        public bool IsValid(object obj)
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