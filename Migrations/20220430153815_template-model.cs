using Microsoft.EntityFrameworkCore.Migrations;

namespace AaronSite.Migrations
{
    public partial class templatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModelType",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Template");
        }
    }
}
