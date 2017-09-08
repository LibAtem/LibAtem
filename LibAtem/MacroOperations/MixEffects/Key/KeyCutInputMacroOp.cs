using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyCutInput, 12)]
    public class KeyCutInputMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(8), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand()
        {
            return new MixEffectKeyCutSourceSetCommand()
            {
                MixEffectIndex = Index,
                KeyerIndex = KeyIndex,
                CutSource = Source,
            };
        }
    }
}