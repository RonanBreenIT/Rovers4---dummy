using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rovers4.Migrations
{
    public partial class InitialSeedForAzure : Migration
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
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    ClubImage1 = table.Column<string>(nullable: true),
                    ClubImage2 = table.Column<string>(nullable: true),
                    ClubImage3 = table.Column<string>(nullable: true)
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
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    TeamBio = table.Column<string>(maxLength: 1280, nullable: true),
                    TeamImage = table.Column<string>(nullable: true),
                    ClubID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
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
                    TeamID = table.Column<int>(nullable: false),
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
                        name: "FK_Fixtures_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
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
                    ThumbnailImage = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    PersonBio = table.Column<string>(maxLength: 1280, nullable: true),
                    TeamID = table.Column<int>(nullable: false),
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
                        name: "FK_Persons_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TeamID",
                table: "Fixtures",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PlayerStatID1",
                table: "Persons",
                column: "PlayerStatID1");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamID",
                table: "Persons",
                column: "TeamID");

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
