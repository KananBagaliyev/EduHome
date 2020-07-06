using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class UpdatedAbouteTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "AboutTeachers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "AboutTeachers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "AboutTeachers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vimeo",
                table: "AboutTeachers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "AboutTeachers");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "AboutTeachers");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "AboutTeachers");

            migrationBuilder.DropColumn(
                name: "Vimeo",
                table: "AboutTeachers");
        }
    }
}
