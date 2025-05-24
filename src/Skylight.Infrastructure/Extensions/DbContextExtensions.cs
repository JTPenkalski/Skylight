using Microsoft.EntityFrameworkCore;
using Skylight.Infrastructure.Identity.Roles;
using Skylight.Infrastructure.Identity.Users;

namespace Skylight.Infrastructure.Extensions;

/// <summary>
/// Extension methods for <see cref="DbContext"/>.
/// </summary>
public static class DbContextExtensions
{
	/// <summary>
	/// Configures table properties for Identity features.
	/// </summary>
	public static void ConfigureIdentity(this ModelBuilder builder)
	{
		builder.Entity<User>(b =>
		{
			// Primary Key
			b.HasKey(u => u.Id);

			// Indexes for "normalized" username and email, to allow efficient lookups
			b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("IX_UserName").IsUnique();
			b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("IX_Email");

			// Maps to the Users table
			b.ToTable("Users");

			// A concurrency token for use with the optimistic concurrency checking
			b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

			// Limit the size of columns to use efficient database types
			b.Property(u => u.UserName).HasMaxLength(256);
			b.Property(u => u.NormalizedUserName).HasMaxLength(256);
			b.Property(u => u.Email).HasMaxLength(256);
			b.Property(u => u.NormalizedEmail).HasMaxLength(256);

			// The relationships between User and other entity types
			// Note that these relationships are configured with no navigation properties

			// Each User can have many UserClaims
			b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

			// Each User can have many UserLogins
			b.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

			// Each User can have many UserTokens
			b.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

			// Each User can have many entries in the UserRole join table
			b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
		});

		builder.Entity<UserClaim>(b =>
		{
			// Primary Key
			b.HasKey(uc => uc.Id);

			// Maps to the UserClaims table
			b.ToTable("UserClaims");
		});

		builder.Entity<UserLogin>(b =>
		{
			// Composite Primary Key consisting of the LoginProvider and the key to use
			// with that provider
			b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

			// Limit the size of the composite key columns due to common DB restrictions
			b.Property(l => l.LoginProvider).HasMaxLength(128);
			b.Property(l => l.ProviderKey).HasMaxLength(128);

			// Maps to the UserLogins table
			b.ToTable("UserLogins");
		});

		builder.Entity<UserToken>(b =>
		{
			// Composite Primary Key consisting of the UserId, LoginProvider and Name
			b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

			// Limit the size of the composite key columns due to common DB restrictions
			b.Property(t => t.LoginProvider).HasMaxLength(256);
			b.Property(t => t.Name).HasMaxLength(256);

			// Maps to the UserTokens table
			b.ToTable("UserTokens");
		});

		builder.Entity<Role>(b =>
		{
			// Primary Key
			b.HasKey(r => r.Id);

			// Index for "normalized" role name to allow efficient lookups
			b.HasIndex(r => r.NormalizedName).HasDatabaseName("IX_RoleName").IsUnique();

			// Maps to the Roles table
			b.ToTable("Roles");

			// A concurrency token for use with the optimistic concurrency checking
			b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

			// Limit the size of columns to use efficient database types
			b.Property(u => u.Name).HasMaxLength(256);
			b.Property(u => u.NormalizedName).HasMaxLength(256);

			// The relationships between Role and other entity types
			// Note that these relationships are configured with no navigation properties

			// Each Role can have many entries in the UserRole join table
			b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

			// Each Role can have many associated RoleClaims
			b.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
		});

		builder.Entity<RoleClaim>(b =>
		{
			// Primary Key
			b.HasKey(rc => rc.Id);

			// Maps to the RoleClaims table
			b.ToTable("RoleClaims");
		});

		builder.Entity<UserRole>(b =>
		{
			// Primary Key
			b.HasKey(r => new { r.UserId, r.RoleId });

			// Maps to the UserRoles table
			b.ToTable("UserRoles");
		});
	}
}
