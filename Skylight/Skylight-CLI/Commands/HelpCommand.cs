using System.Collections.Generic;
using System.Linq;

namespace Skylight.CLI.Commands
{
    public class HelpCommand : BaseCommand
    {
        public override string Description => "Displays help text for each known command.";

        public HelpCommand()
        {
            KnownArguments.Create(
                new Argument("c", "command", "The specific command to display help for.", false)
            );
        }

        public override void Execute(IReadOnlyDictionary<string, string?> args)
        {
            if (!Validate(args))
                return;

            Program.ExecutionState = Program.State.Exiting;
        }

        protected override bool Validate(IReadOnlyDictionary<string, string?> args)
        {
            bool valid = ValidateArgumentCount(1, args.Count);

            

            return valid;
        }
    }
}
