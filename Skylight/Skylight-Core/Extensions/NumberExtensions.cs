using System.Linq;

namespace Skylight.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Checks if an integer is contained within set of potential specified values.
        /// </summary>
        /// <param name="number">The source integer to search for.</param>
        /// <param name="values">The list of potential values.</param>
        /// <returns>True if the integer is contained within the specified values, false otherwise.</returns>
        public static bool OneOf(this int number, params int[] values)
        {
            return values.Any(x => x == number);
        }
    }
}
