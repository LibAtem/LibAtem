using System;
using System.Net;
using System.Net.Sockets;

namespace LibAtem.Util
{
    public static class IPUtil
    {
        public static byte[] ParseAddressUnsafe(string str)
        {
            IPAddress addr = IPAddress.Parse(str);
            if (addr.AddressFamily != AddressFamily.InterNetwork) // is IPv4
                throw new Exception($"Failed to parse IP: {str}");

            return addr.GetAddressBytes();
        }
        public static byte[] ParseAddress(string str)
        {
            try
            {
                return ParseAddressUnsafe(str);
            }
            catch (Exception)
            {
                throw new Exception($"Failed to parse IP: {str}");
            }

            // Return all 0
            return new byte[] { 0, 0, 0, 0 };
        }

        public static string IPToString(params byte[] arr)
        {
            if (arr.Length != 4)
                throw new Exception($"Failed to convert IP to string: {arr}");

            return $"{arr[0]}.{arr[1]}.{arr[2]}.{arr[3]}";
        }
    }
}
