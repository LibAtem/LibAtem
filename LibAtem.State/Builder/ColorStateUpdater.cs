using System.Linq;
using LibAtem.Commands;

namespace LibAtem.State.Builder
{
    internal static class ColorStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is ColorGeneratorGetCommand colCmd)
            {
                UpdaterUtil.TryForIndex(result, state.ColorGenerators, (int)colCmd.Index, col =>
                {
                    col.Hue = colCmd.Hue;
                    col.Luma = colCmd.Luma;
                    col.Saturation = colCmd.Saturation;
                    result.SetSuccess($"ColorGenerators.{colCmd.Index}");
                });
            }
        }
    }
}