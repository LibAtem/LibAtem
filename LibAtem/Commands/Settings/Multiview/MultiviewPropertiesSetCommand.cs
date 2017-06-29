using System;
using LibAtem.Common;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMvP")]
    public class MultiviewPropertiesSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Layout = 1 << 0,
            SafeAreaEnabled = 1 << 1,
            ProgramPreviewSwapped = 1 << 2,
        }

        public MaskFlags Mask { get; set; }
        public uint MultiviewIndex { get; set; }
        public MultiViewLayout Layout { get; set; }
        public bool SafeAreaEnabled { get; set; }
        public bool ProgramPreviewSwapped { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((uint) Mask);
            cmd.AddUInt8(MultiviewIndex);
            cmd.AddUInt8((uint)Layout);
            cmd.AddBoolArray(SafeAreaEnabled);
            cmd.AddBoolArray(ProgramPreviewSwapped);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            MultiviewIndex = cmd.GetUInt8();
            Layout = (MultiViewLayout) cmd.GetUInt8();
            SafeAreaEnabled = cmd.GetBoolArray()[0];
            ProgramPreviewSwapped = cmd.GetBoolArray()[0];
            cmd.Skip(3);
        }
    }
}