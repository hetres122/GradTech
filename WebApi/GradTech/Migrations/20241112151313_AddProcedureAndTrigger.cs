using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradTech.Migrations
{
    /// <inheritdoc />
    public partial class AddProcedureAndTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                      migrationBuilder.Sql(@"
                CREATE PROCEDURE SyncAspNetUsersToApplicationUsers
                AS
                BEGIN
                    MERGE INTO GradTech.dbo.ApplicationUser AS Target
                    USING AuthServiceDb.dbo.AspNetUsers AS Source
                    ON Target.Id = Source.Id
                    WHEN MATCHED THEN
                        UPDATE SET
                            Target.Id = Source.Id,
                            Target.UserName = Source.UserName,
                            Target.NormalizedUserName = Source.NormalizedUserName,
                            Target.Email = Source.Email,
                            Target.EmailConfirmed = Source.EmailConfirmed,
                            Target.PasswordHash = Source.PasswordHash,
                            Target.SecurityStamp = Source.SecurityStamp,
                            Target.ConcurrencyStamp = Source.ConcurrencyStamp,
                            Target.PhoneNumber = Source.PhoneNumber,
                            Target.PhoneNumberConfirmed = Source.PhoneNumberConfirmed,
                            Target.TwoFactorEnabled = Source.TwoFactorEnabled,
                            Target.LockoutEnd = Source.LockoutEnd,
                            Target.LockoutEnabled = Source.LockoutEnabled,
                            Target.AccessFailedCount = Source.AccessFailedCount
                    WHEN NOT MATCHED BY Target THEN
                        INSERT (Id, UserName, NormalizedUserName, Email, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
                        VALUES (Source.Id, Source.UserName, Source.NormalizedUserName, Source.Email, Source.EmailConfirmed, Source.PasswordHash, Source.SecurityStamp, Source.ConcurrencyStamp, Source.PhoneNumber, Source.PhoneNumberConfirmed, Source.TwoFactorEnabled, Source.LockoutEnd, Source.LockoutEnabled, Source.AccessFailedCount)
                    WHEN NOT MATCHED BY Source THEN
                        DELETE;
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER SyncUsersOnInsertUpdate
                ON AuthServiceDb.dbo.AspNetUsers
                AFTER INSERT, UPDATE
                AS
                BEGIN
                    -- Wywołaj procedurę składowaną, aby zsynchronizować dane
                    EXEC SyncAspNetUsersToApplicationUsers;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
