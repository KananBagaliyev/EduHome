using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class updatedCPN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CenterPhoneNumbers_Data_DataId",
                table: "CenterPhoneNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "DataId",
                table: "CenterPhoneNumbers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CenterPhoneNumbers_Data_DataId",
                table: "CenterPhoneNumbers",
                column: "DataId",
                principalTable: "Data",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CenterPhoneNumbers_Data_DataId",
                table: "CenterPhoneNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "DataId",
                table: "CenterPhoneNumbers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CenterPhoneNumbers_Data_DataId",
                table: "CenterPhoneNumbers",
                column: "DataId",
                principalTable: "Data",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
