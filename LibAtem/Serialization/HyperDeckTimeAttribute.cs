using System.Reflection;
using LibAtem.Common;

namespace LibAtem.Serialization
{
    public class HyperDeckTimeAttribute : SerializableAttributeBase // TODO - implement randomiser?
    {
        private UInt8Attribute _uint8 = new UInt8Attribute();

        public override void Serialize(bool reverseBytes, byte[] data, uint start, object val)
        {
            var val2 = (HyperDeckTime)val;
            if (val2 != null)
            {
                _uint8.Serialize(reverseBytes, data, start, val2.Hour);
                _uint8.Serialize(reverseBytes, data, start + 1, val2.Minute);
                _uint8.Serialize(reverseBytes, data, start + 2, val2.Second);
                _uint8.Serialize(reverseBytes, data, start + 3, val2.Frame);
            }
        }

        public override object Deserialize(bool reverseBytes, byte[] data, uint start, PropertyInfo prop)
        {
            uint hour = (uint)_uint8.Deserialize(reverseBytes, data, start, prop);
            uint minute = (uint)_uint8.Deserialize(reverseBytes, data, start + 1, prop);
            uint second = (uint)_uint8.Deserialize(reverseBytes, data, start + 2, prop);
            uint frame = (uint)_uint8.Deserialize(reverseBytes, data, start + 3, prop);
            return new HyperDeckTime
            {
                Hour = hour,
                Minute = minute,
                Second = second,
                Frame = frame
            };
        }

        public override bool AreEqual(object val1, object val2)
        {
            var val1a = (HyperDeckTime)val1;
            var val2a = (HyperDeckTime)val2;

            return val1a == val2a || (val1a.Hour == val2a.Hour && val1a.Minute == val2a.Minute &&
                                      val1a.Second == val2a.Second && val1a.Frame == val2a.Frame);
        }

        public override bool IsValid(PropertyInfo prop, object val)
        {
            // TODO
            return true;
        }
    }
}