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
                    UpdaterUtil.CopyAllProperties(colCmd, col, new []{"Index"});
                    result.SetSuccess($"ColorGenerators.{colCmd.Index:D}");
                });
            }
        }
    }
}