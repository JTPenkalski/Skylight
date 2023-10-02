namespace Skylight.Utilities
{
    /// <summary>
    /// Helper methods for Regular Expressions.
    /// </summary>
    public static class RegexUtilities
    {
        /// <summary>
        /// A Regex for integer values.
        /// </summary>
        public const string INTEGER_REGEX = @$"^(-?[1-9]\d*|0)$";

        /// <summary>
        /// A Regex for numeric values.
        /// </summary>
        public const string NUMBER_REGEX = @$"^(-?[1-9]\d*|0)(\.\d+)?$";
    }
}
