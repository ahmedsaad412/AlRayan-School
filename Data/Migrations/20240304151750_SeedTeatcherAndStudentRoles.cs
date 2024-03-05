using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTeatcherAndStudentRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                schema: "security",
                values: new object[]
                {Guid.NewGuid().ToString(),
                    "Teatcher",
                    "Teatcher".ToUpper(),
                     Guid.NewGuid().ToString()}
                );
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                schema: "security",
                values: new object[]
                {Guid.NewGuid().ToString(),
                    "Student",
                    "Student".ToUpper(),
                     Guid.NewGuid().ToString()}
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Roles]");
        }
    }
}
