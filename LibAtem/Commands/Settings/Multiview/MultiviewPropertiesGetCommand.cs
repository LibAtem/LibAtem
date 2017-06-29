using LibAtem.Common;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMvP")]
    public class MultiviewPropertiesGetCommand : ICommand
    {
        public uint MultiviewIndex { get; set; }
        public MultiViewLayout Layout { get; set; }
        public bool SafeAreaEnabled { get; set; }
        public bool ProgramPreviewSwapped { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((uint) MultiviewIndex);
            cmd.AddUInt8((uint)Layout);
            cmd.AddBoolArray(SafeAreaEnabled);
            cmd.AddBoolArray(ProgramPreviewSwapped);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MultiviewIndex = cmd.GetUInt8();
            Layout = (MultiViewLayout)cmd.GetUInt8();
            SafeAreaEnabled = cmd.GetBoolArray()[0];
            ProgramPreviewSwapped = cmd.GetBoolArray()[0];
        }
    }
}