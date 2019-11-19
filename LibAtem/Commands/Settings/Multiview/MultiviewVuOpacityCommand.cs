using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("VuMo", CommandDirection.Both, 4)] // TODO - verify direction
    public class MultiviewVuOpacityCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [Serialize(1), UInt8D(1, 0, 100)]
        public double Opacity { get; set; }
    }
}