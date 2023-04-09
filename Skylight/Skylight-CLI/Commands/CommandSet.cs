using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skylight.CLI.Commands
{
    public class CommandSet
    {
        private readonly IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        /// <summary>
        /// The text to be displayed when help is requested for this command set.
        /// </summary>
        public string Help
        {
            get
            {
                var output = new StringBuilder();

                commands.Values.ToList().ForEach(c => output.AppendLine($"\t{c.Help} "));

                return output.ToString().Trim();
            }
        }

        /// <summary>
        /// The collection of all commands in this set.
        /// </summary>
        public IReadOnlyDictionary<string, ICommand> Commands => (IReadOnlyDictionary<string, ICommand>)commands;

        /// <summary>
        /// Retrieves a specific command from this set by its name.
        /// </summary>
        /// <param name="name">The name of the command to get.</param>
        /// <returns>The command instance, if it exists, null otherwise.</returns>
        public ICommand? this[string name] => commands.TryGetValue(name, out ICommand? command) ? command : null;

        /// <summary>
        /// Checks if the command set contains a specific command by name.
        /// </summary>
        /// <param name="name">The name of the command to check.</param>
        /// <returns>If the command exists for this command or not.</returns>
        public bool Contains(string name) => commands.ContainsKey(name);

        /// <summary>
        /// Builds a command set from an arbitrary list of commands.
        /// </summary>
        /// <param name="commands">A list of commands to recognize.</param>
        /// <returns>The newly formed command set.</returns>
        public static CommandSet Create(params ICommand[] commands)
        {
            var commandSet = new CommandSet();

            commands.ToList().ForEach(commandSet.AddCommand);

            return commandSet;
        }

        /// <summary>
        /// Adds a command to the set.
        /// </summary>
        /// <param name="arg">The command to add.</param>
        public void AddCommand(ICommand command) => commands.Add(command.Name, command);

        /// <summary>
        /// Removes a command from the set.
        /// </summary>
        /// <param name="arg">The command to remove.</param>
        public void RemoveCommand(ICommand command) => commands.Remove(command.Name);

        /// <summary>
        /// Returns a friendly display string for the help text of all the commands in the set.
        /// </summary>
        /// <returns>A formatted string with the help text of all the commands.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            commands.Values.ToList().ForEach(arg => output.Append($"{arg} "));

            return output.ToString().Trim();
        }
    }
}