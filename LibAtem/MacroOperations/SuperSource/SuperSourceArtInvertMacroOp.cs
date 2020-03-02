﻿using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceArtInvert, 8)]
    public class SuperSourceArtInvertMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Invert")]
        public bool Invert { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            if (version >= ProtocolVersion.V8_0)
            {
                return new SuperSourcePropertiesSetV8Command()
                {
                    Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtInvertKey,
                    SSrcId = SuperSourceId.One,
                    ArtInvertKey = Invert,
                };
            }
            else
            {
                return new SuperSourcePropertiesSetCommand()
                {
                    Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtInvertKey,
                    ArtInvertKey = Invert,
                };
            }
        }
    }

    [MacroOperation(MacroOperationType.SuperSourceV2ArtInvert, ProtocolVersion.V8_0, 8)]
    public class SuperSourceV2ArtInvertMacroOp : SuperSourceMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Invert")]
        public bool Invert { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new SuperSourcePropertiesSetV8Command()
            {
                Mask = SuperSourcePropertiesSetV8Command.MaskFlags.ArtInvertKey,
                SSrcId = SSrcId,
                ArtInvertKey = Invert,
            };
        }
    }
}