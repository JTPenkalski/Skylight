using System.Diagnostics.CodeAnalysis;

namespace Skylight.CLI.Commands
{
    public class Argument
    {
        /// <summary>
        /// If this argument is required for the command to execute or not.
        /// </summary>
        public required bool Required { get; init; }

        /// <summary>
        /// The short, single letter name that represents this argument.
        /// It will be used with a single hyphen '-' for execution.
        /// </summary>
        public required string ShortName { get; init; }

        /// <summary>
        /// The longer, multi-letter name that represents this argument.
        /// It will be used with a double hyphen '--' for execution.
        /// </summary>
        public required string LongName { get; init; }

        /// <summary>
        /// A brief description of this argument's purpose to the command.
        /// </summary>
        public required string Description { get; init; }

        /// <summary>
        /// The text to be displayed when help is requested for this argument.
        /// </summary>
        public string Help => $"{(Required ? "*" : " ")} -{ShortName}, --{LongName}: {Description}";

        [SetsRequiredMembers]
        public Argument(string shortName, string longName, string description, bool required)
        {
            ShortName = shortName;
            LongName = longName;
            Description = description;
            Required = required;
        }

        /// <summary>
        /// Creates a string representation of this argument.
        /// </summary>
        /// <returns>The summary of this argument.</returns>
        public override string ToString() => Required ? $"<{LongName}>" : $"[{LongName}]";
    }
}