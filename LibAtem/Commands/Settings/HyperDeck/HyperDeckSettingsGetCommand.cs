using System;
using System.Net;
using System.Net.Sockets;
using LibAtem.Common;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXMS")]
    public class HyperDeckSettingsGetCommand : ICommand
    {
        public uint Id { get; set; }
        public string NetworkAddress { get; set; }
        public VideoSource Input { get; set; }
        public bool AutoRoll { get; set; }
        public uint AutoRollFrameDelay { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Id);
            cmd.Pad(2);
            cmd.AddByte(ParseAddress(NetworkAddress));
            cmd.AddUInt16((uint)Input);
            cmd.AddBoolArray(AutoRoll);
            cmd.Pad();
            cmd.AddUInt8(AutoRollFrameDelay); // TODO - this causes the delay to report as either 0 or 60 (min or max)
            cmd.Pad(7);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(2);
            NetworkAddress = string.Format("{0}.{1}.{2}.{3}", cmd.GetByte(), cmd.GetByte(), cmd.GetByte(),cmd.GetByte());
            Input = (VideoSource)cmd.GetUInt16();
            AutoRoll = cmd.GetBoolArray()[0];
            cmd.Skip();
            AutoRollFrameDelay = cmd.GetUInt8(0, 60);
            cmd.Skip(7);
        }

        private static byte[] ParseAddress(string str)
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
    }
}