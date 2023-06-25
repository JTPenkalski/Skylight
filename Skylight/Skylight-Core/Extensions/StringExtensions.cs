using System;
using System.Linq;

namespace Skylight.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string is contained within set of potential specified values.
        /// Case insensitive.
        /// </summary>
        /// <param name="text">The source string to search for.</param>
        /// <param name="values">The list of potential values.</param>
        /// <returns>True if the string is contained within the specified values, false otherwise.</returns>
        public static bool OneOf(this string text, params string[] values)
        {
            return values.Any(x => x.Equals(text, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}