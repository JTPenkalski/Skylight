using System;
using System.Collections.Generic;

namespace Skylight.CLI.Commands
{
    /// <summary>
    /// Represents the shared behavior of all CLI commands.
    /// Primarily used for ensuring all default behavior and common functionality is consolidated.
    /// </summary>
    public abstract class BaseCommand : ICommand, IEquatable<ICommand>
    {
        /// <inheritdoc cref="ICommand.Name"/>
        public virtual string Name => GetType().Name.Replace("Command", string.Empty).ToLower();

        /// <inheritdoc cref="ICommand.Description"/>
        public virtual string Description => $"The {Name} command.";

        /// <inheritdoc cref="ICommand.Help"/>
        public virtual string Help => $"{Name}: {Description}\n{KnownArguments.Help}";

        /// <inheritdoc cref="ICommand.KnownArguments"/>
        public ArgumentSet KnownArguments { get; } = new ArgumentSet();

        /// <inheritdoc cref="ICommand.Execute"/>
        public abstract void Execute(IReadOnlyDictionary<string, string?> args);

        /// <inheritdoc cref="ICommand.ToString"/>
        public override string ToString() => $"{Name} {KnownArguments}";

        public bool Equals(ICommand? other) => other is not null && Name == other.Name;

        public override bool Equals(object? obj) => Equals(obj as ICommand);

        public override int GetHashCode() => HashCode.Combine(Name);

        /// <summary>
        /// Validates the command prior to execution.
        /// </summary>
        /// <returns>If the command is valid or not.</returns>
        protected abstract bool Validate(IReadOnlyDictionary<string, string?> args);

        /// <summary>
        /// Logs a message to the Console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        protected void Log(string message)
        {
            Console.WriteLine($"[{Name}]: {message}");
        }

        /// <summary>
        /// Logs an error message to the Console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        protected void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{Name}]: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        #region Validators
        protected bool ValidateArgumentCount(int expected, int actual)
        {
            bool valid = true;

            if (actual != expected)
            {
                Error($"Expected {expected} argument, but recieved {actual}.");
                valid = false;
            }

            return valid;
        }

        protected bool ValidateArgumentsKnown(IReadOnlyDictionary<string, string?> args)
        {
            bool valid = true;

            

            return valid;
        }
        #endregion
    }
}
