using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class UInt16Attribute : SerializableAttributeBase
    {
        public override void Serialize(byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((uint) val);
            data[start] = bytes[1];
            data[start+1] = bytes[0];
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            return (uint) ((data[start] << 8) + data[start+1]);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }
    }

    public class UInt16DAttribute : UInt16Attribute, IRandomGeneratorAttribute
    {
        private readonly double _scale;
        private readonly uint _scaledMin;
        private readonly uint _scaledMax;

        public UInt16DAttribute(double scale, uint scaledMin, uint scaledMax)
        {
            _scale = scale;
            _scaledMin = scaledMin;
            _scaledMax = scaledMax;

            if (scaledMin >= scaledMax)
                throw new ArgumentException("Min must be less than Max");
        }

        public override void Serialize(byte[] data, uint start, object val)
        {
            double value = Math.Round((double) val * _scale);
            base.Serialize(data, start, (uint) value);
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            uint rawVal = (uint) base.Deserialize(data, start, prop);
            double val = rawVal / _scale;

            if (val < _scaledMin / _scale)
                return _scaledMin / _scale;
            if (val > _scaledMax / _scale)
                return _scaledMax / _scale;

            return val;
        }

        public object GetRandom(Random random)
        {
            uint range = _scaledMax - _scaledMin;
            return (random.NextDouble() * range + _scaledMin) / _scale;
        }

        public bool IsValid(object obj)
        {
            return (double) obj >= _scaledMin && (double) obj <= _scaledMax;
        }

        public override bool AreEqual(object val1, object val2)
        {
            double tolerance = 1 / (2 * _scale);
            return Math.Abs((double) val1 - (double) val2) <= tolerance;
        }
    }
}
