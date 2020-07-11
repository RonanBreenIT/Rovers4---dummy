using Microsoft.EntityFrameworkCore.Migrations;

namespace Rovers4.Migrations
{
    public partial class AddedIDintoTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_TeamName",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamName",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TeamName",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_TeamName",
                table: "Fixtures");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: "First Team");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: "Under 11s");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: "Under 13s");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: "Under 15s");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: "Under 17s");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: "Under 19s");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: "Under 21s");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Teams",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Persons",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Fixtures",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Fixtures",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "ClubID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "First Team" },
                    { 2, 1, "Under 21s" },
                    { 3, 1, "Under 19s" },
                    { 4, 1, "Under 17s" },
                    { 5, 1, "Under 15s" },
                    { 6, 1, "Under 13s" },
                    { 7, 1, "Under 11s" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamID",
                table: "Persons",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TeamID",
                table: "Fixtures",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_TeamID",
                table: "Fixtures",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamID",
                table: "Persons",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_TeamID",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamID",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TeamID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_TeamID",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Fixtures");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Fixtures",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamName",
                table: "Persons",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TeamName",
                table: "Fixtures",
                column: "TeamName");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_TeamName",
                table: "Fixtures",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamName",
                table: "Persons",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
