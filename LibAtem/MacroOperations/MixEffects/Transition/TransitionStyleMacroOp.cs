using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionStyle, 8)]
    public class TransitionStyleMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("TransitionStyle", "style")]
        public TStyle Style { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionPropertiesSetCommand()
            {
                Mask = TransitionPropertiesSetCommand.MaskFlags.Style,
                Index = Index,
                Style = Style,
            };
        }
    }
}