using System.Collections.Generic;

namespace Skylight.CLI.Commands
{
    /// <summary>
    /// Describes the fundamental operations needed for a CLI command implementation. 
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The name of the command.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A brief description of the command's purpose.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The text to be displayed when help is requested for this command.
        /// </summary>
        string Help { get; }

        /// <summary>
        /// The set of all valid arguments to use with this command.
        /// </summary>
        ArgumentSet KnownArguments { get; }

        /// <summary>
        /// Executes the command with the given arguments.
        /// </summary>
        /// <param name="args">Optional arguments that modify the command's behavior.</param>
        void Execute(IReadOnlyDictionary<string, string?> args);

        /// <summary>
        /// Creates a string representation of this command.
        /// </summary>
        /// <returns>The summary of this command.</returns>
        string ToString();
    }
}