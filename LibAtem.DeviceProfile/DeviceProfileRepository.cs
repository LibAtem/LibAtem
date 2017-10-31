using System;
using System.IO;
using System.Xml.Serialization;
using LibAtem.DeviceProfile.Properties;

namespace LibAtem.DeviceProfile
{
    public static class DeviceProfileRepository
    {
        public static DeviceProfile LoadTopology(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DeviceProfile));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                    return (DeviceProfile)serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
                throw new DeviceProfileException(e);
            }
        }

        public static DeviceProfile ParseTopology(string data)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DeviceProfile));
                using (var tx = new StringReader(data))
                    return (DeviceProfile) serializer.Deserialize(tx);
            }
            catch (Exception e)
            {
                throw new DeviceProfileException(e);
            }
        }

        public static DeviceProfile GetSystemProfile(string id)
        {
            switch (id)
            {
                case "atem-1me":
                    return ParseTopology(Resources.Atem1MEProductionSwitcher);
                case "atem-2me-4k":
                default:
                    return ParseTopology(Resources.Atem2MEProductionStudio4K);
            }
        }
    }

    public class DeviceProfileException : Exception
    {
        public DeviceProfileException(Exception e)
            : base("Failed to load profile", e)
        {   
        }
    }
}
