﻿using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderLuminescence, 8)]
    public class SuperSourceBorderLuminescenceMacroOp : MacroOpBase
    {
        [Serialize(4), UInt32DScale]
        [MacroField("Luma")]
        public double Luma { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.Luma,
                    SSrcId = SuperSourceId.One,
                    Luma = Luma,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderLuma,
                    BorderLuma = Luma,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderLuminescence, ProtocolVersion.V8_0, 12)]
    public class SuperSourceV2BorderLuminescenceMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(8), UInt32DScale]
        [MacroField("Luma")]
        public double Luma { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.Luma,
                SSrcId = SSrcId,
                Luma = Luma,
            };
        }
    }
}