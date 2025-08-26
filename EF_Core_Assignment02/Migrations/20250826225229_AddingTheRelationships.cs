using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Assignment02.Migrations
{
    /// <inheritdoc />
    public partial class AddingTheRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Last Name",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "First Name",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "Dept_ID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dept_ID",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentManager_ID",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Topic_ID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inst_Courses",
                columns: table => new
                {
                    Inst_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Evaluate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inst_Courses", x => new { x.Inst_ID, x.Course_ID });
                    table.CheckConstraint("CHK_CourseInst_Evaluate", "[Evaluate] BETWEEN 1 AND 10");
                    table.ForeignKey(
                        name: "FK_Inst_Courses_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inst_Courses_Instructors_Inst_ID",
                        column: x => x.Inst_ID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stud_Courses",
                columns: table => new
                {
                    Stud_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stud_Courses", x => new { x.Stud_ID, x.Course_ID });
                    table.CheckConstraint("CHK_StudCourse_Grade", "[Grade] BETWEEN 0 AND 100");
                    table.ForeignKey(
                        name: "FK_Stud_Courses_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stud_Courses_Students_Stud_ID",
                        column: x => x.Stud_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dept_ID",
                table: "Students",
                column: "Dept_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dept_ID",
                table: "Instructors",
                column: "Dept_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentManager_ID",
                table: "Departments",
                column: "DepartmentManager_ID",
                unique: true,
                filter: "[DepartmentManager_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Topic_ID",
                table: "Courses",
                column: "Topic_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inst_Courses_Course_ID",
                table: "Inst_Courses",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Stud_Courses_Course_ID",
                table: "Stud_Courses",
                column: "Course_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Topics_Topic_ID",
                table: "Courses",
                column: "Topic_ID",
                principalTable: "Topics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_DepartmentManager_ID",
                table: "Departments",
                column: "DepartmentManager_ID",
                principalTable: "Instructors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_Dept_ID",
                table: "Instructors",
                column: "Dept_ID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Dept_ID",
                table: "Students",
                column: "Dept_ID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Topics_Topic_ID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_DepartmentManager_ID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_Dept_ID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Dept_ID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Inst_Courses");

            migrationBuilder.DropTable(
                name: "Stud_Courses");

            migrationBuilder.DropIndex(
                name: "IX_Students_Dept_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_Dept_ID",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentManager_ID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Topic_ID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Dept_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Dept_ID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "DepartmentManager_ID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Topic_ID",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Last Name",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "First Name",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
