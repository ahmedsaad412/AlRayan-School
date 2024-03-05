using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities_WithRelation1To1WithApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeatcherId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Center_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Center",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teatcher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teatcher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teatcher_Center_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Center",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teatcher_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CenterId",
                schema: "security",
                table: "Users",
                column: "CenterId",
                unique: true,
                filter: "[CenterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                schema: "security",
                table: "Users",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeatcherId",
                schema: "security",
                table: "Users",
                column: "TeatcherId",
                unique: true,
                filter: "[TeatcherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CenterId",
                table: "Course",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Teatcher_CenterId",
                table: "Teatcher",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Teatcher_CourseId",
                table: "Teatcher",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Center_CenterId",
                schema: "security",
                table: "Users",
                column: "CenterId",
                principalTable: "Center",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Student_StudentId",
                schema: "security",
                table: "Users",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teatcher_TeatcherId",
                schema: "security",
                table: "Users",
                column: "TeatcherId",
                principalTable: "Teatcher",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Center_CenterId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Student_StudentId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teatcher_TeatcherId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teatcher");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropIndex(
                name: "IX_Users_CenterId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeatcherId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CenterId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeatcherId",
                schema: "security",
                table: "Users");
        }
    }
}
