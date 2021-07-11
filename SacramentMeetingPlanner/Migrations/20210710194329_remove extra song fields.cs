using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class removeextrasongfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingSong",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "IntermediateSong",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "OpeningSong",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "SacramentSong",
                table: "Meeting");

            migrationBuilder.RenameColumn(
                name: "ClosingNumber",
                table: "Meeting",
                newName: "ClosingSongNumber");

            migrationBuilder.AlterColumn<int>(
                name: "IntermediateSongNumber",
                table: "Meeting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClosingSongNumber",
                table: "Meeting",
                newName: "ClosingNumber");

            migrationBuilder.AlterColumn<int>(
                name: "IntermediateSongNumber",
                table: "Meeting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClosingSong",
                table: "Meeting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntermediateSong",
                table: "Meeting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningSong",
                table: "Meeting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SacramentSong",
                table: "Meeting",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
