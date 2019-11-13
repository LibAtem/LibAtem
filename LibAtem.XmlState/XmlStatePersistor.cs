using System;
using System.IO;
using System.Xml.Serialization;

namespace LibAtem.XmlState
{
    public class XmlStatePersistor
    {
        public static XmlState LoadState(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlState));
            using (FileStream fs = new FileStream(path, FileMode.Open))
                return (XmlState) serializer.Deserialize(fs);
        }

        public static bool SaveState(string path, XmlState profile)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(XmlState));
            using(FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, profile, ns);
                fs.Flush();
            }
            return true;
        }
    }
}
