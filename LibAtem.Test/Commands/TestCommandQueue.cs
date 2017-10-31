using LibAtem.Commands;
using LibAtem.Common;
using Xunit;

namespace LibAtem.Test.Commands
{
    public class TestCommandQueue
    {
        [Fact]
        public void TestCommandQueueKeyWithMask()
        {
            var cmd = new ColorGeneratorSetCommand()
            {
                Mask = ColorGeneratorSetCommand.MaskFlags.Hue,
                Index = ColorGeneratorId.Two,
                Hue = 5,
            };

            var key = new CommandQueueKey(cmd);
            Assert.NotEqual(0, key.Mask);
        }

        [Fact]
        public void TestCommandQueueKeyId()
        {
            var cmd = new ColorGeneratorGetCommand()
            {
                Index = ColorGeneratorId.Two,
                Hue = 5,
            };

            var key = new CommandQueueKey(cmd);
            Assert.NotEqual(0, key.Id);
            Assert.Equal(0, key.Mask);
        }

        [Fact]
        public void TestCommandQueueKeyNoId()
        {
            var cmd = new TallyChannelConfigCommand()
            {
                InputCount = 0,
            };

            var key = new CommandQueueKey(cmd);
            Assert.Equal(0, key.Id);
        }
    }
}