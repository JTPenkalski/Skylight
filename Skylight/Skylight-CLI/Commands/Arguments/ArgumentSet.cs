using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skylight.CLI.Commands
{
    public class ArgumentSet
    {
        private readonly IDictionary<string, Argument> arguments = new Dictionary<string, Argument>();

        /// <summary>
        /// The default argument to use when executing this command.
        /// A default argument does not require hypens to used.
        /// </summary>
        public Argument? DefaultArgument { get; set; }

        /// <summary>
        /// The text to be displayed when help is requested for this argument set.
        /// </summary>
        public string Help
        {
            get
            {
                var output = new StringBuilder();

                arguments.Values.ToList().ForEach(arg => output.AppendLine($"\t{arg.Help} "));

                return output.ToString().Trim();
            }
        }

        /// <summary>
        /// The collection of all arguments in this set.
        /// </summary>
        public IReadOnlyDictionary<string, Argument> Arguments => (IReadOnlyDictionary<string, Argument>)arguments;

        /// <summary>
        /// Retrieves a specific argument from this set by its short name.
        /// </summary>
        /// <param name="shortName">The short name of the argument to get.</param>
        /// <returns>The argument instance, if it exists, null otherwise.</returns>
        public Argument? this[string shortName] => arguments.TryGetValue(shortName, out Argument? arg) ? arg : null;

        /// <summary>
        /// Builds an Argument Set from an arbitrary list of arguments.
        /// </summary>
        /// <param name="arguments">A list of Commands to recognize.</param>
        public void Create(params Argument[] arguments)
        {
            arguments.ToList().ForEach(this.AddArgument);
        }

        /// <summary>
        /// Checks if the argument set contains a specific argument by short name.
        /// </summary>
        /// <param name="shortName">The short name of the argument to check.</param>
        /// <returns>If the argument exists for this command or not.</returns>
        public bool Contains(string shortName) => arguments.ContainsKey(shortName);

        /// <summary>
        /// Adds an argument to the set.
        /// </summary>
        /// <param name="arg">The argument to add.</param>
        public void AddArgument(Argument arg) => arguments.Add(arg.ShortName, arg);

        /// <summary>
        /// Removes an argument from the set.
        /// </summary>
        /// <param name="arg">The argument to remove.</param>
        public void RemoveArgument(Argument arg) => arguments.Remove(arg.ShortName);

        /// <summary>
        /// Returns a friendly display string for the help text of all the arguments in the set.
        /// </summary>
        /// <returns>A formatted string with the help text of all the arguments.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            arguments.Values.ToList().ForEach(arg => output.Append($"{arg} "));

            return output.ToString().Trim();
        }
    }
}