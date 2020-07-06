using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class UpdatedSpeaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Speciality",
                table: "Speakers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Speakers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Speakers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Backgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backgrounds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backgrounds");

            migrationBuilder.AlterColumn<int>(
                name: "Speciality",
                table: "Speakers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Speakers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "Image",
                table: "Speakers",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
