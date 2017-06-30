using System;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("CXMS")]
    public class HyperDeckSettingsSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Address = 1 << 0,
            Input = 1 << 1,
            AutoRoll = 1 << 2,
            AutoRollFrameDelay = 1 << 2,
        }

        public MaskFlags Mask { get; set; }
        public uint Id { get; set; }
        public string NetworkAddress { get; set; }
        public VideoSource Input { get; set; }
        public bool AutoRoll { get; set; }
        public uint AutoRollFrameDelay { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.Pad();
            cmd.AddUInt16(Id);
            cmd.AddByte(IPUtil.ParseAddress(NetworkAddress));
            cmd.AddUInt16((uint)Input);
            cmd.AddBoolArray(AutoRoll);
            cmd.Pad();
            cmd.AddUInt8(AutoRollFrameDelay); // TODO - this causes the delay to report as either 0 or 60 (min or max)
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            cmd.Skip();
            Id = cmd.GetUInt16();
            NetworkAddress = IPUtil.IPToString(cmd.GetByte(), cmd.GetByte(), cmd.GetByte(), cmd.GetByte());
            Input = (VideoSource)cmd.GetUInt16();
            AutoRoll = cmd.GetBoolArray()[0];
            cmd.Skip();
            AutoRollFrameDelay = cmd.GetUInt8(0, 60);
            cmd.Skip(2);
        }
    }
}