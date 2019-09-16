using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionDVEFillInput, 8)]
    public class TransitionDVEFillInputMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Input { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionDVESetCommand
            {
                Mask = TransitionDVESetCommand.MaskFlags.FillSource,
                Index = Index,
                FillSource = Input,
            };
        }
    }
}