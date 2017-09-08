using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState
{
    public class Macro
    {
        public Macro() : this(0)
        {
        }

        public Macro(uint index)
        {
            Index = index;
            Operations = new List<MacroOperation>();    
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlElement("Op")]
        public List<MacroOperation> Operations { get; set; }
    }

    public static class MacroOperationExtensions
    {
        public static bool IsWait(this MacroOperation op)
        {
            return op.Id == MacroOperationType.MacroUserWait || op.Id == MacroOperationType.MacroSleep;
        }
    }

    public enum MacroInput
    {
        Black = 0,

        Camera1 = 1,
        Camera2 = 2,
        Camera3 = 3,
        Camera4 = 4,
        Camera5 = 5,
        Camera6 = 6,
        Camera7 = 7,
        Camera8 = 8,
        Camera9 = 9,
        Camera10 = 10,
        Camera11 = 11,
        Camera12 = 12,
        Camera13 = 13,
        Camera14 = 14,
        Camera15 = 15,
        Camera16 = 16,
        Camera17 = 17,
        Camera18 = 18,
        Camera19 = 19,
        Camera20 = 20,

        Color1 = 2001,
        Color2 = 2002,

        MediaPlayer1    = 3010,
        MediaPlayer1Key = 3011,
        MediaPlayer2    = 3020,
        MediaPlayer2Key = 3021,
        MediaPlayer3    = 3030,
        MediaPlayer3Key = 3031,
        MediaPlayer4    = 3040,
        MediaPlayer4Key = 3041,

        SuperSource = 6000,

        ME1Program = 10010,
        ME2Program = 10020,

        ExternalXLR = 20000,
    }

    public class MacroControl
    {
        [XmlAttribute("loop")]
        public AtemBool Loop { get; set; }
    }
}