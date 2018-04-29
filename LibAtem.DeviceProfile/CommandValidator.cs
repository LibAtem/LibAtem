using LibAtem.Commands;
using LibAtem.Serialization;

namespace LibAtem.DeviceProfile
{
    public static class CommandValidator
    {
        public static bool IsValid(DeviceProfile profile, ICommand cmd)
        {
            if (!(cmd is AutoSerializeBase asbCmd))
                return true;

            var props = AutoSerializeBase.GetPropertySpecForType(asbCmd.GetType());

            foreach (AutoSerializeBase.PropertySpec prop in props.Properties)
            {
                if (prop.Getter == null)
                    continue;

                object val = prop.Getter.DynamicInvoke(cmd);
                if (!prop.SerAttr.IsValid(prop.PropInfo, val) || !AvailabilityChecker.IsAvailable(profile, val))
                    return false;
            }

            return true;
        }
    }
}