using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace LibAtem.DeviceProfile
{
    public enum DeviceProfileType
    {
        Auto,
        Atem1ME,
        Atem2ME4K,
        AtemTelevisionStudioHD,
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

        public static DeviceProfile TryLoadTopology(string path)
        {
            try
            {
                return LoadTopology(path);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DeviceProfile ParseTopology(string name)
        {
            try
            {
                var assembly = typeof(DeviceProfileRepository).GetTypeInfo().Assembly;
                Stream resource = assembly.GetManifestResourceStream("LibAtem.DeviceProfile.Profiles." + name + ".xml");
                XmlSerializer serializer = new XmlSerializer(typeof(DeviceProfile));
                using (var tx = new StreamReader(resource))
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
                    return ParseTopology("Unknown");
                case DeviceProfileType.Atem1ME:
                    return ParseTopology("Atem1MEProductionSwitcher");
                case DeviceProfileType.AtemTelevisionStudioHD:
                    return ParseTopology("AtemTelevisionStudioHD");
                case DeviceProfileType.Atem2ME4K:
                default:
                    return ParseTopology("Atem2MEProductionStudio4K");
            }
        }

        public static DeviceProfile FindByProductName(string name)
        {
            return Enum.GetValues(typeof(DeviceProfileType))
                .OfType<DeviceProfileType>()
                .Select(GetSystemProfile)
                .FirstOrDefault(p => p.Product == name);
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
