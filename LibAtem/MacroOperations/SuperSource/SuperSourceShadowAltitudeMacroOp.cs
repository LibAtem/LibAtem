﻿using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceShadowAltitude, 8)]
    public class SuperSourceShadowAltitudeMacroOp : MacroOpBase
    {
        [Serialize(4), UInt16Range(10, 100)]
        [MacroField("Altitude")]
        public uint Altitude { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourceBorderSetCommand()
                {
                    Mask = SuperSourceBorderSetCommand.MaskFlags.LightSourceAltitude,
                    SSrcId = SuperSourceId.One,
                    LightSourceAltitude = Altitude,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.BorderLightSourceAltitude,
                    BorderLightSourceAltitude = Altitude,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ShadowAltitude, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2ShadowAltitudeMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), UInt16Range(10, 100)]
        [MacroField("Altitude")]
        public uint Altitude { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourceBorderSetCommand()
            {
                Mask = SuperSourceBorderSetCommand.MaskFlags.LightSourceAltitude,
                SSrcId = SSrcId,
                LightSourceAltitude = Altitude,
            };
        }
    }
}