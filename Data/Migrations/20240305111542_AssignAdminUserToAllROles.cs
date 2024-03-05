using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminUserToAllROles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into [security].[UserRoles](UserId,RoleId)select 'dc2e3186-9ae4-4b75-acab-21b9cd14f582',Id from [security].Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='dc2e3186-9ae4-4b75-acab-21b9cd14f582'");
        }
    }
}
