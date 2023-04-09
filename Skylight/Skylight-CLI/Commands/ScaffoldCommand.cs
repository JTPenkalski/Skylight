using System.Collections.Generic;

namespace Skylight.CLI.Commands
{
    public class ScaffoldCommand : BaseCommand
    {
        public override string Description => "Scaffolds the necessary infrastructure for a specified Core model.";

        public ScaffoldCommand()
        {
            KnownArguments.Create(
                new Argument("m", "model", "The Core model to scaffold the files for.", true)
            );
        }

        public override void Execute(IReadOnlyDictionary<string, string?> args)
        {
            // 1) Validate the arguments.
            if (!Validate(args))
                return;

            // 2) Validate that all template files exist.


            // 3) Create a new file for each template and fill in the required variables.


        }

        protected override bool Validate(IReadOnlyDictionary<string, string?> args)
        {
            return true;
        }
    }
}