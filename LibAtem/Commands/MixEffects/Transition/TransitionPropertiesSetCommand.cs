using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTTp")]
    public class TransitionPropertiesSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Style = 1 << 0,
            Selection = 1 << 1,
        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId Index { get; set; }
        public TStyle Style { get; set; }
        public TransitionLayer Selection { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) Index);
            cmd.AddUInt8((int) Style);
            cmd.AddUInt8((int) Selection);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            Index = (MixEffectBlockId) cmd.GetUInt8();
            Style = (TStyle) cmd.GetUInt8();
            Selection = (TransitionLayer) cmd.GetUInt8();
        }
    }
}