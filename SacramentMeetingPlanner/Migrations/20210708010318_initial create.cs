using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conductor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningSongNumber = table.Column<int>(type: "int", nullable: false),
                    SacramentSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SacramentSongNumber = table.Column<int>(type: "int", nullable: false),
                    ClosingSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingNumber = table.Column<int>(type: "int", nullable: false),
                    IntermediateSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntermediateSongNumber = table.Column<int>(type: "int", nullable: false),
                    MusicalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningPrayerBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingPrayerBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Speaker");
        }
    }
}
