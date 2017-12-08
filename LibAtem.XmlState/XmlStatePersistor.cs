using System;
using System.IO;
using System.Xml.Serialization;

namespace LibAtem.XmlState
{
    public class XmlStatePersistor
    {
        public static XmlState LoadState(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlState));
                FileStream fs = new FileStream(path, FileMode.Open);
                var res = (XmlState)serializer.Deserialize(fs);
                fs.Dispose();
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool SaveState(string path, XmlState profile)
        {
            try
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer serializer = new XmlSerializer(typeof(XmlState));
                FileStream fs = new FileStream(path, FileMode.Create);
                serializer.Serialize(fs, profile, ns);
                fs.Flush();
                fs.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
