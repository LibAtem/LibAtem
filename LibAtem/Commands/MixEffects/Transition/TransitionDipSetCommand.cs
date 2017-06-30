using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTDp")]
    public class TransitionDipSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Rate = 1 << 0,
            Input = 1 << 1,
        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId Index { get; set; }
        public uint Rate { get; set; }
        public VideoSource Input { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) Index);
            cmd.AddUInt8(Rate);
            cmd.Pad();
            cmd.AddUInt16((int) Input);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            Index = (MixEffectBlockId) cmd.GetUInt8();
            Rate = cmd.GetUInt8(0, 250);
            cmd.Skip();
            Input = (VideoSource) cmd.GetUInt16();
            cmd.Skip(2);
        }
    }
}