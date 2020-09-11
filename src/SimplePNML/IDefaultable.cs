using System;

namespace SimplePNML
{
    /// <summary>
    /// Encapsulates petri net elements that may be in default state
    /// </summary>
    public interface IDefaultable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsDefault();
    }

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
