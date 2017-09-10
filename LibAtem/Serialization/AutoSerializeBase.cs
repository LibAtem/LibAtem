using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LibAtem.Serialization
{
    public abstract class AutoSerializeBase
    {
        protected abstract int GetLengthFromAttribute();

        protected virtual int GetLength()
        {
            return GetLengthFromAttribute();
        }

        private string GetName()
        {
            return GetType().Name;
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(prop => prop.GetCustomAttribute<NoSerializeAttribute>() == null);
        }

        public virtual void Serialize(ByteArrayBuilder cmd)
        {
            int length = GetLength();
            if (length < 0)
                throw new SerializationException(GetName(), "Cannot auto serialize without a defined length");

            var res = new byte[length];
            foreach (PropertyInfo prop in GetProperties())
            {

                SerializeAttribute attr = prop.GetCustomAttribute<SerializeAttribute>();
                if (attr == null) // This means the property shouldnt be serialized
                    continue;

                SerializableAttributeBase serAttr = prop.GetCustomAttribute<SerializableAttributeBase>();
                if (serAttr == null)
                    throw new SerializationException(GetName(), "Missing serialization definition on property {0}", prop.Name);

                serAttr.Serialize(cmd.ReverseBytes, res, attr.StartByte, prop.GetValue(this));
            }

            cmd.AddByte(res);
        }

        public virtual void Deserialize(ParsedByteArray cmd)
        {
            int attrLength = GetLengthFromAttribute();
            if (attrLength != -1 && attrLength != cmd.BodyLength)
                throw new Exception("Auto deserialze length mismatch");

            foreach (PropertyInfo prop in GetProperties())
            {
                // If the field is readonly, then ignore
                if (!prop.CanWrite)
                    continue;

                SerializeAttribute attr = prop.GetCustomAttribute<SerializeAttribute>();
                if (attr == null) // This means the property shouldnt be serialized
                    continue;

                SerializableAttributeBase serAttr = prop.GetCustomAttribute<SerializableAttributeBase>();
                if (serAttr == null)
                    throw new SerializationException(GetName(), "Missing serialization definition on property {0}", prop.Name);

                prop.SetValue(this, serAttr.Deserialize(cmd.ReverseBytes, cmd.Body, attr.StartByte, prop));
            }

            if (GetLength() != cmd.BodyLength)
                throw new Exception("Auto deserialze final length mismatch");
        }
    }

    public class SerializationException : Exception
    {
        public string CommandName { get; }

        public SerializationException(string cmdName, string fmt, params object[] vals) : base(
            string.Format(string.Format("{0}: {1}", cmdName, fmt), vals))
        {
            CommandName = cmdName;
        }
    }
}