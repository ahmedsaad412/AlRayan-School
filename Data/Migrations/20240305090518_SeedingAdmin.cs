using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture], [CenterId], [StudentId], [TeatcherId]) VALUES (N'dc2e3186-9ae4-4b75-acab-21b9cd14f582', N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAECF7xgBk/UwXt5l6TBzsGPG5KnY5ozJtEQcsxRuIR0tq35c9hsEPinacFjWOK2ehXw==', N'UBL3QGQXFLAU3UMCHRK7ON4J7UZKZZBZ', N'a3377294-4fca-4f05-8e67-1ee083b67eb0', NULL, 0, 0, NULL, 1, 0, N'ahmed', N'saad', Null, NULL, NULL, NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id='dc2e3186-9ae4-4b75-acab-21b9cd14f582'");
        }
    }
}
