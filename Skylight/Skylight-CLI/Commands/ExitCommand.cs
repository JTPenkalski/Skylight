using System.Collections.Generic;

namespace Skylight.CLI.Commands
{
    public class ExitCommand : BaseCommand
    {
        public override string Description => "Terminates the CLI instance.";

        public override void Execute(IReadOnlyDictionary<string, string?> args)
        {
            if (!Validate(args))
                return;

            Program.ExecutionState = Program.State.Exiting;
        }

        protected override bool Validate(IReadOnlyDictionary<string, string?> args)
        {
            return true;
        }
    }
}