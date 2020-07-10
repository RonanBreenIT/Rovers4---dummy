using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rovers4.Migrations
{
    public partial class SetUpClubTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Number = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    PlayerStatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GamesPlayed = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    Goals = table.Column<int>(nullable: false),
                    CleanSheet = table.Column<int>(nullable: false),
                    RedCards = table.Column<int>(nullable: false),
                    MotmAward = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.PlayerStatID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ClubID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Teams_Clubs_ClubID",
                        column: x => x.ClubID,
                        principalTable: "Clubs",
                        principalColumn: "ClubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    FixtureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true),
                    FixtureType = table.Column<int>(nullable: false),
                    FixtureDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    HomeOrAway = table.Column<int>(nullable: false),
                    MeetTime = table.Column<DateTime>(nullable: false),
                    MeetLocation = table.Column<string>(nullable: true),
                    OurScore = table.Column<int>(nullable: true),
                    Opponent = table.Column<string>(nullable: true),
                    OpponentScore = table.Column<int>(nullable: true),
                    ResultDescription = table.Column<int>(nullable: false),
                    MatchReport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.FixtureID);
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_TeamName",
                        column: x => x.TeamName,
                        principalTable: "Teams",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonType = table.Column<int>(nullable: false),
                    MgmtRole = table.Column<int>(nullable: true),
                    PlayerPosition = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    Surname = table.Column<string>(maxLength: 40, nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    PlayerStatID = table.Column<int>(nullable: false),
                    PlayerStatID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Persons_PlayerStats_PlayerStatID1",
                        column: x => x.PlayerStatID1,
                        principalTable: "PlayerStats",
                        principalColumn: "PlayerStatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Teams_TeamName",
                        column: x => x.TeamName,
                        principalTable: "Teams",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubID", "Address", "Email", "Name", "Number" },
                values: new object[] { 1, "Bushy Park", "X00152190@mytudublin.ie", "Ratharnham Rovers", "0872878566" });

            migrationBuilder.InsertData(
                table: "PlayerStats",
                columns: new[] { "PlayerStatID", "Assists", "CleanSheet", "GamesPlayed", "Goals", "MotmAward", "PersonID", "RedCards" },
                values: new object[,]
                {
                    { 1, 5, 0, 5, 3, 3, 1, 2 },
                    { 2, 1, 0, 3, 1, 1, 2, 0 },
                    { 3, 2, 0, 2, 2, 2, 3, 2 },
                    { 4, 5, 0, 3, 3, 3, 4, 2 },
                    { 5, 5, 0, 5, 3, 3, 5, 2 },
                    { 6, 5, 0, 5, 3, 3, 6, 2 },
                    { 7, 5, 0, 5, 3, 3, 7, 2 },
                    { 8, 5, 0, 5, 3, 3, 8, 2 },
                    { 9, 5, 0, 5, 3, 3, 9, 2 },
                    { 10, 5, 0, 5, 3, 3, 10, 2 },
                    { 11, 5, 0, 5, 3, 3, 11, 2 },
                    { 12, 5, 0, 5, 3, 3, 12, 2 },
                    { 13, 5, 0, 5, 3, 3, 13, 2 },
                    { 14, 5, 0, 5, 3, 3, 14, 2 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Name", "ClubID" },
                values: new object[,]
                {
                    { "First Team", 1 },
                    { "Under 21s", 1 },
                    { "Under 19s", 1 },
                    { "Under 17s", 1 },
                    { "Under 15s", 1 },
                    { "Under 13s", 1 },
                    { "Under 11s", 1 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonID", "DOB", "Email", "FirstName", "Image", "MgmtRole", "Mobile", "PersonType", "PlayerPosition", "PlayerStatID", "PlayerStatID1", "Surname", "TeamName" },
                values: new object[,]
                {
                    { 1, null, null, "Ronan", null, null, null, 0, 1, 0, null, "Breen", "First Team" },
                    { 2, null, null, "Ronan", null, null, null, 0, 0, 0, null, "Grey", "First Team" },
                    { 3, null, null, "Richard", null, null, null, 0, 2, 0, null, "Breen", "First Team" },
                    { 4, null, null, "Andrew", null, null, null, 0, 3, 0, null, "Breen", "First Team" },
                    { 5, null, null, "Murray", null, null, null, 0, 1, 0, null, "Breen", "First Team" },
                    { 6, null, null, "Patricia", null, null, null, 0, 0, 0, null, "Breen", "First Team" },
                    { 7, null, null, "Elmond", null, 0, null, 1, null, 0, null, "Breen", "First Team" },
                    { 8, null, null, "Tim", null, null, null, 0, 0, 0, null, "Breen", "Under 21s" },
                    { 9, null, null, "Tom", null, null, null, 0, 1, 0, null, "Grey", "Under 21s" },
                    { 10, null, null, "Trevor", null, null, null, 0, 2, 0, null, "Breen", "Under 21s" },
                    { 11, null, null, "Tilly", null, null, null, 0, 3, 0, null, "Breen", "Under 19s" },
                    { 12, null, null, "Tyrance", null, null, null, 0, 0, 0, null, "Breen", "Under 19s" },
                    { 13, null, null, "Tombo", null, null, null, 0, 1, 0, null, "Breen", "Under 19s" },
                    { 14, null, null, "Timo", null, null, null, 1, 3, 0, null, "Breen", "Under 19s" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TeamName",
                table: "Fixtures",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PlayerStatID1",
                table: "Persons",
                column: "PlayerStatID1");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamName",
                table: "Persons",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ClubID",
                table: "Teams",
                column: "ClubID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PlayerStats");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
