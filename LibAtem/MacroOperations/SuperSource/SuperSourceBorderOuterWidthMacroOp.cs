﻿using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderOuterWidth, 8)]
    public class SuperSourceBorderOuterWidthMacroOp : MacroOpBase
    {
        [Serialize(4), UInt32D(65536, 0, 16 * 65536)]
        [MacroField("OuterWidth")]
        public double OuterWidth { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.OuterWidth,
                    SSrcId = SuperSourceId.One,
                    OuterWidth = OuterWidth,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderOuterWidth,
                    BorderOuterWidth = OuterWidth,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderOuterWidth, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BorderOuterWidthMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt32D(65536, 0, 16 * 65536)]
        [MacroField("OuterWidth")]
        public double OuterWidth { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.OuterWidth,
                SSrcId = SSrcId,
                OuterWidth = OuterWidth,
            };
        }
    }
}