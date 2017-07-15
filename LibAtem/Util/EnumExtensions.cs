using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LibAtem.Util
{
    public static class EnumExtensions
    {
        public static bool IsValid<T>(this T src) where T: IComparable, IConvertible, IFormattable
        {
            if (!typeof(T).GetTypeInfo().GetCustomAttributes<FlagsAttribute>().Any())
                return Enum.IsDefined(typeof(T), src);

            // Is a flags, handle seperately
            return Convert.ToInt32(src) < Enum.GetValues(typeof(T)).Cast<int>().Max() * 2;

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
            MemberInfo[] memInfo = type.GetMember(src.ToString());
            IEnumerable<Attribute> attributes = memInfo[0].GetCustomAttributes(typeof(T), false);

            return attributes.FirstOrDefault() as T;
        }
    }
}
