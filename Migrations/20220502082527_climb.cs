using Microsoft.EntityFrameworkCore.Migrations;

namespace AaronSite.Migrations
{
    public partial class climb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Page_ParentId",
                table: "Page");

            migrationBuilder.DropForeignKey(
                name: "FK_Page_Template_TemplateId",
                table: "Page");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Template",
                table: "Template");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Page",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Template");

            migrationBuilder.RenameTable(
                name: "Template",
                newName: "Templates");

            migrationBuilder.RenameTable(
                name: "Page",
                newName: "Pages");

            migrationBuilder.RenameIndex(
                name: "IX_Page_TemplateId",
                table: "Pages",
                newName: "IX_Pages_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_Page_ParentId",
                table: "Pages",
                newName: "IX_Pages_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Templates",
                table: "Templates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClimbGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hueco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Font = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YDS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenchSport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClimbEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimbEntries_ClimbGrades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "ClimbGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClimbEntries_GradeId",
                table: "ClimbEntries",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Pages_ParentId",
                table: "Pages",
                column: "ParentId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Templates_TemplateId",
                table: "Pages",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Pages_ParentId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Templates_TemplateId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "ClimbEntries");

            migrationBuilder.DropTable(
                name: "ClimbGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Templates",
                table: "Templates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.RenameTable(
                name: "Templates",
                newName: "Template");

            migrationBuilder.RenameTable(
                name: "Pages",
                newName: "Page");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_TemplateId",
                table: "Page",
                newName: "IX_Page_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_ParentId",
                table: "Page",
                newName: "IX_Page_ParentId");

            migrationBuilder.AddColumn<string>(
                name: "ModelType",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Template",
                table: "Template",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Page",
                table: "Page",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Page_ParentId",
                table: "Page",
                column: "ParentId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Template_TemplateId",
                table: "Page",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
