using System;
using System.IO;
using System.Xml.Serialization;
using LibAtem.DeviceProfile.Properties;

namespace LibAtem.DeviceProfile
{
    public enum DeviceProfileType
    {
        Auto,
        Atem1ME,
        Atem2ME4K,
    }

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

        public static DeviceProfile GetSystemProfile(DeviceProfileType id)
        {
            switch (id)
            {
                case DeviceProfileType.Auto:
                    return ParseTopology(Resources.Unknown);
                case DeviceProfileType.Atem1ME:
                    return ParseTopology(Resources.Atem1MEProductionSwitcher);
                case DeviceProfileType.Atem2ME4K:
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
