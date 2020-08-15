using System;
using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class Int32Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => 4;

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((int)val);
            data[start] = bytes[reverseBytes ? 3 : 0];
            data[start + 1] = bytes[reverseBytes ? 2 : 1];
            data[start + 2] = bytes[reverseBytes ? 1 : 2];
            data[start + 3] = bytes[reverseBytes ? 0 : 3];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return BitConverter.ToInt32(ReverseBytes(reverseBytes, data.Skip((int)start).Take(4)), 0);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public virtual object GetRandom(Random random, Type type)
        {
            return random.Next();
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return true; // TODO 
        }
    }

    public class Int32DAttribute : Int32Attribute
    {
        public double Scale { get; }
        public int ScaledMin { get; }
        public int ScaledMax { get; }
        public bool NegativeInfinity { get; }

        public Int32DAttribute(double scale, int scaledMin, int scaledMax, bool negativeInfinity = false)
        {
            Scale = scale;
            ScaledMin = scaledMin;
            ScaledMax = scaledMax;
            NegativeInfinity = negativeInfinity;

            if (scaledMin >= scaledMax)
                throw new ArgumentException("Min must be less than Max");
        }

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            int value = (int)Math.Round((double)val * Scale);
            if (double.IsNegativeInfinity((double)val))
                value = ScaledMin - 1;

            base.Serialize(reverseBytes, data, start, value);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            int val = (int)base.Deserialize(reverseBytes, data, start, prop);

            if (val <= ScaledMin)
                return NegativeInfinity ? double.NegativeInfinity : ScaledMin / Scale;
            if (val >= ScaledMax)
                return ScaledMax / Scale;

            return val / Scale;
        }

        public override object GetRandom(Random random, Type type)
        {
            double range = (double)ScaledMax - (double)ScaledMin;
            return (random.NextDouble() * range + ScaledMin) / Scale;
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return (double)obj >= ScaledMin / Scale && (double)obj <= ScaledMax / Scale;
        }

        public override bool AreEqual(object val1, object val2)
        {
            double tolerance = Math.Max(1 / (2 * Scale), 0.0001);
            return Math.Abs((double)val1 - (double)val2) <= tolerance;
        }
        
        public override string GetHashString()
        {
            return $"{Scale},{ScaledMin},{ScaledMax},{NegativeInfinity}";
        }
    }

    public class UInt32Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => 4;

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            byte[] bytes = BitConverter.GetBytes((uint)val);
            data[start] = bytes[reverseBytes ? 3 : 0];
            data[start + 1] = bytes[reverseBytes ? 2 : 1];
            data[start + 2] = bytes[reverseBytes ? 1 : 2];
            data[start + 3] = bytes[reverseBytes ? 0 : 3];
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return BitConverter.ToUInt32(ReverseBytes(reverseBytes, data.Skip((int)start).Take(4)), 0);
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public virtual object GetRandom(Random random, Type type)
        {
            return (uint)random.Next();
        }

        public override bool IsValid(PropertyInfo prop, object obj)
        {
            return true; // TODO 
        }
    }

    public class UInt32RangeAttribute : UInt32Attribute
    {
        public int Min { get; }
        public int Max { get; }

        public UInt32RangeAttribute(int min, int max)
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

    public class UInt32DAttribute : UInt32Attribute
    {
        public double Scale { get; }
        public uint ScaledMin { get; }
        public uint ScaledMax { get; }

        public UInt32DAttribute(double scale, uint scaledMin, uint scaledMax)
        {
            Scale = scale;
            ScaledMin = scaledMin;
            ScaledMax = scaledMax;

            if (scaledMin >= scaledMax)
                throw new ArgumentException("Min must be less than Max");
        }

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            uint value = (uint)Math.Round((double)val * Scale);
            base.Serialize(reverseBytes, data, start, value);
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            uint val = (uint)base.Deserialize(reverseBytes, data, start, prop);

            if (val < ScaledMin)
                return ScaledMin / Scale;
            if (val > ScaledMax)
                return ScaledMax / Scale;

            return val / Scale;
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

    public class UInt32DScaleAttribute : UInt32DAttribute
    {
        public UInt32DScaleAttribute(double max = 1) : base(uint.MaxValue / max, 0, (uint)(uint.MaxValue / max))
        {
        }
    }

    public class DirectionInt32Attribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        public override uint Size => 5;

        private readonly BoolAttribute _bool = new BoolAttribute();
        private readonly UInt32Attribute _uint32 = new UInt32Attribute();
        private readonly Int32Attribute _int32 = new Int32Attribute();

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            int val1 = (int)val;
            _bool.Serialize(reverseBytes, data, start, val1 < 0);
            _uint32.Serialize(reverseBytes, data, start + 1, (uint)Math.Abs(val1));
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            bool isNegative = (bool)_bool.Deserialize(reverseBytes, data, start, prop);
            int val = (int)(uint)_uint32.Deserialize(reverseBytes, data, start + 1, prop);
            return isNegative ? -val : val;
        }

        public override bool AreEqual(object val1, object val2)
        {
            return _int32.AreEqual(val1, val2);
        }

        public object GetRandom(Random random, Type type)
        {
            return _int32.GetRandom(random, type);
        }

        public override bool IsValid(PropertyInfo prop, object val)
        {
            return _int32.IsValid(prop, val);
        }
    }
}