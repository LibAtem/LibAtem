using System;
using System.Linq;
using LibAtem.Common;
namespace LibAtem.XmlState
{
    public static class MacroInputExtensions
    {
        public static MacroInput ToMacroInput(this VideoSource src)
        {
            // TODO - block some cases?
            return (MacroInput) src;
        }

        public static VideoSource ToVideoSource(this MacroInput src)
        {
            // TODO - block some cases?
            return (VideoSource)src;
        }
    }
}
