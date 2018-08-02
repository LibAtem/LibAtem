using LibAtem.Commands;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.SuperSource
{
    [MacroOperation(MacroOperationType.SuperSourceArtClip, 8)]
    public class SuperSourceArtClipMacroOp : MacroOpBase
    {
        [Serialize(4), UInt16D(65536, 0, 65536)]
        [MacroField("Clip")]
        public double Clip { get; set; }

        public override ICommand ToCommand()
        {
            return new SuperSourcePropertiesSetCommand()
            {
                Mask = SuperSourcePropertiesSetCommand.MaskFlags.ArtClip,
                ArtClip = Clip,
            };
        }
    }
}