using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into [security].[UserRoles](UserId,RoleId)select 'fb445ecf-7e19-4d07-bbed-ac5ac7e8f622',Id from [security].Roles");
            migrationBuilder.Sql("Insert into [security].[UserRoles](UserId,RoleId)select '0a0b88bf-bd6f-4844-8403-f5cc33860187','80cc15fe-1d2b-4e3d-b367-41d0f4913779'");
            migrationBuilder.Sql("Insert into [security].[UserRoles](UserId,RoleId)select '7aaa609f-63c4-41e7-ab9c-f8581a312c1e','42f4c85c-085c-48cc-86ea-501026b5c563'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='fb445ecf-7e19-4d07-bbed-ac5ac7e8f622'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='0a0b88bf-bd6f-4844-8403-f5cc33860187'"); 
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='7aaa609f-63c4-41e7-ab9c-f8581a312c1e'");
        }
    }
}
