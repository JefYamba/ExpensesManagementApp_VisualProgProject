using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExBudget.Utils
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T ToEnum<T>(string enumStringValue)
        {
            return (T)Enum.Parse(typeof(T), enumStringValue);
        }

        public static T ToEnum<T>(int index)
        {
            return (T)Enum.GetValues(typeof(T)).GetValue(index);
        }
    }
}
