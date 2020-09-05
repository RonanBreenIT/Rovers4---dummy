
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rovers4.Migrations
{
    public partial class AddedPhotosToClubAndTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeamBio",
                table: "Teams",
                maxLength: 1280,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamImage",
                table: "Teams",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonBio",
                table: "Persons",
                maxLength: 1280,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClubImage1",
                table: "Clubs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClubImage2",
                table: "Clubs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClubImage3",
                table: "Clubs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamImage",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ClubImage1",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ClubImage2",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ClubImage3",
                table: "Clubs");

            migrationBuilder.AlterColumn<string>(
                name: "TeamBio",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1280,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "PersonBio",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1280,
                oldNullable: true);
        }
    }
}
