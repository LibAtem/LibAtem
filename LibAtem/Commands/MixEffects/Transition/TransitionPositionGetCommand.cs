using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TrPs")]
    public class TransitionPositionGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public bool InTransition { get; set; }
        public uint RemainingFrames { get; set; }
        public uint HandlePosition { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddBoolArray(InTransition);
            cmd.AddUInt8(RemainingFrames);
            cmd.Pad();
            cmd.AddUInt16(HandlePosition);
            cmd.AddByte(0x13, 0x01); // TODO - unknown
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            InTransition = cmd.GetBoolArray()[0];
            RemainingFrames = cmd.GetUInt8();
            cmd.Skip();
            HandlePosition = cmd.GetUInt16();
            cmd.Skip(2);
        }
    }
}