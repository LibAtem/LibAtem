using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    [MacroOperation(MacroOperationType.KeyCutInput, 8)]
    public class KeyCutInputMacroOp : MixEffectKeyMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
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