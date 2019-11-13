using System;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Net;
using PcapngFile;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.Test.Commands
{
    public class TestPcapDump
    {
        private readonly ITestOutputHelper output;

        public TestPcapDump(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(Skip = "Command parsing not complete")]
        public void Test2ME4KWithHyperdeck()
        {
            RunForFile(ProtocolVersion.V7_2, "TestFiles/Pcap/7.2-2me4k-hyperdeck.pcapng");
        }

        [Fact(Skip = "Command parsing not complete")]
        public void TestPS4K()
        {
            RunForFile(ProtocolVersion.V7_2, "TestFiles/Pcap/7.2-ps4k.pcapng");
        }

        #region Helpers

        private void RunForFile(ProtocolVersion version, string filename)
        {
            bool failed = false;

            using (var reader = new Reader(filename))
            {
                foreach (var readBlock in reader.EnhancedPacketBlocks)
                {
                    failed |= ParseEnhancedBlock(version, readBlock as EnhancedPacketBlock);
                }
            }

            Assert.False(failed);
        }

        private bool ParseEnhancedBlock(ProtocolVersion version, EnhancedPacketBlock block)
        {
            byte[] data = block.Data;

            // Perform some basic checks, to ensure data looks like it could be ATEM
            if (data[23] != 17)
                throw new ArgumentOutOfRangeException("Found packet that appears to not be UDP");
            if ((data[36] << 8) + data[37] != 9910 && (data[34] << 8) + data[35] != 9910)
                throw new ArgumentOutOfRangeException("Found packet that has wrong UDP port");

            data = data.Skip(42).ToArray();
            var packet = new ReceivedPacket(data);
            if (!packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckRequest))
                return false;

            bool failed = false;

            foreach (ParsedCommand cmd in packet.Commands)
            {
                try
                {
                    // Try and parse, just to ensure it was successful
                    CommandParser.ParseUnsafe(version, cmd);
                }
                catch (Exception e)
                {
                    output.WriteLine(e.ToString());
                    failed = true;
                }
            }

            // TODO - parse any macros that were downloaded

            return failed;
        }

        #endregion Helpers
    }
}
