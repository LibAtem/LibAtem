using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionDVEPattern, 8)]
    public class TransitionDVEPatternMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("Pattern")]
        public DVEEffect Pattern { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionDVESetCommand()
            {
                Mask = TransitionDVESetCommand.MaskFlags.Style,
                Index = Index,
                Style = Pattern,
            };
        }
    }
}