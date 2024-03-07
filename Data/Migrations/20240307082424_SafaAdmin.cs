using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SafaAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CenterId], [StudentId], [TeatcherId], [Photo]) VALUES (N'fb445ecf-7e19-4d07-bbed-ac5ac7e8f622', N'safa', N'SAFA', N'safa@gmail.com', N'SAFA@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPgpAx+HYz2/0IP372EN+4kcJ9zuk/paiM7MYJugINjBCMVHQOC1Tewv1TMrdJwQIA==', N'BBTU63BLCXZIUDX2PVFXTZKQNEPSLN5C', N'cffd2e35-0bb5-464a-aac2-eb995e5c6aee', NULL, 0, 0, NULL, 1, 0, N'Ahmed', N'Saad', NULL, NULL, NULL, N'473cefdf-ace3-4851-ab95-5b854e636089.jpeg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id='fb445ecf-7e19-4d07-bbed-ac5ac7e8f622'");
        }
    }
}
