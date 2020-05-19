using System;

namespace SimplePNML
{
    internal static class DefaultExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return value.Length == 0;
        }

        public static bool IsDefault(this Enum value)
        {
            return Convert.ToInt32(value) == 0;
        }
    }
}
