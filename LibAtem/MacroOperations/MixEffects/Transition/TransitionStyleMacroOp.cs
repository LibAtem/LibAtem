using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionStyle, 8)]
    public class TransitionStyleMacroOp : MixEffectMacroOpBase
    {
        [Serialize(5), Enum8]
        [MacroField("TransitionStyle", "style")]
        public TransitionStyle Style { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionPropertiesSetCommand()
            {
                Mask = TransitionPropertiesSetCommand.MaskFlags.NextStyle,
                Index = Index,
                NextStyle = Style,
            };
        }
    }
}