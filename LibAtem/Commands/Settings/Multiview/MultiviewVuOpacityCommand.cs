using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("VuMo", 4)]
    public class MultiviewVuOpacityCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [Serializable(1), UInt8D(100, 10, 100)]
        public double Opacity { get; set; }
    }
}