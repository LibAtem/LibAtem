using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;

namespace LibAtem.State.Builder
{
    internal static class MixEffectStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is ProgramInputGetCommand progCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) progCmd.Index, me => { 
                    me.Sources.Program = progCmd.Source;
                    result.SetSuccess($"MixEffects.{progCmd.Index}.Sources");
                });
            }
            else if (command is PreviewInputGetCommand prevCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MixEffects, (int) prevCmd.Index, me => { 
                    me.Sources.Preview = prevCmd.Source;
                    result.SetSuccess($"MixEffects.{prevCmd.Index}.Sources");
                });
            }
        }
    }
}