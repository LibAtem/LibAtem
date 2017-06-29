using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TrSS")]
    public class TransitionPropertiesGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public TStyle Style { get; set; }
        public TransitionLayer Selection { get; set; }
        public TStyle NextStyle { get; set; }
        public TransitionLayer NextSelection { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Index);
            cmd.AddUInt8((int) Style);
            cmd.AddUInt8((int) Selection);
            cmd.AddUInt8((int) NextStyle);
            cmd.AddUInt8((int) NextSelection);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            Style = (TStyle) cmd.GetUInt8();
            Selection = (TransitionLayer) cmd.GetUInt8();
            NextStyle = (TStyle) cmd.GetUInt8();
            NextSelection = (TransitionLayer) cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}