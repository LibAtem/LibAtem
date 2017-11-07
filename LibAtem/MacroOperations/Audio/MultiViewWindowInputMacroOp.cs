using LibAtem.Commands;
using LibAtem.Commands.Settings.Multiview;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.MultiViewWindowInput, 8)]
    public class MultiViewWindowInputMacroOp : MacroOpBase
    {
        [Serialize(4), UInt8]
        [MacroField("MultiViewIndex")]
        public uint MultiViewIndex { get; set; }

        [Serialize(5), UInt8]
        [MacroField("WindowIndex")]
        public uint WindowIndex { get; set; }

        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand()
        {
            return new MultiviewWindowInputSetCommand
            {
                MultiviewIndex = MultiViewIndex,
                WindowIndex = WindowIndex,
                Source = Source,
            };
        }
    }
}