using System.Globalization;

namespace Stutz.EF.OracleToPoco.Util
{
    /// <summary>
    /// <see cref="string"/> util.
    /// </summary>
    class StringUtil
    {
        /// <summary>
        /// To the pascal case.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns><see cref="string"/>.</returns>
        public static string ToPascalCase(string val)
        {
            val = val
                .ToLower()
                .Replace("_", " ")
            ;

            TextInfo pascal = new CultureInfo("en-US", false).TextInfo;

            return pascal
                .ToTitleCase(val)
                .Replace(" ", "")
            ;
        }
    }
}
