using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table:"Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                schema: "security",
                values:new object[] 
                {Guid.NewGuid().ToString(),
                    "Admin",
                    "Admin".ToUpper(),
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
