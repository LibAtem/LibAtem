using System;
using System.Reflection;
using System.Text;

namespace LibAtem.Serialization
{
    public class StringAttribute : SerializableAttributeBase, IRandomGeneratorAttribute
    {
        private readonly int _length;

        public StringAttribute(int length)
        {
            _length = length;
        }

        public override void Serialize(byte[] data, uint start, object val)
        {
            string str = (string)val;
            byte[] res = new byte[_length];
            int i;

            for (i = 0; i < _length && i < str.Length; i++)
                res[i] = (byte)str[i];

            for (; i < _length; i++)
                res[i] = 0;

            res.CopyTo(data, (int) start);
        }

        public override object Deserialize(byte[] data, uint start, PropertyInfo prop)
        {
            string str = Encoding.ASCII.GetString(data, (int) start, _length);
            return str.Substring(0, str.IndexOf((char) 0));
        }

        public override bool AreEqual(object val1, object val2)
        {
            return Equals(val1, val2);
        }

        public object GetRandom(Random random)
        {
            int targetLength = random.Next(_length);

            var str = new StringBuilder();
            while (str.Length < targetLength)
                str.Append(Guid.NewGuid());

            return str.ToString().Substring(0, targetLength);
        }

        public bool IsValid(object obj)
        {
            return true;
        }
    }
}