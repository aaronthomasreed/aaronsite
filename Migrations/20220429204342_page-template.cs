using Microsoft.EntityFrameworkCore.Migrations;

namespace AaronSite.Migrations
{
    public partial class pagetemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ViewName",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Page",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Page_TemplateId",
                table: "Page",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Template_TemplateId",
                table: "Page",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Template_TemplateId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_TemplateId",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ViewName",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Page");
        }
    }
}
