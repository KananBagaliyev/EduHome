using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class UpdatedCourseFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SkillLevel",
                table: "CourseFeatures",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "CourseFeatures",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Assesments",
                table: "CourseFeatures",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SkillLevel",
                table: "CourseFeatures",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "CourseFeatures",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "Assesments",
                table: "CourseFeatures",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);
        }
    }
}
