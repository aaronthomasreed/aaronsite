using Microsoft.EntityFrameworkCore.Migrations;

namespace AaronSite.Migrations
{
    public partial class climb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ClimbEntries",
                newName: "Stlye");

            migrationBuilder.AddColumn<bool>(
                name: "IsIndoors",
                table: "ClimbEntries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndoors",
                table: "ClimbEntries");

            migrationBuilder.RenameColumn(
                name: "Stlye",
                table: "ClimbEntries",
                newName: "Type");
        }
    }
}
