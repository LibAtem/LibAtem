﻿using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceBorderOuterSoftness, 8)]
    public class SuperSourceBorderOuterSoftnessMacroOp : MacroOpBase
    {
        [Serialize(4), UInt8Range(0, 100)]
        [MacroField("OuterSoftness")]
        public uint OuterSoftness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.OuterSoftness,
                    SSrcId = SuperSourceId.One,
                    OuterSoftness = OuterSoftness,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderOuterSoftness,
                    BorderOuterSoftness = OuterSoftness,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2BorderOuterSoftness, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2BorderOuterSoftnessMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 100)]
        [MacroField("OuterSoftness")]
        public uint OuterSoftness { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.OuterSoftness,
                SSrcId = SSrcId,
                OuterSoftness = OuterSoftness,
            };
        }
    }
}