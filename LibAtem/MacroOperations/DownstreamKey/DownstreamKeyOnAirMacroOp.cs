using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.DownStreamKey
{
    [MacroOperation(MacroOperationType.DownstreamKeyOnAir, 8)]
    public class DownstreamKeyOnAirMacroOp : DownstreamKeyMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("OnAir")]
        public bool OnAir { get; set; }

        public override ICommand ToCommand()
        {
            return new DownstreamKeyOnAirSetCommand()
            {
                Index = (DownstreamKeyId) KeyIndex,
                OnAir = OnAir,
            };
        }
    }
}