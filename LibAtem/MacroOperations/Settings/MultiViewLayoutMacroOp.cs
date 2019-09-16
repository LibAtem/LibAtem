using System;
using LibAtem.Commands;
using LibAtem.Commands.Settings.Multiview;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Settings
{
    [MacroOperation(MacroOperationType.MultiViewLayout, 8)]
    public class MultiViewLayoutMacroOp : MacroOpBase
    {
        [Serialize(4), UInt8]
        [MacroField("MultiViewIndex")]
        public uint MultiViewIndex { get; set; }

        [Serialize(5), Enum8]
        [MacroField("Layout")]
        public MultiViewLayout Layout { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                if (!Enum.TryParse(Layout.ToString(), true, out MultiViewLayoutV8 layout))
                    layout = 0;

                return new MultiviewPropertiesSetV8Command
                {
                    Mask = MultiviewPropertiesSetV8Command.MaskFlags.Layout,
                    MultiviewIndex = MultiViewIndex,
                    Layout = layout,
                };
            }
            else
            {
                return new MultiviewPropertiesSetCommand
                {
                    Mask = MultiviewPropertiesSetCommand.MaskFlags.Layout,
                    MultiviewIndex = MultiViewIndex,
                    Layout = Layout,
                };
            }
        }
    }
}