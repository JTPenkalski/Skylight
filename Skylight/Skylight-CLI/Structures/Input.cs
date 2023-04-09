using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Skylight.CLI.Structures
{
    public class Input
    {
        /// <summary>
        /// The raw text input into the Console.
        /// </summary>
        public required string Text { get; init; }

        /// <summary>
        /// The name of the command to execute.
        /// </summary>
        public string Command { get; init; }

        /// <summary>
        /// The set of unique arguments supplied for the command.
        /// </summary>
        public IReadOnlyCollection<string> Arguments { get; init; }

        [SetsRequiredMembers]
        public Input(string? input)
        {
            string[] splitInput = input?.Split(' ', 2) ?? new string[] { string.Empty };

            Text = input ?? string.Empty;
            Command = splitInput[0];
            Arguments = ParseArguments(splitInput.Length == 2 ? splitInput[1] : string.Empty);
        }

        /// <summary>
        /// Parses the individual arguments from the raw input string.
        /// </summary>
        /// <param name="argumentsList">The potential list of arguments from the raw input string to parse from.</param>
        /// <returns>A set of unique argument strings.</returns>
        private static IReadOnlyCollection<string> ParseArguments(string argumentsList)
        {
            ISet<string> arguments = new HashSet<string>();

            argumentsList.Split(' ').ToList().ForEach(arg => arguments.Add(arg));

            return (IReadOnlyCollection<string>)arguments;
        }
    }
}