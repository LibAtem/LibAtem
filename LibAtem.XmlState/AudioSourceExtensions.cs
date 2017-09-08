using LibAtem.Common;

namespace LibAtem.XmlState
{
    public static class AudioSourceExtensions
    {

        public static MacroInput ToMacroInput(this AudioSource src)
        {
            // TODO - block some cases?
            return (MacroInput)src;
        }

        public static AudioSource ToAudioSource(this MacroInput src)
        {
            // TODO - block some cases?
            return (AudioSource)src;
        }
    }
}