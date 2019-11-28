using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace VideoAudioMerge
{
    public static class EnumExtensions
    {
        public static string ToText(this Enum enumeration)
        {
            MemberInfo[] memberInfoArr = enumeration.GetType().GetMember(enumeration.ToString());
            if (memberInfoArr.Length <= 0) return enumeration.ToString();

            object[] attributes = memberInfoArr[0].GetCustomAttributes(typeof(TextAttribute), false);
            return attributes.Length > 0 ? ((TextAttribute)attributes[0]).Text : enumeration.ToString();
        }
    }
}
