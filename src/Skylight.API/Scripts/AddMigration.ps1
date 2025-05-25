param (
	[Parameter(Mandatory=$true, HelpMessage="Enter the Migration name")]
    [string]$MigrationName
)

dotnet ef migrations add $MigrationName -s ..\..\Skylight.API\ -p ..\..\Skylight.Infrastructure\ -o Data\Migrations
