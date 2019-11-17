using LibAtem.Util;

namespace LibAtem
{
    public enum ProtocolVersion
    {
        Minimum = V7_2,
        [ProtocolVersionNameAttribute("v7.2")]
        V7_2 = 0x00020016, // 2.22
        V7_X = 0x00020019, // 2.25
        [ProtocolVersionNameAttribute("v8.0")]
        V8_0 = 0x0002001C, // 2.28
        [ProtocolVersionNameAttribute("v8.0.1")]
        V8_0_1 = 0x0002001D, // 2.29
        Latest = V8_0_1
    }
    
    public class ProtocolVersionNameAttribute : System.Attribute
    {
        public ProtocolVersionNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public static class ProtocolVersionExt
    {
        public static string ToVersionString(this ProtocolVersion version)
        {
            var attr = version.GetPossibleAttribute<ProtocolVersion, ProtocolVersionNameAttribute>();
            return attr?.Name ?? version.ToString();
        }
    }
}
