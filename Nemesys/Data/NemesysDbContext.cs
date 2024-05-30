using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nemesys.Models.Domain;

namespace Nemesys.Data
{
    public class NemesysDbContext : IdentityDbContext
    {
        public NemesysDbContext(DbContextOptions<NemesysDbContext> options) : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ReportLike> ReportLike { get; set; }

		public DbSet<ReportInvestigation> ReportInvestigation { get; set; }

        public DbSet<Status> ReprotStatus { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles (Reporter, Investigator, SuperInvestigator)

            var investigatorRoleID = "9e285ddf-792d-4597-a649-e03a4c8fb03f";
            var superInvestigatorRoleId = "4fd88b4f-3fa3-49c9-a141-c3cb76a55eb1";
            var reporterRoleId = "ad7284c2-3da1-40be-be6f-9a353751b79d";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="Investigator",
                    NormalizedName = "Investigator",
                    Id = investigatorRoleID,
                    ConcurrencyStamp= investigatorRoleID
                },
                new IdentityRole
                {
                    Name = "SuperInvestigator",
                    NormalizedName = "SuperInvestigator",
                    Id = superInvestigatorRoleId,
                    ConcurrencyStamp= superInvestigatorRoleId

                },
                new IdentityRole
                {
                    Name = "Reporter",
                    NormalizedName = "Reporter",
                    Id = reporterRoleId,
                    ConcurrencyStamp= reporterRoleId
                }

            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed superInvestigator
            var superInvestigatorId = "a2ef1044-d4ad-4933-881f-840f734f6fa5";
            var superInvestigatorUser = new IdentityUser
            {
                UserName = "superinvestigator@gmail.com",
                Email = "superinvestigator@gmail.com",
                NormalizedEmail = "superinvestigator@gmail.com".ToUpper(),
                NormalizedUserName = "superinvestigator@gmail.com".ToUpper(),
                Id = superInvestigatorId
            };

            superInvestigatorUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superInvestigatorUser, "SuperInvestigator@123");


            builder.Entity<IdentityUser>().HasData(superInvestigatorUser);
            //Add All roles to SuperIvestigator
            var superInvestigatorRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = investigatorRoleID,
                    UserId = superInvestigatorId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superInvestigatorRoleId,
                    UserId = superInvestigatorId
                },
                new IdentityUserRole<string>
                {
                    RoleId = reporterRoleId,
                    UserId = superInvestigatorId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superInvestigatorRoles);

            builder.Entity<Status>().HasData(
                new Status()
                {
                    Id = 1,
                    Name = "Open"
                },
                new Status()
                {
                    Id = 2,
                    Name = "Being Investigated"
                },
                new Status()
                {
                    Id = 3,
                    Name = "Closed"
                },
				new Status()
				{
					Id = 4,
					Name = "No Action Needed"
				}
			);
        }
    }
}
