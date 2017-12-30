using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.Net
{
    public class ReceivedPacket
    {
        // The five bits in "command" (from LSB to MSB): (right to left)
        // 1 = ACK, "Please respond to this packet" (using the _lastRemotePacketID). Exception: The initial 10-20 kbytes of Switcher status
        // 2 = ?. Set during initialization? (first hand-shake packets contains that)
        // 3 = "This is a retransmission". You will see this bit set if the ATEM switcher did not get a timely response to a packet.
        // 4 = ? ("hello packet" according to "ratte", forum at atemuser.com)
        // 5 = "This is a response on your request". So set this when answering...
        [Flags]
        public enum CommandCodeFlags
        {
            None = 0,
            AckRequest = 1 << 0,
            Handshake = 1 << 1,
            Retransmission = 1 << 2,
            Unknown = 1 << 3,
            AckReply = 1 << 4,
        }

        public const int HeaderLength = 12;

        public CommandCodeFlags CommandCode { get; }
        public uint SessionId { get; }
        public uint AckedId { get; }
        public uint PacketId { get; }
        public byte[] Payload { get; }
        public int PayloadLength { get; }
        public List<ParsedCommand> Commands { get; }

        public ReceivedPacket(byte[] raw)
        {
            if (raw.Length < HeaderLength)
                throw new ArgumentException("raw");

            CommandCode = ParseCommandCode(raw[0]);
            PayloadLength = ((raw[0] & 0x07) << 8) + raw[1] - HeaderLength;
            SessionId = (uint)((raw[2] << 8) | raw[3]);
            AckedId = (uint)((raw[4] << 8) | raw[5]);
            PacketId = (uint)((raw[10] << 8) | raw[11]);

            // Ensure payload length doesnt overflow 
            if (PayloadLength + HeaderLength > raw.Length)
                PayloadLength = raw.Length - HeaderLength;

            Payload = raw.Skip(HeaderLength).Take(PayloadLength).ToArray();
            Commands = ParseCommands(Payload);
        }

        private static List<ParsedCommand> ParseCommands(byte[] payload)
        {
            var res = new List<ParsedCommand>();

            int offset = 0;
            while (offset < payload.Length)
            {
                if (!ParsedCommand.ReadNextCommand(payload, offset, out ParsedCommand cmd) || cmd == null)
                    return res;

                res.Add(cmd);
                offset += 8 + cmd.BodyLength;
            }

            return res;
        }

        private static CommandCodeFlags ParseCommandCode(byte b)
        {
            try
            {
                int command = b >> 3;
                return (CommandCodeFlags)command;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}