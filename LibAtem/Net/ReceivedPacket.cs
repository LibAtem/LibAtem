using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.Net
{
    public class ReceivedPacket
    {
        [Flags]
        public enum CommandCodeFlags
        {
            None = 0,
            AckRequest = 1 << 0,
            Handshake = 1 << 1,
            IsRetransmit = 1 << 2,
            RetransmitRequest = 1 << 3,
            AckReply = 1 << 4,
        }

        public const int HeaderLength = 12;

        public CommandCodeFlags CommandCode { get; }
        public uint SessionId { get; }
        public uint AckedId { get; }
        public uint PacketId { get; }
        public byte[] Payload { get; }
        public int PayloadLength { get; }
        public List<ParsedCommandSpec> Commands { get; }

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

        public static List<ParsedCommandSpec> ParseCommands(byte[] payload)
        {
            var res = new List<ParsedCommandSpec>();

            int offset = 0;
            while (offset < payload.Length)
            {
                if (!ParsedCommand.ReadNextCommand(payload, offset, out ParsedCommandSpec? cmd) || !cmd.HasValue)
                    return res;

                res.Add(cmd.Value);
                offset += 8 + cmd.Value.Body.Length;
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