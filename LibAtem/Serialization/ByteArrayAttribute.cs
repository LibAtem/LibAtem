using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class ByteArrayAttribute : SerializableAttributeBase
    {
        public override void Serialize(byte[] data, uint start, object val)
        {
            byte[] arr = (byte[]) val;
            arr.CopyTo(data, (int) start);
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            return null; // Note: not supported
        }

        public override bool AreEqual(object val1, object val2)
        {
            return ((byte[]) val1).SequenceEqual((byte[]) val2);
        }
    }
}