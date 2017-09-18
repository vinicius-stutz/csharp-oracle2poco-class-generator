// <copyright file="StringUtil.cs" company="Vinicius de Araujo Stutz">
// Copyright (c) Vinicius de Araujo Stutz. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Stutz.EF.OracleToPoco.Util
{
    using System.Globalization;

    /// <summary>
    /// <see cref="string"/> utils class.
    /// </summary>
    internal class StringUtil
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
                .Replace("_", " ");

            TextInfo pascal = new CultureInfo("en-US", false).TextInfo;

            return pascal
                .ToTitleCase(val)
                .Replace(" ", string.Empty);
        }
    }
}
