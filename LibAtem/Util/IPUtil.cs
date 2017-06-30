using System;
using System.Net;
using System.Net.Sockets;

namespace LibAtem.Util
{
    public static class IPUtil
    {
        public static byte[] ParseAddress(string str)
        {
            try
            {
                IPAddress addr = IPAddress.Parse(str);
                if (addr.AddressFamily == AddressFamily.InterNetwork) // is IPv4
                    return addr.GetAddressBytes();
            }
            catch (Exception)
            {
                throw new Exception(string.Format("Failed to parse hyperdeck IP: {0}", str));
            }

            // Return all 0
            return new byte[] { 0, 0, 0, 0 };
        }

        public static string IPToString(params byte[] arr)
        {
            if (arr.Length != 4)
                throw new Exception(string.Format("Failed to convert hyperdeck IP to string: {0}", arr));

            return string.Format("{0}.{1}.{2}.{3}", arr[0], arr[1], arr[2], arr[3]);
        }
    }
}
