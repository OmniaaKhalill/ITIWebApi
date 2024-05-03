using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Topic",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Course_Course",
                table: "Ins_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Course_Instructor",
                table: "Ins_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Stud_Course_Course",
                table: "Stud_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Stud_Course_Student",
                table: "Stud_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Student",
                table: "Student");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<int>(
                name: "Top_Id",
                table: "Topic",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "St_Lname",
                table: "Student",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ins_Id",
                table: "Instructor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_Id",
                table: "Department",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Crs_Id",
                table: "Course",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Topic_Top_Id",
                table: "Course",
                column: "Top_Id",
                principalTable: "Topic",
                principalColumn: "Top_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_Dept_Manager",
                table: "Department",
                column: "Dept_Manager",
                principalTable: "Instructor",
                principalColumn: "Ins_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Course_Course_Crs_Id",
                table: "Ins_Course",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Crs_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Course_Instructor_Ins_Id",
                table: "Ins_Course",
                column: "Ins_Id",
                principalTable: "Instructor",
                principalColumn: "Ins_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department_Dept_Id",
                table: "Instructor",
                column: "Dept_Id",
                principalTable: "Department",
                principalColumn: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stud_Course_Course_Crs_Id",
                table: "Stud_Course",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Crs_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stud_Course_Student_St_Id",
                table: "Stud_Course",
                column: "St_Id",
                principalTable: "Student",
                principalColumn: "St_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_Dept_Id",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Department",
                principalColumn: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Student_St_super",
                table: "Student",
                column: "St_super",
                principalTable: "Student",
                principalColumn: "St_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Topic_Top_Id",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_Dept_Manager",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Course_Course_Crs_Id",
                table: "Ins_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Course_Instructor_Ins_Id",
                table: "Ins_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department_Dept_Id",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Stud_Course_Course_Crs_Id",
                table: "Stud_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Stud_Course_Student_St_Id",
                table: "Stud_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_Dept_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Student_St_super",
                table: "Student");

            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<int>(
                name: "Top_Id",
                table: "Topic",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "St_Lname",
                table: "Student",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ins_Id",
                table: "Instructor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_Id",
                table: "Department",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Crs_Id",
                table: "Course",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Topic",
                table: "Course",
                column: "Top_Id",
                principalTable: "Topic",
                principalColumn: "Top_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor",
                table: "Department",
                column: "Dept_Manager",
                principalTable: "Instructor",
                principalColumn: "Ins_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Course_Course",
                table: "Ins_Course",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Crs_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Course_Instructor",
                table: "Ins_Course",
                column: "Ins_Id",
                principalTable: "Instructor",
                principalColumn: "Ins_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department",
                table: "Instructor",
                column: "Dept_Id",
                principalTable: "Department",
                principalColumn: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stud_Course_Course",
                table: "Stud_Course",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Crs_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stud_Course_Student",
                table: "Stud_Course",
                column: "St_Id",
                principalTable: "Student",
                principalColumn: "St_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Department",
                principalColumn: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Student",
                table: "Student",
                column: "St_super",
                principalTable: "Student",
                principalColumn: "St_Id");
        }
    }
}
