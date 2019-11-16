using System.Linq;
using LibAtem.Commands;

namespace LibAtem.State.Builder
{
    internal static class AuxStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is AuxSourceGetCommand sourceCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Auxiliaries, (int) sourceCmd.Id, aux =>
                {
                    aux.Source = sourceCmd.Source;
                    result.SetSuccess($"Auxiliaries.{sourceCmd.Id}");
                });
            }
        }
    }
}