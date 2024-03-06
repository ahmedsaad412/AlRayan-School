using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlRayan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDbsetsProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Center_CenterId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Course_CourseId",
                table: "Student_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Student_StudentId",
                table: "Student_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teatcher_Center_CenterId",
                table: "Teatcher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teatcher_Course_CourseId",
                table: "Teatcher");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teatcher",
                table: "Teatcher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Center",
                table: "Center");

            migrationBuilder.RenameTable(
                name: "Teatcher",
                newName: "Teatchers");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Center",
                newName: "Centers");

            migrationBuilder.RenameIndex(
                name: "IX_Teatcher_CourseId",
                table: "Teatchers",
                newName: "IX_Teatchers_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Teatcher_CenterId",
                table: "Teatchers",
                newName: "IX_Teatchers_CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_CenterId",
                table: "Courses",
                newName: "IX_Courses_CenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teatchers",
                table: "Teatchers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers",
                table: "Centers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Centers_CenterId",
                table: "Courses",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Courses_CourseId",
                table: "Student_Courses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Students_StudentId",
                table: "Student_Courses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teatchers_Centers_CenterId",
                table: "Teatchers",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teatchers_Courses_CourseId",
                table: "Teatchers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Centers_CenterId",
                schema: "security",
                table: "Users",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_StudentId",
                schema: "security",
                table: "Users",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teatchers_TeatcherId",
                schema: "security",
                table: "Users",
                column: "TeatcherId",
                principalTable: "Teatchers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Centers_CenterId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Courses_CourseId",
                table: "Student_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Students_StudentId",
                table: "Student_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teatchers_Centers_CenterId",
                table: "Teatchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teatchers_Courses_CourseId",
                table: "Teatchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Centers_CenterId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_StudentId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teatchers_TeatcherId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teatchers",
                table: "Teatchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers",
                table: "Centers");

            migrationBuilder.RenameTable(
                name: "Teatchers",
                newName: "Teatcher");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Centers",
                newName: "Center");

            migrationBuilder.RenameIndex(
                name: "IX_Teatchers_CourseId",
                table: "Teatcher",
                newName: "IX_Teatcher_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Teatchers_CenterId",
                table: "Teatcher",
                newName: "IX_Teatcher_CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CenterId",
                table: "Course",
                newName: "IX_Course_CenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teatcher",
                table: "Teatcher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Center",
                table: "Center",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Center_CenterId",
                table: "Course",
                column: "CenterId",
                principalTable: "Center",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Course_CourseId",
                table: "Student_Courses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Student_StudentId",
                table: "Student_Courses",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teatcher_Center_CenterId",
                table: "Teatcher",
                column: "CenterId",
                principalTable: "Center",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teatcher_Course_CourseId",
                table: "Teatcher",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
