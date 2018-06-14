using LibAtem.Commands;
using LibAtem.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.DeviceProfile
{
    public static class CommandValidator
    {
        public static bool IsValid(DeviceProfile profile, ICommand cmd)
        {
            return Validate(profile, cmd, true).Count == 0;
        }

        public static IReadOnlyList<string> Validate(DeviceProfile profile, ICommand cmd, bool failOnFirst=false)
        {
            var res = new List<string>();

            if (!(cmd is AutoSerializeBase asbCmd))
                return res;

            var props = AutoSerializeBase.GetPropertySpecForType(asbCmd.GetType());
            List<string> propNamesToCheck = null;

            // If there is a mask, only validate the ones specified by the mask
            AutoSerializeBase.PropertySpec maskProp = props.Properties.Where(p => p.PropInfo.Name == "Mask").FirstOrDefault();
            if (maskProp != null)
            {
                // Only check fields which are indicated by the mask
                propNamesToCheck = maskProp.Getter.DynamicInvoke(cmd).ToString()
                    .Split(',').Select(s => s.Trim()).Concat(new[] { "Mask" }).ToList();
            }

            foreach (AutoSerializeBase.PropertySpec prop in props.Properties)
            {
                if (prop.Getter == null)
                    continue;

                // If prop is not to check and not commandId then skip
                if (!prop.IsCommandId && propNamesToCheck != null && !propNamesToCheck.Contains(prop.PropInfo.Name))
                    continue;

                object val = prop.Getter.DynamicInvoke(cmd);
                if (!prop.SerAttr.IsValid(prop.PropInfo, val) || !AvailabilityChecker.IsAvailable(profile, val))
                {
                    res.Add("Invalid value: " + asbCmd.GetType().FullName + "." + prop.PropInfo.Name + ": " + val);

                    if (failOnFirst)
                        return res;
                }
            }

            return res;
        }
    }
}