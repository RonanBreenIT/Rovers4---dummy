using Microsoft.EntityFrameworkCore.Migrations;

namespace Rovers4.Migrations
{
    public partial class AddTeamIDIntoFixtureClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_TeamID",
                table: "Fixtures");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Fixtures",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_TeamID",
                table: "Fixtures",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_TeamID",
                table: "Fixtures");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Fixtures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_TeamID",
                table: "Fixtures",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
