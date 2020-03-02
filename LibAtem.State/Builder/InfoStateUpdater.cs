using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;

namespace LibAtem.State.Builder
{
    internal static class InfoStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is VersionCommand verCmd)
            {
                state.Info.Version = verCmd.ProtocolVersion;
                result.SetSuccess("Info.Version");
            }
            else if (command is TimecodeLockedCommand lockedCmd)
            {
                state.Info.TimecodeLocked = lockedCmd.Locked;
                result.SetSuccess("Info.TimecodeLocked");
            }
            else if (command is TimeCodeCommand timecodeCmd)
            {
                state.Info.LastTimecode = new Timecode
                {
                    Hour = timecodeCmd.Hour,
                    Minute = timecodeCmd.Minute,
                    Second = timecodeCmd.Second,
                    Frame = timecodeCmd.Frame,
                    DropFrame = timecodeCmd.IsDropFrame,
                };
                result.SetSuccess("Info.LastTimecode");
            }
            else if (command is ProductIdentifierCommand pidCmd)
            {
                state.Info.Model = pidCmd.Model;
                state.Info.ProductName = pidCmd.Name;
                result.SetSuccess("Info.Model");
            }
        }
    }
}