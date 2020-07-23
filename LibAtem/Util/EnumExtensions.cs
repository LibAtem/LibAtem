using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace LibAtem.Util
{
    public static class EnumExtensions
    {
        public static bool IsValid<T>(this T src) where T: IComparable, IConvertible, IFormattable
        {
            return src.IsValid(typeof(T));
        }

        public static bool IsValid(this object src, Type t)
        {
            if (!t.GetTypeInfo().GetCustomAttributes<FlagsAttribute>().Any())
                return Enum.IsDefined(t, src);

            // Is a flags, handle seperately
            int ival = Convert.ToInt32(src);
            if (ival == 0 && !Enum.IsDefined(t, 0))
                return false;

            return ival < Enum.GetValues(t).Cast<int>().Max() * 2;
        }

        public static T GetAttribute<Te, T>(this Te src) where T : Attribute where Te : IConvertible
        {
            var attr = src.GetPossibleAttribute<Te, T>();
            if (attr == null)
                throw new Exception(string.Format("Missing {1} on {0}", src, typeof(T).Name));

            return attr;
        }

        public static T GetPossibleAttribute<Te, T>(this Te src) where T : Attribute where Te : IConvertible
        {
            Type type = src.GetType();
            MemberInfo[] memInfo = type.GetMember(src.ToString(CultureInfo.InvariantCulture));

            return memInfo[0].GetCustomAttributes(typeof(T), false).OfType<T>().FirstOrDefault();
        }
        public static List<T> FindFlagComponents<T>(this T value) where T : Enum
        {
            return Enum.GetValues(typeof(T)).OfType<T>().Where(v => value.HasFlag(v) && Convert.ToInt32(v) != 0)
                .ToList();
        }

        public static T CombineFlagComponents<T>(this IEnumerable<T> input) where T : Enum
        {
            return (T) Enum.ToObject(typeof(T), input.Select(v => Convert.ToInt32(v)).Sum());
        }
    }
}
