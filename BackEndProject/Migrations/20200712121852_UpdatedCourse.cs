using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class UpdatedCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CourseDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 144);

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "AboutTeachers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CourseDetails",
                maxLength: 144,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "AboutTeachers",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
