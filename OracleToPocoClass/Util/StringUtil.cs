using System.Globalization;

namespace OracleToPocoClass.Util
{
    class StringUtil
    {
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
