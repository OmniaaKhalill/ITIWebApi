using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_Department_Instructor",
            table: "Department");

            migrationBuilder.DropTable(
                name: "Ins_Course");

            migrationBuilder.DropTable(
                name: "stdDelHisto_audit");

            migrationBuilder.DropTable(
                name: "stdHisto_audit");

            migrationBuilder.DropTable(
                name: "Stud_Course");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Department");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
