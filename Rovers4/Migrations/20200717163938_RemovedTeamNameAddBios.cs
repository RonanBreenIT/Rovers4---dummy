using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rovers4.Migrations
{
    public partial class RemovedTeamNameAddBios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Fixtures");

            migrationBuilder.AddColumn<string>(
                name: "TeamBio",
                table: "Teams",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonBio",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImage",
                table: "Persons",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 1,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 1, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 2,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 1, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 3,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 1, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 4,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 1, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 5,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 1, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 6,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 1, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 7,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 1, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 8,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 2, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 9,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(2080, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 2, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 10,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(1980, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 2, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 11,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(1980, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 3, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 12,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(1980, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 3, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 13,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(1980, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 3, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 14,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "PersonBio", "TeamID", "ThumbnailImage" },
                values: new object[] { new DateTime(1980, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "X@X.com", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "111 1111111", "Alan Mannus began his career with Linfield where he won five league titles in nine years. He joined Shamrock Rovers in August 2009, making his first appearance in a 2-2 draw against Dundalk in Tallaght. Mannus won the 2010 SWAI Goalkeeper of the Year the following season as Rovers won the league for the first time in 16 years.The club lifted the Setanta Cup trophy in May 2011 but he moved to St Johnstone two months later, making his last appearance in a Hoops jersey in a Champions League tie away to Flora Tallinn. Mannus debuted against Hearts the following February and played a total of 191 league games in Scotland, helping the Saints to their first ever Scottish Cup in 2014. The Northern Ireland goalkeeper made his international debut in 2004 and was part of former Hoops manager Michael O’Neill’s Euro 2016 squad in France. Alan rejoined the Hoops in the summer of 2018.He spoke to Hoops Scene a the start of our 2019 Europa League campaign", 3, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 1,
                column: "TeamBio",
                value: "First Team Compete in Leinster Senior League 2. They have been together since 2014 and recently appointed Mike Bassett for the new season.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 2,
                column: "TeamBio",
                value: "The Under 21 Team Compete in Leinster Senior League 1. They have been together since 2015.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 3,
                column: "TeamBio",
                value: "The Under 19 Team Compete in Leinster Senior League 3. They have been together since 2014.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 4,
                column: "TeamBio",
                value: "The Under 17 Team Compete in Leinster Senior League 2. They have been together since 2013.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 5,
                column: "TeamBio",
                value: "The Under 15 Team Compete in Leinster Senior League 2. They have been together since 2014.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 6,
                column: "TeamBio",
                value: "The Under 13 Team Compete in Leinster Senior League 2. They have been together since 2014.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 7,
                column: "TeamBio",
                value: "The Under 11 Team Compete in Leinster Senior League 2. They have been together since 2014.");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamID",
                table: "Persons",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TeamBio",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PersonBio",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ThumbnailImage",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Fixtures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 1,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "First Team" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 2,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "First Team" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 3,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "First Team" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 4,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "First Team" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 5,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "First Team" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 6,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "First Team" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 7,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "First Team" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 8,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "Under 21s" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 9,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "Under 21s" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 10,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "Under 21s" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 11,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "Under 19s" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 12,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "Under 19s" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 13,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "Under 19s" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonID",
                keyValue: 14,
                columns: new[] { "DOB", "Email", "Image", "Mobile", "TeamID", "TeamName" },
                values: new object[] { null, null, null, null, null, "Under 19s" });

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamID",
                table: "Persons",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
