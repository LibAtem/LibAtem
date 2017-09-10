using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class DecibelsAttribute : UInt16Attribute
    {
        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            base.Serialize(reverseBytes, data, start, (uint) (Math.Pow(10, (double) val / 20d) * 32768));
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            return UIntToDecibel((uint) base.Deserialize(reverseBytes, data, start, prop));
        }

        private static double UIntToDecibel(uint val)
        {
            return Math.Log10(val / 32768d) * 20;
        }

        public override bool AreEqual(object val1, object val2)
        {
            double tolerance = 1 / (2 * 20d);
            return Math.Abs((double) val1 - (double) val2) <= tolerance;
        }

        public override object GetRandom(Random random)
        {
            return UIntToDecibel((uint) random.Next(65535));
        }

        public override bool IsValid(object obj)
        {
            return (double) obj <= 32768 && (double) obj >= 0;
        }
    }
}