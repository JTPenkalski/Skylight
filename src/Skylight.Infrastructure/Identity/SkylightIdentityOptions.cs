namespace Skylight.Infrastructure.Identity;

public class SkylightIdentityOptions
{
	public const string RootKey = "Identity";

	#region General

	public bool InvokeHandlersAfterFailure { get; set; }

	#endregion

	#region User

	public bool UserRequireUniqueEmail { get; set; }

	#endregion

	#region Password

	public int PasswordRequiredLength { get; set; }

	public bool RequireNonAlphanumeric { get; set; }

	public bool RequireUppercase { get; set; }

	public bool RequireDigit { get; set; }

	#endregion

	#region Lockout

	public bool LockoutAllowedForNewUsers { get; set; }

	public int LockoutMaxFailedAccessAttempts { get; set; }

	#endregion
}
