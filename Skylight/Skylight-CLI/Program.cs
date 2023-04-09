using Skylight.CLI.Commands;
using Skylight.CLI.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skylight.CLI
{
    public class Program
    {
        public enum State
        {
            Waiting,
            Executing,
            Exiting
        }

        public const string VERSION = "1.0.0";
        private const string WELCOME = "Skylight CLI successfully started...";
        private const string GOODBYE = "Skylight CLI successfully terminated.";
        private const string CLOSE = "Press any button to close this console...";
        private const string INVALID_COMMAND = "'{0}' is an invalid command. Please try another command or type 'help' for more information.";

        public static State ExecutionState { get; set; } = State.Waiting;
        public static readonly CommandSet KnownCommands = CommandSet.Create(
            new ScaffoldCommand(),
            new ExitCommand()
        );

        public static void Main(string[] args)
        {
            Console.WriteLine($"Skylight CLI v{VERSION}\n{WELCOME}\n");

            while (ExecutionState != State.Exiting)
            {
                ExecutionState = State.Waiting;

                var input = new Input(Console.ReadLine());

                if (KnownCommands.Contains(input.Command))
                {
                    ExecutionState = State.Executing;

                    KnownCommands[input.Command]!.Execute(ParseArguments(input.Arguments));
                }
                else
                {
                    if (!string.IsNullOrEmpty(input.Text.Trim()))
                    {
                        Console.Write(string.Format(INVALID_COMMAND, input.Command));
                    }
                }
            }

            Console.WriteLine($"{GOODBYE}\n{CLOSE}\n");
        }

        private static IReadOnlyDictionary<string, string?> ParseArguments(IReadOnlyCollection<string> rawArguments)
        {
            IDictionary<string, string?> arguments = new Dictionary<string, string?>();

            // TODO: Parse into short and long arguments?

            rawArguments.ToList().ForEach(arg =>
            {
                string[] keyValue = arg.Split('=', 2);

                string key = keyValue[0];
                string value = keyValue.Length == 2 ? keyValue[1] : string.Empty;

                arguments.Add(key, value);
            });

            return (IReadOnlyDictionary<string, string?>)arguments;
        }
    }
}