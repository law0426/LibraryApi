using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAuthenticationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE "Users"
                ALTER COLUMN "IdentityProviderId" DROP DEFAULT;
                """);

            migrationBuilder.Sql("""
                UPDATE "Users"
                SET "IdentityProviderId" = uuidv7()::text;
                """);

            migrationBuilder.Sql("""
                ALTER TABLE "Users"
                ALTER COLUMN "IdentityProviderId" TYPE uuid
                USING "IdentityProviderId"::uuid;
                """);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityProviderId",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
