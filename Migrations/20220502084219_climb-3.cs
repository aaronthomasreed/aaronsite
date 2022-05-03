using Microsoft.EntityFrameworkCore.Migrations;

namespace AaronSite.Migrations
{
    public partial class climb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stlye",
                table: "ClimbEntries",
                newName: "Style");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Style",
                table: "ClimbEntries",
                newName: "Stlye");
        }
    }
}
