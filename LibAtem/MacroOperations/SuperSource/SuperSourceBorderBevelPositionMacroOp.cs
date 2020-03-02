﻿using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderBevelPosition, 8)]
    public class SuperSourceBorderBevelPositionMacroOp : MacroOpBase
    {
        [Serialize(4), UInt8Range(0, 100)]
        [MacroField("BevelPosition")]
        public uint BevelPosition { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.BevelPosition,
                    SSrcId = SuperSourceId.One,
                    BevelPosition = BevelPosition,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderBevelPosition,
                    BorderBevelPosition = BevelPosition,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderBevelPosition, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2BorderBevelPositionMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("BevelPosition")]
        public uint BevelPosition { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.BevelPosition,
                SSrcId = SSrcId,
                BevelPosition = BevelPosition,
            };
        }
    }
}